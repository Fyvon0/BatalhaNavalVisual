namespace BatalhaNavalVisual
{
    partial class Navios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbSubmarino = new System.Windows.Forms.PictureBox();
            this.pbDestroier = new System.Windows.Forms.PictureBox();
            this.pbCruzador = new System.Windows.Forms.PictureBox();
            this.pbEncouracado = new System.Windows.Forms.PictureBox();
            this.pbPortaAvioes = new System.Windows.Forms.PictureBox();
            this.rdbtnVertical = new System.Windows.Forms.RadioButton();
            this.rdbtnHorizontal = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmarino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDestroier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncouracado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortaAvioes)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pbSubmarino, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbDestroier, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbCruzador, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbEncouracado, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbPortaAvioes, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 209);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbSubmarino
            // 
            this.pbSubmarino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSubmarino.Location = new System.Drawing.Point(284, 4);
            this.pbSubmarino.Name = "pbSubmarino";
            this.pbSubmarino.Size = new System.Drawing.Size(66, 201);
            this.pbSubmarino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSubmarino.TabIndex = 4;
            this.pbSubmarino.TabStop = false;
            this.pbSubmarino.Tag = "Submarino";
            this.pbSubmarino.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbNavio_MouseDown);
            // 
            // pbDestroier
            // 
            this.pbDestroier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDestroier.Location = new System.Drawing.Point(214, 4);
            this.pbDestroier.Name = "pbDestroier";
            this.pbDestroier.Size = new System.Drawing.Size(63, 201);
            this.pbDestroier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDestroier.TabIndex = 3;
            this.pbDestroier.TabStop = false;
            this.pbDestroier.Tag = "Destroier";
            this.pbDestroier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbNavio_MouseDown);
            // 
            // pbCruzador
            // 
            this.pbCruzador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCruzador.Location = new System.Drawing.Point(144, 4);
            this.pbCruzador.Name = "pbCruzador";
            this.pbCruzador.Size = new System.Drawing.Size(63, 201);
            this.pbCruzador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCruzador.TabIndex = 2;
            this.pbCruzador.TabStop = false;
            this.pbCruzador.Tag = "Cruzador";
            this.pbCruzador.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbNavio_MouseDown);
            // 
            // pbEncouracado
            // 
            this.pbEncouracado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEncouracado.Location = new System.Drawing.Point(74, 4);
            this.pbEncouracado.Name = "pbEncouracado";
            this.pbEncouracado.Size = new System.Drawing.Size(63, 201);
            this.pbEncouracado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEncouracado.TabIndex = 1;
            this.pbEncouracado.TabStop = false;
            this.pbEncouracado.Tag = "Encouracado";
            this.pbEncouracado.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbNavio_MouseDown);
            // 
            // pbPortaAvioes
            // 
            this.pbPortaAvioes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPortaAvioes.Location = new System.Drawing.Point(4, 4);
            this.pbPortaAvioes.Name = "pbPortaAvioes";
            this.pbPortaAvioes.Size = new System.Drawing.Size(63, 201);
            this.pbPortaAvioes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPortaAvioes.TabIndex = 0;
            this.pbPortaAvioes.TabStop = false;
            this.pbPortaAvioes.Tag = "PortaAvioes";
            this.pbPortaAvioes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbNavio_MouseDown);
            // 
            // rdbtnVertical
            // 
            this.rdbtnVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbtnVertical.AutoSize = true;
            this.rdbtnVertical.Checked = true;
            this.rdbtnVertical.Location = new System.Drawing.Point(4, 215);
            this.rdbtnVertical.Name = "rdbtnVertical";
            this.rdbtnVertical.Size = new System.Drawing.Size(60, 17);
            this.rdbtnVertical.TabIndex = 1;
            this.rdbtnVertical.TabStop = true;
            this.rdbtnVertical.Text = "Vertical";
            this.rdbtnVertical.UseVisualStyleBackColor = true;
            // 
            // rdbtnHorizontal
            // 
            this.rdbtnHorizontal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbtnHorizontal.AutoSize = true;
            this.rdbtnHorizontal.Location = new System.Drawing.Point(70, 215);
            this.rdbtnHorizontal.Name = "rdbtnHorizontal";
            this.rdbtnHorizontal.Size = new System.Drawing.Size(72, 17);
            this.rdbtnHorizontal.TabIndex = 2;
            this.rdbtnHorizontal.TabStop = true;
            this.rdbtnHorizontal.Text = "Horizontal";
            this.rdbtnHorizontal.UseVisualStyleBackColor = true;
            // 
            // Navios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 237);
            this.Controls.Add(this.rdbtnHorizontal);
            this.Controls.Add(this.rdbtnVertical);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Navios";
            this.Text = "Navios";
            this.Load += new System.EventHandler(this.Navios_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmarino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDestroier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCruzador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncouracado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortaAvioes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbSubmarino;
        private System.Windows.Forms.PictureBox pbDestroier;
        private System.Windows.Forms.PictureBox pbCruzador;
        private System.Windows.Forms.PictureBox pbEncouracado;
        private System.Windows.Forms.PictureBox pbPortaAvioes;
        private System.Windows.Forms.RadioButton rdbtnVertical;
        private System.Windows.Forms.RadioButton rdbtnHorizontal;
    }
}