using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatalhaNavalVisual
{
    public partial class Regras : Form
    {
        public Regras()
        {
            InitializeComponent();
        }

        private void Regras_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            dataGridView1.RowCount = 5;
            dataGridView1.AllowUserToResizeRows = dataGridView1.AllowUserToResizeColumns = false;

            dataGridView1.Rows[0].Cells[0].Value = Image.FromFile("PortaAvioes.png");
            ((Image)dataGridView1.Rows[0].Cells[0].Value).RotateFlip(RotateFlipType.Rotate270FlipNone);
            ((DataGridViewImageCell)dataGridView1.Rows[0].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Rows[0].Cells[1].Value = "Porta Avioes";
            dataGridView1.Rows[0].Cells[2].Value = "5";

            dataGridView1.Rows[1].Cells[0].Value = Image.FromFile("Encouracado.png");
            ((Image)dataGridView1.Rows[1].Cells[0].Value).RotateFlip(RotateFlipType.Rotate270FlipNone);
            ((DataGridViewImageCell)dataGridView1.Rows[1].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Rows[1].Cells[1].Value = "Encouracado";
            dataGridView1.Rows[1].Cells[2].Value = "4";

            dataGridView1.Rows[2].Cells[0].Value = Image.FromFile("Cruzador.png");
            ((Image)dataGridView1.Rows[2].Cells[0].Value).RotateFlip(RotateFlipType.Rotate270FlipNone);
            ((DataGridViewImageCell)dataGridView1.Rows[2].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Rows[2].Cells[1].Value = "Cruzador";
            dataGridView1.Rows[2].Cells[2].Value = "3";

            dataGridView1.Rows[3].Cells[0].Value = Image.FromFile("Destroier.png");
            ((Image)dataGridView1.Rows[3].Cells[0].Value).RotateFlip(RotateFlipType.Rotate270FlipNone);
            ((DataGridViewImageCell)dataGridView1.Rows[3].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Rows[3].Cells[1].Value = "Destroier";
            dataGridView1.Rows[3].Cells[2].Value = "2";

            dataGridView1.Rows[4].Cells[0].Value = Image.FromFile("Submarino.png");
            ((Image)dataGridView1.Rows[4].Cells[0].Value).RotateFlip(RotateFlipType.Rotate270FlipNone);
            ((DataGridViewImageCell)dataGridView1.Rows[4].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Rows[4].Cells[1].Value = "Submarino";
            dataGridView1.Rows[4].Cells[2].Value = "2";


            dataGridView2.RowCount = 3;
            dataGridView2.AllowUserToResizeRows = dataGridView1.AllowUserToResizeColumns = false;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView2.Rows[0].Cells[0].Value = Image.FromFile("xisverde.png");
            ((DataGridViewImageCell)dataGridView2.Rows[0].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView2.Rows[0].Cells[1].Value = "O tiro caiu na água";

            dataGridView2.Rows[1].Cells[0].Value = Image.FromFile("xisvermelho.png");
            ((DataGridViewImageCell)dataGridView2.Rows[1].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView2.Rows[1].Cells[1].Value = "O tiro acertou um barco, mas não afundou-o";

            dataGridView2.Rows[2].Cells[0].Value = Image.FromFile("xispreto.png");
            ((DataGridViewImageCell)dataGridView2.Rows[2].Cells[0]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView2.Rows[2].Cells[1].Value = "O tiro afundou um barco";
        }
    }
}
