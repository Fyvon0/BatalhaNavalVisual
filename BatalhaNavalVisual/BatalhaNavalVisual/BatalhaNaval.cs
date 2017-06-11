using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BatalhaNaval;
using System.Net;

namespace BatalhaNavalVisual
{
    public partial class BatalhaNaval : Form
    {
        int x1, y1, x2, y2, tiroX, tiroY = -1;
        float larguraF, alturaF = 0F;
        TipoDeNavio navio = default(TipoDeNavio);
        Navios frmNavios;
        Tabuleiro tabuleiro;
        Jogadores frmJogadores;
        Regras frmRegras;
        Image miraVerde = Image.FromFile("miraverde.png");
        Image miraVermelha = Image.FromFile("miravermelha.png");
        ClienteP2P cliente;
        Dictionary<Tiro, ResultadoDeTiro> tirosDados;
        List<Tiro> tirosRecebidos;
        Image tiroVerde = Image.FromFile("xisVerde.png");
        Image tiroVermelho = Image.FromFile("xisVermelho.png");
        Image tiroPreto = Image.FromFile("xisPreto.png");
        int tempo = 31;
        bool podeAtirar = false;


        public BatalhaNaval()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Nick frmNick = new Nick();

            while (frmNick.ShowDialog(this) != DialogResult.OK)
                MessageBox.Show("Por favor escolha um nick");

            MessageBox.Show(frmNick.textBox1.Text);
            lblJogador.Text = frmNick.textBox1.Text;

            frmNavios = new Navios();
            frmNavios.Show(this);

            this.WindowState = FormWindowState.Maximized;

            frmRegras = new Regras();
            frmRegras.Show(this);

            tabuleiro = new Tabuleiro();

            tirosDados = new Dictionary<Tiro, ResultadoDeTiro>();
            tirosRecebidos = new List<Tiro>();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            larguraF = (sender as PictureBox).Width / 10F;
            alturaF = (sender as PictureBox).Height / 10F;

            if (navio != default(TipoDeNavio))
            {
                Image img = Image.FromFile(navio.ToString() + ".png");

                if (frmNavios.Direcao == 0)
                {
                    if (10 - navio.Tamanho() < y1)
                        y1 = 10 - navio.Tamanho();

                    e.Graphics.DrawImage(img, new RectangleF(larguraF * x1, alturaF * y1, larguraF, alturaF * navio.Tamanho()));
                }
                else
                {
                    if (10 - navio.Tamanho() < x1)
                        x1 = 10 - navio.Tamanho();

                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    e.Graphics.DrawImage(img, new RectangleF(larguraF * x1, alturaF * y1, larguraF * navio.Tamanho(), alturaF));
                }
            }

            foreach (KeyValuePair<int[], TipoDeNavio> barco in tabuleiro.Navios)
            {
                if (barco.Key[2] == 0)
                    e.Graphics.DrawImage(Image.FromFile(barco.Value.ToString() + ".png"), new RectangleF(larguraF * barco.Key[0], alturaF * barco.Key[1], larguraF, alturaF * barco.Value.Tamanho()));
                else
                {
                    Image img = Image.FromFile(barco.Value.ToString() + ".png");
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    e.Graphics.DrawImage(img, new RectangleF(larguraF * barco.Key[0], alturaF * barco.Key[1], larguraF * barco.Value.Tamanho(), alturaF));
                }
            }

            foreach (Tiro tiroRecebido in tirosRecebidos)
            {
                ResultadoDeTiro tiroRes = tabuleiro.Atirar(tiroRecebido.X, tiroRecebido.Y);
                Image tiro = tiroPreto;
                switch (tiroRes)
                {
                    case ResultadoDeTiro.Errou:
                        tiro = tiroVerde;
                        break;
                    case ResultadoDeTiro.Acertou:
                        tiro = tiroVermelho;
                        break;
                    case ResultadoDeTiro.Afundou:
                        tiro = tiroPreto;
                        break;
                }
                e.Graphics.DrawImage(tiro, tiroRecebido.X * larguraF, tiroRecebido.Y * alturaF, larguraF, alturaF);
            }

