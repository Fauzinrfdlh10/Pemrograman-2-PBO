using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;
using P9_714240032.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace P9_714240032.controller
{
    internal class Mahasiswa
    {
        //Memanggil class Koneksi dan membuat objek baru
        Koneksi koneksi = new Koneksi();

        //Method insert
        public bool Insert(M_mahasiswa mahasiswa)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                var cmd = new MySqlCommand(
                "INSERT INTO t_mahasiswa (npm, nama, angkatan, alamat, email, nohp) " +
                "VALUES (@npm, @nama, @angkatan, @alamat, @email, @nohp)"
                );
                cmd.Parameters.AddWithValue("@npm", mahasiswa.Npm);
                cmd.Parameters.AddWithValue("@nama", mahasiswa.Nama);
                cmd.Parameters.AddWithValue("@angkatan", mahasiswa.Angkatan);
                cmd.Parameters.AddWithValue("@alamat", mahasiswa.Alamat);
                cmd.Parameters.AddWithValue("@email", mahasiswa.Email);
                cmd.Parameters.AddWithValue("@nohp", mahasiswa.No_hp);
                koneksi.ExecuteQuery(cmd);
                status = true;
                MessageBox.Show("Data berhasil ditambahkan", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Insert",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        public bool Update(M_mahasiswa mahasiswa, string npm_mhs)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                var cmd = new MySqlCommand(
                "UPDATE t_mahasiswa SET nama=@nama, angkatan=@angkatan, alamat=@alamat, email = @email, nohp = @nohp " +
                "WHERE npm=@npm"
                );
                cmd.Parameters.AddWithValue("@npm", npm_mhs);
                cmd.Parameters.AddWithValue("@nama", mahasiswa.Nama);
                cmd.Parameters.AddWithValue("@angkatan", mahasiswa.Angkatan);
                cmd.Parameters.AddWithValue("@alamat", mahasiswa.Alamat);
                cmd.Parameters.AddWithValue("@email", mahasiswa.Email);
                cmd.Parameters.AddWithValue("@nohp", mahasiswa.No_hp);
                koneksi.ExecuteQuery(cmd);
                status = true;
                MessageBox.Show("Data berhasil diubah", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        //Method Delete
        public bool Delete(string npm_mhs)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                var cmd = new MySqlCommand("DELETE FROM t_mahasiswa WHERE npm = @npm");
                cmd.Parameters.AddWithValue("@npm", npm_mhs);
                koneksi.ExecuteQuery(cmd);
                status = true;
                MessageBox.Show("Data berhasil dihapus", "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Hapus",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }
    }
}
