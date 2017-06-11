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
    public partial class Jogadores : Form
    {
        public void Adicionar (System.Net.IPAddress addr)
        {
            if (!cbUsuarios.Items.Contains(addr))
                cbUsuarios.Items.Add(addr);
        }

        public void Remover (System.Net.IPAddress addr)
        {
            cbUsuarios.Items.Remove(addr);
        }

        public Jogadores()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        { }
    }
}
