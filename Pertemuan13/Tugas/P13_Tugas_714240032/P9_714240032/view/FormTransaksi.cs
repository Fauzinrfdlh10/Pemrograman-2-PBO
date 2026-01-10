using MySql.Data.MySqlClient;
using P9_714240032.Lib;
using System;
using System.IO;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace P9_714240032.view
{
    public partial class FormTransaksi : Form
    {
        int idTransaksi = 0;
        int qtyLama = 0;   // ⬅️ TAMBAHKAN INI (WAJIB)

        public FormTransaksi()
        {
            InitializeComponent();
            this.Load += FormTransaksi_Load;
        }

        // ================= LOAD =================
        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            LoadBarang();
            LoadTransaksi();
        }

        // ================= LOAD BARANG =================
        void LoadBarang()
        {
            Koneksi k = new Koneksi();
            cbIdBarang.DataSource = k.ShowData(
                "SELECT id_barang FROM t_barang ORDER BY id_barang"
            );
            cbIdBarang.DisplayMember = "id_barang";
            cbIdBarang.ValueMember = "id_barang";
            cbIdBarang.SelectedIndex = -1; // penting agar kosong saat refresh
        }

        // ================= LOAD TRANSAKSI =================
        void LoadTransaksi()
        {
            Koneksi k = new Koneksi();
            dgvTransaksi.DataSource = k.ShowData(@"
                SELECT 
                    t.id_transaksi AS ID,
                    t.id_barang AS 'ID Barang',
                    b.nama_barang AS 'Nama Barang',
                    b.harga AS Harga,
                    t.qty AS QTY,
                    t.total AS 'Total Harga'
                FROM t_transaksi t
                JOIN t_barang b ON t.id_barang = b.id_barang
            ");

            dgvTransaksi.Columns["Harga"].DefaultCellStyle.Format = "C0";
            dgvTransaksi.Columns["Harga"].DefaultCellStyle.FormatProvider =
                new CultureInfo("id-ID");

            dgvTransaksi.Columns["Total Harga"].DefaultCellStyle.Format = "C0";
            dgvTransaksi.Columns["Total Harga"].DefaultCellStyle.FormatProvider =
                new CultureInfo("id-ID");
        }

        // ================= PILIH BARANG =================
        private void cbIdBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex == -1) return;

            Koneksi k = new Koneksi();
            DataTable dt = k.ShowDataParam(
                "SELECT nama_barang, harga FROM t_barang WHERE id_barang=@id",
                new MySqlParameter("@id", cbIdBarang.SelectedValue)
            );

            if (dt.Rows.Count > 0)
            {
                txtNamaBarang.Text = dt.Rows[0]["nama_barang"].ToString();
                int harga = Convert.ToInt32(dt.Rows[0]["harga"]);
                txtHarga.Text = $"Rp{harga:N0}";
            }
        }

        // ================= HITUNG TOTAL =================
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == "" || txtHarga.Text == "") return;

            int qty = Convert.ToInt32(txtQty.Text);
            int harga = int.Parse(txtHarga.Text.Replace("Rp", "").Replace(".", ""));

            txtTotal.Text = $"Rp{(harga * qty):N0}";
        }


        // ================= SIMPAN =================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex == -1 || txtQty.Text == "")
            {
                MessageBox.Show("Lengkapi data transaksi");
                return;
            }

            Koneksi k = new Koneksi();

            // CEK ID BARANG SUDAH ADA
            DataTable cek = k.ShowDataParam(
                "SELECT id_transaksi FROM t_transaksi WHERE id_barang=@id",
                new MySqlParameter("@id", cbIdBarang.SelectedValue)
            );

            if (cek.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Barang ini sudah pernah ditransaksikan.\nSilakan gunakan tombol Ubah.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int qty = Convert.ToInt32(txtQty.Text);
            int harga = int.Parse(txtHarga.Text.Replace("Rp", "").Replace(".", ""));
            int total = harga * qty;

            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO t_transaksi (id_barang, qty, total) VALUES (@id,@qty,@total)"
            );
            cmd.Parameters.AddWithValue("@id", cbIdBarang.SelectedValue);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@total", total);

            k.ExecuteQuery(cmd);

            LoadTransaksi();
            ClearInput();
            MessageBox.Show("Transaksi berhasil disimpan");
        }

        // ================= KLIK TABEL =================
        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTransaksi.Rows[e.RowIndex];

            idTransaksi = Convert.ToInt32(row.Cells["ID"].Value);

            cbIdBarang.SelectedValue = row.Cells["ID Barang"].Value;
            txtNamaBarang.Text = row.Cells["Nama Barang"].Value.ToString();
            txtHarga.Text = row.Cells["Harga"].Value.ToString();

            qtyLama = Convert.ToInt32(row.Cells["QTY"].Value); // ⬅️ SIMPAN
            txtQty.Text = qtyLama.ToString();

            txtTotal.Text = row.Cells["Total Harga"].Value.ToString();
        }



        // ================= UBAH =================
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idTransaksi == 0)
            {
                MessageBox.Show("Pilih data transaksi terlebih dahulu");
                return;
            }

            if (txtQty.Text.Trim() == "")
            {
                MessageBox.Show("Quantity tidak boleh kosong");
                return;
            }

            int qtyBaru = Convert.ToInt32(txtQty.Text);

            // 🔴 VALIDASI UTAMA (INI YANG KAMU MAU)
            if (qtyBaru == qtyLama)
            {
                MessageBox.Show(
                    "Quantity belum diubah.\nSilakan ubah quantity terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int harga = int.Parse(
                txtHarga.Text.Replace("Rp", "").Replace(".", "")
            );

            int total = harga * qtyBaru;

            MySqlCommand cmd = new MySqlCommand(
                "UPDATE t_transaksi SET qty=@qty, total=@total WHERE id_transaksi=@id"
            );

            cmd.Parameters.AddWithValue("@qty", qtyBaru);
            cmd.Parameters.AddWithValue("@total", total);
            cmd.Parameters.AddWithValue("@id", idTransaksi);

            Koneksi k = new Koneksi();
            k.ExecuteQuery(cmd);

            LoadTransaksi();
            ClearInput();

            MessageBox.Show("Data berhasil diubah");
        }



        // ================= HAPUS =================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idTransaksi == 0)
            {
                MessageBox.Show("Pilih data transaksi yang akan dihapus");
                return;
            }

            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM t_transaksi WHERE id_transaksi=@id"
            );
            cmd.Parameters.AddWithValue("@id", idTransaksi);

            Koneksi k = new Koneksi();
            k.ExecuteQuery(cmd);

            LoadTransaksi();
            ClearInput();
            MessageBox.Show("Transaksi berhasil dihapus");
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBarang();
            LoadTransaksi();
            ClearInput();
        }

        // ================= CLEAR =================
        void ClearInput()
        {
            cbIdBarang.SelectedIndex = -1;
            txtNamaBarang.Text = "";
            txtHarga.Text = "";
            txtQty.Text = "";
            txtTotal.Text = "";
            idTransaksi = 0;
            qtyLama = 0;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel (*.xlsx)|*.xlsx";
            save.FileName = "Report Transaksi Barang.xlsx";
            save.OverwritePrompt = false;

            if (save.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(save.FileName))
                    File.Delete(save.FileName);

                Excel ex = new Excel();
                ex.ExportToExcel(dgvTransaksi, save.FileName);
                MessageBox.Show("Data berhasil diexport ke Excel");
            }
        }
    }
}
