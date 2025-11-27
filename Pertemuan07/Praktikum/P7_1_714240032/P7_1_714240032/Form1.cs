using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P7_1_714240032
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size = new Size(333,254);
        }

    private void buttonTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textBoxNama.Text))
            {
                errorMessage.AppendLine("Nama harus diisi!");
            }

            if (comboBoxAngkatan.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Angkatan harus diisi!");
            }

            if (string.IsNullOrWhiteSpace(textBoxKelas.Text))
            {
                errorMessage.AppendLine("Kelas harus diisi!");
            }

            string errorString = errorMessage.ToString();

            if (string.IsNullOrEmpty(errorString))
            {
                MessageBox.Show(
                    "Lengkap",
                    "Informasi Data Submit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information );
                    Size = new Size(333, 511);
            }
            else
            {
                MessageBox.Show(
                    errorString.Trim(),
                    "Informasi Data Submit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void radioButtonWeekday_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeekday.Checked)
            {
                checkBoxKuliah.Enabled = true;
                checkBoxKuliah.Checked = false;

                checkBoxTidur.Enabled = true;
                checkBoxTidur.Checked = false;

                checkBoxLiburan.Enabled = false;
                checkBoxLiburan.Checked = false;
            }
        }

        private void radioButtonWeekend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeekend.Checked)
            {
                checkBoxKuliah.Enabled = false;
                checkBoxKuliah.Checked = false;

                checkBoxTidur.Enabled = true;
                checkBoxTidur.Checked = false;

                checkBoxLiburan.Enabled = true;
                checkBoxLiburan.Checked = false;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // Menggunakan LINQ

            string hari = Controls.OfType<RadioButton>()
                                  .FirstOrDefault(rb => rb.Checked)?
                                  .Text;   // FirstOrDefault mengembalikan null jika tidak ada yang terpilih

            string kegiatan = string.Join(", ",
                                 Controls.OfType<CheckBox>()
                                         .Where(cb => cb.Checked)    // Hanya checkbox yang dipilih
                                         .Select(cb => cb.Text)       // Ambil teksnya
                             );

            // Menampilkan pesan
            MessageBox.Show(
                "Nama : " + textBoxNama.Text + "\n" +
                "Angkatan : " + comboBoxAngkatan.Text + "\n" +
                "Kelas : " + textBoxKelas.Text + "\n\n" +
                "Hari : " + hari + "\n" +
                "Kegiatan : " + kegiatan,
                "Informasi Data Submit",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }

}
