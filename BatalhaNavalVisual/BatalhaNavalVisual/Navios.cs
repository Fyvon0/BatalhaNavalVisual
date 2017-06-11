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

namespace BatalhaNavalVisual
{
    public partial class Navios : Form
    {
        public Navios()
        {
            InitializeComponent();
        }

        public int Direcao
        {
            get
            {
                if (rdbtnHorizontal.Checked)
                    return 3;
                return 0;
            }
        }

        public void RemoverNavio (TipoDeNavio barco)
        {
            switch(barco)
            {
                case TipoDeNavio.PortaAvioes:
                    pbPortaAvioes.Image = null;
                    break;
                case TipoDeNavio.Encouracado:
                    pbEncouracado.Image = null;
                    break;
                case TipoDeNavio.Cruzador:
                    pbCruzador.Image = null;
                    break;
                case TipoDeNavio.Destroier:
                    pbDestroier.Image = null;
                    break;
                case TipoDeNavio.Submarino:
                    pbSubmarino.Image = null;
                    break;
            }
        }

        private void Navios_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                PictureBox pb = (PictureBox)tableLayoutPanel1.Controls[i];
                pb.Image = Image.FromFile(pb.Tag + ".png");
            }

            this.ControlBox = false;
        }

        private void pbNavio_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (pb.Image != null)
            {
                pb.Image.Tag = pb.Tag;
                pb.DoDragDrop(pb.Image, DragDropEffects.All);
                //navio = (TipoDeNavio)Enum.Parse(typeof(TipoDeNavio), pb.Tag.ToString());
            }
        }
    }
}
