using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace P9_714240032.controller
{
    class CekLogin
    {
        Koneksi koneksi = new Koneksi();

        public bool cek_login(string username, string password)
        {
            MySqlDataReader dr = null;
            try
            {
                koneksi.OpenConnection();

                string query = "SELECT 1 FROM t_user WHERE username=@username AND password=@password LIMIT 1";

                MySqlParameter[] param = new MySqlParameter[]
                {
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@password", password)
                };

                dr = koneksi.reader(query, param);

                // Kalau ada baris, berarti login valid
                return dr.Read();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    e.Message,
                    "Gagal Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
            finally
            {
                // Pastikan reader dan koneksi selalu ditutup (menghindari error DataReader masih terbuka)
                if (dr != null && !dr.IsClosed)
                    dr.Close();

                koneksi.CloseConnection();
            }
        }
    }
}