            for (int i = 1; i < 10; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2F), larguraF * i, 0, larguraF * i, (sender as PictureBox).Height - 1);
                e.Graphics.DrawLine(new Pen(Color.Black, 2F), 0, alturaF * i, (sender as PictureBox).Width - 1, alturaF * i);
            }

            if (x1 != -1)
                e.Graphics.DrawImage(miraVerde, x1 * larguraF, y1 * alturaF, larguraF, alturaF);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (larguraF != 0)
            {
                x1 = e.X / (int)(larguraF);
                y1 = e.Y / (int)(alturaF);
                (sender as PictureBox).Invalidate();
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (larguraF != 0)
            {
                x2 = e.X / (int)(larguraF);
                y2 = e.Y / (int)(alturaF);
                (sender as PictureBox).Invalidate();
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (frmNavios.Direcao == 0)
            {
                if (10 - navio.Tamanho() < y1)
                    y1 = 10 - navio.Tamanho();
            }
            else
                if (10 - navio.Tamanho() < x1)
                x1 = 10 - navio.Tamanho();

            try
            {
                tabuleiro.PosicionarNavio(navio, x1, y1, (Direcao)frmNavios.Direcao);
                frmNavios.RemoverNavio(navio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Posição inválida");
            }
            if (tabuleiro.EstaCompleto())
            {
                frmNavios.Close();
                cliente = new ClienteP2P(lblJogador.Text, tabuleiro);
                frmJogadores = new Jogadores();
                frmJogadores.btnConectar.Click += BtnConectar_Click;
                frmJogadores.Show(this);
                cliente.OnClienteDisponivel += Cliente_OnClienteDisponivel;
                cliente.OnClienteRequisitandoConexao += Cliente_OnClienteRequisitandoConexao;
                cliente.OnClienteConectado += Cliente_OnClienteConectado;
                cliente.OnClienteDesconectado += Cliente_OnClienteDesconectado;
                cliente.OnDarTiro += Cliente_OnDarTiro;
                cliente.OnResultadoDeTiro += Cliente_OnResultadoDeTiro;
                cliente.OnTiroRecebido += Cliente_OnTiroRecebido;
                cliente.OnClienteDisponivel += Cliente_OnClienteDisponivel;
                cliente.OnClienteIndisponivel += Cliente_OnClienteIndisponivel;
                // cliente.OnFimDeJogo += Cliente_OnFimDeJogo;
                cliente.Iniciar();
            }
            navio = default(TipoDeNavio);
        }

        private void Cliente_OnClienteConectado(IPAddress addr)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(cliente.NomeRemoto + " conectou com você =)");
                frmJogadores.Close();
                lblOponente.Text = cliente.NomeRemoto;
                timer.Enabled = true;
                lblTempo.Text = tempo + "";
            }));
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                try
                {
                    if (frmJogadores.cbUsuarios.SelectedIndex < 0)
                    {
                        frmJogadores.btnConectar.Enabled = true;
                        return;
                    }

                    MessageBox.Show(frmJogadores.cbUsuarios.SelectedItem.ToString());
                    if (!cliente.SolicitarConexao((IPAddress)frmJogadores.cbUsuarios.SelectedItem))
                    {
                        MessageBox.Show(this, "O cliente remoto recusou a conexão", "Batalha Naval", MessageBoxButtons.OK);
                        frmJogadores.btnConectar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(cliente.NomeRemoto + " conectou com você =)");
                        frmJogadores.Close();
                        lblOponente.Text = cliente.NomeRemoto;
                        timer.Enabled = true;
                        lblTempo.Text = tempo + "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Não foi possível conectar ao cliente remoto. Tento novamente mais tarde.\r\n" + ex.Message, "Batalha Naval", MessageBoxButtons.OK);
                    frmJogadores.cbUsuarios.Items.RemoveAt(frmJogadores.cbUsuarios.SelectedIndex);
                    frmJogadores.btnConectar.Enabled = true;
                }
            }));
        }

        private void Cliente_OnClienteDisponivel(System.Net.IPAddress addr)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { Cliente_OnClienteDisponivel(addr); }));
            else
            if (frmJogadores != null)
                frmJogadores.Adicionar(addr);
        }

        private bool Cliente_OnClienteRequisitandoConexao(System.Net.IPAddress addr)
        {
            DialogResult r = DialogResult.No;

            Invoke(new Action(() => { r = MessageBox.Show(this, string.Format("{0} ({1}) quer jogar com você. Aceitar?", cliente.NomeRemoto, addr), "Batalha Naval", MessageBoxButtons.YesNo); }));

            if (r == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void Cliente_OnClienteDesconectado(IPAddress ip)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(cliente.NomeRemoto + " se desconectou");
                Reiniciar();
            }));
        }

        private void Cliente_OnDarTiro()
        {
            Invoke(new Action(() =>
            {
                podeAtirar = true;
                tempo = 31;
                lblTempo.Text = tempo + "";
                Console.WriteLine("sua vez");
            }));
        }

        private void Cliente_OnResultadoDeTiro(Tiro t, ResultadoDeTiro resultado)
        {
            Invoke(new Action(() =>
            {
                Console.WriteLine("Atirô");
                tirosDados.Add(new Tiro(tiroX,tiroY), resultado);
                tiroX = tiroY = -1;
                pictureBox1.Invalidate();
                pictureBox2.Invalidate();
                podeAtirar = false;
            }));
        }

        private void Cliente_OnTiroRecebido(Tiro t)
        {
            Invoke(new Action(() =>
            {
                Console.WriteLine("tomou tiro");
                tirosRecebidos.Add(t);
            }));
        }

        private void Cliente_OnClienteIndisponivel(IPAddress addr)
        {
            Invoke(new Action(() => { frmJogadores.Remover(addr); }));
        }

        private void Cliente_OnFimDeJogo(bool ganhou)
        {
            Invoke(new Action(() =>
            {
                if (ganhou)
                    MessageBox.Show("Parabéns!! Você ganhou! =D");
                else
                    MessageBox.Show("Ahh... Você perdeu... D=");

                Reiniciar();
            }));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cliente == null)
                return;
            if (cliente.Conectado)
                Invoke(new Action(() =>
                {
                    if (podeAtirar)
                    {
                        cliente.DarTiro(x2, y2);
                        tiroX = x2;
                        tiroY = y2;
                        pictureBox2.Invalidate();
                        podeAtirar = false;
                    }
                }));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tempo > 0)
            {
                tempo--;
                lblTempo.Text = tempo + "";
            }
        }

        private void Reiniciar()
        {
            frmNavios = new Navios();
            frmNavios.Show(this);

            cliente = null;
            tabuleiro = new Tabuleiro();

            frmJogadores = null;

            tirosDados = new Dictionary<Tiro, ResultadoDeTiro>();
            tirosRecebidos = new List<Tiro>();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            larguraF = (sender as PictureBox).Width / 10F;
            alturaF = (sender as PictureBox).Height / 10F;

            foreach (KeyValuePair<Tiro, ResultadoDeTiro> tiroDado in tirosDados)
            {
                ResultadoDeTiro tiroRes = tiroDado.Value;
                Image tiro = tiroPreto;
                Console.WriteLine("Tirores" + tiroRes);
                switch (tiroRes)
                {
                    case ResultadoDeTiro.Errou:
                        tiro = tiroVerde;
                        break;
                    case ResultadoDeTiro.Acertou:
                        tiro = tiroVermelho;
                        break;
                    case ResultadoDeTiro.Afundou:
                        tiro = tiroPreto;
                        break;
                    case ResultadoDeTiro.Ganhou:
                        MessageBox.Show("Ganhou Miserávi");
                        break;
                    default:
                        Console.WriteLine(tiroRes + "");
                        break;
                }
                e.Graphics.DrawImage(tiro, tiroDado.Key.X * larguraF, tiroDado.Key.Y * alturaF, larguraF, alturaF);
            }

            for (int i = 1; i < 10; i++)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2F), larguraF * i, 0, larguraF * i, (sender as PictureBox).Height - 1);
                e.Graphics.DrawLine(new Pen(Color.Black, 2F), 0, alturaF * i, (sender as PictureBox).Width - 1, alturaF * i);
            }

            if (tiroX != -1)
                e.Graphics.DrawRectangle(new Pen(Color.Aquamarine, 2f), tiroX * larguraF, tiroY * alturaF, larguraF, alturaF);

            if (x2 != -1)
                e.Graphics.DrawImage(miraVermelha, x2 * larguraF, y2 * alturaF, larguraF, alturaF);
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
                navio = (TipoDeNavio)Enum.Parse(typeof(TipoDeNavio), ((Bitmap)e.Data.GetData(DataFormats.Bitmap)).Tag.ToString());
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            if (larguraF != 0)
            {
                Point p = (sender as PictureBox).PointToClient(new Point(e.X, e.Y));
                x1 = p.X / (int)(larguraF);
                y1 = p.Y / (int)(alturaF);
                (sender as PictureBox).Invalidate();
            }
        }
    }
}
