namespace P9_714240032.view
{
    partial class FormBarang
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
            this.dgvBarang = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHargaTemp = new System.Windows.Forms.TextBox();
            this.txtNama1 = new System.Windows.Forms.TextBox();
            this.txtHarga = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCari = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBarang
            // 
            this.dgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarang.Location = new System.Drawing.Point(12, 22);
            this.dgvBarang.Name = "dgvBarang";
            this.dgvBarang.ReadOnly = true;
            this.dgvBarang.Size = new System.Drawing.Size(776, 222);
            this.dgvBarang.TabIndex = 0;
            this.dgvBarang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarang_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHargaTemp);
            this.groupBox1.Controls.Add(this.txtNama1);
            this.groupBox1.Controls.Add(this.txtHarga);
            this.groupBox1.Controls.Add(this.txtNama);
            this.groupBox1.Location = new System.Drawing.Point(13, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Form Input Barang";
            // 
            // txtHargaTemp
            // 
            this.txtHargaTemp.Location = new System.Drawing.Point(95, 50);
            this.txtHargaTemp.Name = "txtHargaTemp";
            this.txtHargaTemp.Size = new System.Drawing.Size(300, 20);
            this.txtHargaTemp.TabIndex = 3;
            this.txtHargaTemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHarga_KeyPress);
            // 
            // txtNama1
            // 
            this.txtNama1.Location = new System.Drawing.Point(95, 19);
            this.txtNama1.Name = "txtNama1";
            this.txtNama1.Size = new System.Drawing.Size(300, 20);
            this.txtNama1.TabIndex = 2;
            // 
            // txtHarga
            // 
            this.txtHarga.AutoSize = true;
            this.txtHarga.Location = new System.Drawing.Point(6, 50);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(36, 13);
            this.txtHarga.TabIndex = 1;
            this.txtHarga.Text = "Harga";
            // 
            // txtNama
            // 
            this.txtNama.AutoSize = true;
            this.txtNama.Location = new System.Drawing.Point(6, 25);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(72, 13);
            this.txtNama.TabIndex = 0;
            this.txtNama.Text = "Nama Barang";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.txtCari);
            this.groupBox2.Location = new System.Drawing.Point(13, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Form Pencarian";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(95, 27);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(300, 20);
            this.textBox3.TabIndex = 1;
            // 
            // txtCari
            // 
            this.txtCari.AutoSize = true;
            this.txtCari.Location = new System.Drawing.Point(6, 27);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(51, 13);
            this.txtCari.TabIndex = 0;
            this.txtCari.Text = "Cari Data";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.btnUbah);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(500, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 142);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tombol Action";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(20, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(252, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Hapus";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(20, 80);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(252, 23);
            this.btnUbah.TabIndex = 2;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Simpan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBarang);
            this.Name = "FormBarang";
            this.Text = "FormBarang";
            this.Load += new System.EventHandler(this.FormBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBarang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHargaTemp;
        private System.Windows.Forms.TextBox txtNama1;
        private System.Windows.Forms.Label txtHarga;
        private System.Windows.Forms.Label txtNama;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label txtCari;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}