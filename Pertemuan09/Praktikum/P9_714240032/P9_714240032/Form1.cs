using System;
using System.Windows.Forms;

namespace P9_714240032
{
    public partial class Form1 : Form
    {
        Koneksi koneksi = new Koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        public void Tampil()
        {
            DataMahasiswa.DataSource = koneksi.ShowData("SELECT * FROM t_mahasiswa");

            // Mengubah Nama Kolom Tabel
            DataMahasiswa.Columns[0].HeaderText = "NPM";
            DataMahasiswa.Columns[1].HeaderText = "Nama";
            DataMahasiswa.Columns[2].HeaderText = "Angkatan";
            DataMahasiswa.Columns[3].HeaderText = "Alamat";
            DataMahasiswa.Columns[4].HeaderText = "Email";
            DataMahasiswa.Columns[5].HeaderText = "No HP";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Tampil();
        }
    }
}
