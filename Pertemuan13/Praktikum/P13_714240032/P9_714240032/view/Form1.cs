using MySql.Data.MySqlClient;
using P9_714240032.controller;
using P9_714240032.model;
using System;
using System.Windows.Forms;

namespace P9_714240032
{
    public partial class Form1 : Form
    {
        Koneksi koneksi = new Koneksi();
        M_mahasiswa m_mhs = new M_mahasiswa();

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

        public void ResetForm()
        {
            textboxNpm.Text = "";
            textboxNama.Text = "";
            comboBoxAngkatan.SelectedIndex = -1;
            textboxAlamat.Text = "";
            textboxEmail.Text = "";
            textboxNohp.Text = "";
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (textboxNpm.Text == "" || textboxNama.Text == "" || comboBoxAngkatan.SelectedIndex == -1 || textboxAlamat.Text == "" || textboxEmail.Text == "" || textboxNohp.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();

                m_mhs.Npm = textboxNpm.Text;
                m_mhs.Nama = textboxNama.Text;
                m_mhs.Angkatan = comboBoxAngkatan.Text;
                m_mhs.Alamat = textboxAlamat.Text;
                m_mhs.Email = textboxEmail.Text;
                m_mhs.No_hp = textboxNohp.Text;

                mhs.Insert(m_mhs);

                ResetForm();
                Tampil();
            }
        }

        private void DataMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textboxNpm.Text = DataMahasiswa.Rows[e.RowIndex].Cells[0].Value.ToString();
            textboxNama.Text = DataMahasiswa.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxAngkatan.Text = DataMahasiswa.Rows[e.RowIndex].Cells[2].Value.ToString();
            textboxAlamat.Text = DataMahasiswa.Rows[e.RowIndex].Cells[3].Value.ToString();
            textboxEmail.Text = DataMahasiswa.Rows[e.RowIndex].Cells[4].Value.ToString();
            textboxNohp.Text = DataMahasiswa.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (textboxNpm.Text == "" || textboxNama.Text == "" || comboBoxAngkatan.SelectedIndex == -1 || textboxAlamat.Text == "" || textboxEmail.Text == "" || textboxNohp.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();

                m_mhs.Npm = textboxNpm.Text;
                m_mhs.Nama = textboxNama.Text;
                m_mhs.Angkatan = comboBoxAngkatan.Text;
                m_mhs.Alamat = textboxAlamat.Text;
                m_mhs.Email = textboxEmail.Text;
                m_mhs.No_hp = textboxNohp.Text;

                mhs.Update(m_mhs,textboxNpm.Text);

                ResetForm();
                Tampil();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah Yakin ingin menghapus data ini?", "Perhatian",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(pesan == DialogResult.Yes)
            {
                Mahasiswa mhs = new Mahasiswa();
                mhs.Delete(textboxNpm.Text);
                ResetForm();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            Tampil();
        }

        private void TextBoxCariData_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM t_mahasiswa WHERE npm LIKE @param OR nama LIKE @param";
            DataMahasiswa.DataSource = koneksi.ShowDataParam(
            sql,
            new MySqlParameter("@param", "%" + textboxCariData.Text + "%")
            );
        }


    }
}
