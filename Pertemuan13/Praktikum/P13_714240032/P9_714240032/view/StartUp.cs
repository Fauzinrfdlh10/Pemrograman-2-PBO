using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240032.view
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Menambah nilai ProgressBar sebesar 5 setiap Tick,
            // ProgressBar berfungsi sebagai indikator proses loading
            progressBar1.Value += 5;

            // Mengecek apakah ProgressBar sudah mencapai nilai maksimum (100)
            if (progressBar1.Value == 100)
            {
                // Menghentikan dan membersihkan Timer agar tidak berjalan lagi
                timer1.Dispose();

                // Menutup Form StartUp (Splash Screen)
                Close();
            }
        }
    }
}
