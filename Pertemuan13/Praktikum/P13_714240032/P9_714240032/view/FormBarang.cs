using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace P9_714240032.view
{
    public partial class FormBarang : Form
    {
        int idBarang = 0;

        public FormBarang()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // ⬅️ PAKSA HUBUNGKAN EVENT UBAH
            btnUbah.Click += btnUbah_Click;
        }

        // ================= FORM LOAD =================
        private void FormBarang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // ================= LOAD DATA =================
        void LoadData()
        {
            Koneksi koneksi = new Koneksi();
            dgvBarang.AutoGenerateColumns = true;
            dgvBarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBarang.MultiSelect = false;

            dgvBarang.DataSource = koneksi.ShowData(
                "SELECT id_barang AS ID, nama_barang AS 'Nama Barang', harga AS Harga FROM t_barang"
            );

            dgvBarang.Columns["Harga"].DefaultCellStyle.Format = "C0";
            dgvBarang.Columns["Harga"].DefaultCellStyle.FormatProvider =
                new CultureInfo("id-ID");
        }

        // ================= SIMPAN =================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNama1.Text.Trim() == "" || txtHargaTemp.Text.Trim() == "")
            {
                MessageBox.Show("Nama dan Harga wajib diisi");
                return;
            }

            int harga = BersihkanHarga(txtHargaTemp.Text);

            string query = "INSERT INTO t_barang (nama_barang, harga) VALUES (@nama,@harga)";
            Koneksi koneksi = new Koneksi();
            koneksi.OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@nama", txtNama1.Text.Trim());
            cmd.Parameters.AddWithValue("@harga", harga);

            koneksi.ExecuteQuery(cmd);
            koneksi.CloseConnection();

            LoadData();
            ClearInput();
            MessageBox.Show("Data berhasil disimpan");
        }

        // ================= UBAH (FIX TOTAL) =================
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idBarang == 0)
            {
                MessageBox.Show("Pilih data pada tabel terlebih dahulu");
                return;
            }

            int harga = BersihkanHarga(txtHargaTemp.Text);

            string query = "UPDATE t_barang SET nama_barang=@nama, harga=@harga WHERE id_barang=@id";

            Koneksi koneksi = new Koneksi();
            koneksi.OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@nama", txtNama1.Text.Trim());
            cmd.Parameters.AddWithValue("@harga", harga);
            cmd.Parameters.AddWithValue("@id", idBarang);

            koneksi.ExecuteQuery(cmd); // ✅ WAJIB INI
            koneksi.CloseConnection();

            LoadData();
            ClearInput();
            MessageBox.Show("Data berhasil diubah");
        }


        // ================= HAPUS =================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idBarang == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            string query = "DELETE FROM t_barang WHERE id_barang=@id";

            Koneksi koneksi = new Koneksi();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id", idBarang);

            koneksi.ExecuteQuery(cmd);   // ✅ WAJIB PAKAI INI

            LoadData();
            ClearInput();
            MessageBox.Show("Data berhasil dihapus");
        }

        // ================= KLIK TABEL =================
        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBarang.CurrentRow != null)
            {
                idBarang = Convert.ToInt32(dgvBarang.CurrentRow.Cells["ID"].Value);
                txtNama1.Text = dgvBarang.CurrentRow.Cells["Nama Barang"].Value.ToString();

                int harga = Convert.ToInt32(dgvBarang.CurrentRow.Cells["Harga"].Value);
                txtHargaTemp.Text = $"Rp{harga:N0}";
            }
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInput();
        }

        // ================= CLEAR =================
        void ClearInput()
        {
            txtNama1.Text = "";
            txtHargaTemp.Text = "";
            idBarang = 0;
        }

        // ================= HELPER =================
        int BersihkanHarga(string text)
        {
            return int.Parse(
                text.Replace("Rp", "").Replace(".", "").Replace(" ", "")
            );
        }

        // ================= KEY PRESS =================
        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtHargaTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtHarga_KeyPress(sender, e);
        }
    }
}
