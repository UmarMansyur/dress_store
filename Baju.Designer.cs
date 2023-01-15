namespace WindowsFormsApplication9
{
    partial class Baju
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
            this.batal = new System.Windows.Forms.Button();
            this.tambah = new System.Windows.Forms.Button();
            this.harga = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.stok = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.jenis = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nama = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ubah = new System.Windows.Forms.Button();
            this.hapus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // batal
            // 
            this.batal.Location = new System.Drawing.Point(417, 146);
            this.batal.Name = "batal";
            this.batal.Size = new System.Drawing.Size(99, 27);
            this.batal.TabIndex = 34;
            this.batal.Text = "Batal";
            this.batal.UseVisualStyleBackColor = true;
            this.batal.Click += new System.EventHandler(this.batal_Click);
            // 
            // tambah
            // 
            this.tambah.Location = new System.Drawing.Point(301, 146);
            this.tambah.Name = "tambah";
            this.tambah.Size = new System.Drawing.Size(110, 27);
            this.tambah.TabIndex = 33;
            this.tambah.Text = "Tambah";
            this.tambah.UseVisualStyleBackColor = true;
            this.tambah.Click += new System.EventHandler(this.tambah_Click);
            // 
            // harga
            // 
            this.harga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.harga.Location = new System.Drawing.Point(320, 91);
            this.harga.Multiline = true;
            this.harga.Name = "harga";
            this.harga.Size = new System.Drawing.Size(196, 31);
            this.harga.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(252, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Harga:";
            // 
            // stok
            // 
            this.stok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stok.Location = new System.Drawing.Point(56, 91);
            this.stok.Multiline = true;
            this.stok.Name = "stok";
            this.stok.Size = new System.Drawing.Size(157, 31);
            this.stok.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Stok:";
            // 
            // jenis
            // 
            this.jenis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jenis.Location = new System.Drawing.Point(56, 52);
            this.jenis.Multiline = true;
            this.jenis.Name = "jenis";
            this.jenis.Size = new System.Drawing.Size(460, 31);
            this.jenis.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Jenis:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Nama:";
            // 
            // nama
            // 
            this.nama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nama.Location = new System.Drawing.Point(56, 12);
            this.nama.Multiline = true;
            this.nama.Name = "nama";
            this.nama.Size = new System.Drawing.Size(460, 31);
            this.nama.TabIndex = 25;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(497, 184);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ubah
            // 
            this.ubah.Location = new System.Drawing.Point(301, 179);
            this.ubah.Name = "ubah";
            this.ubah.Size = new System.Drawing.Size(110, 23);
            this.ubah.TabIndex = 36;
            this.ubah.Text = "Ubah";
            this.ubah.UseVisualStyleBackColor = true;
            this.ubah.Click += new System.EventHandler(this.ubah_Click);
            // 
            // hapus
            // 
            this.hapus.Location = new System.Drawing.Point(417, 179);
            this.hapus.Name = "hapus";
            this.hapus.Size = new System.Drawing.Size(99, 23);
            this.hapus.TabIndex = 37;
            this.hapus.Text = "Hapus";
            this.hapus.UseVisualStyleBackColor = true;
            this.hapus.Click += new System.EventHandler(this.hapus_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(19, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 37);
            this.panel1.TabIndex = 38;
            // 
            // Baju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hapus);
            this.Controls.Add(this.ubah);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.batal);
            this.Controls.Add(this.tambah);
            this.Controls.Add(this.harga);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.stok);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.jenis);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nama);
            this.Name = "Baju";
            this.Text = "Baju";
            this.Load += new System.EventHandler(this.Baju_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button batal;
        private System.Windows.Forms.Button tambah;
        private System.Windows.Forms.TextBox harga;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox stok;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox jenis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox nama;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ubah;
        private System.Windows.Forms.Button hapus;
        private System.Windows.Forms.Panel panel1;
    }
}