using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace P9_714240032
{
    internal class Koneksi
    {
        string connectionstring = "Server=localhost;Database=pemrog2ulbi;Uid=root;Pwd=;";
        MySqlConnection kon;

        public void OpenConnection()
        {
            kon = new MySqlConnection(connectionstring);
            kon.Open();
        }

        public void CloseConnection()
        {
            kon.Close();
        }

        public object ShowData(string query)
        {
            try
            {
                OpenConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, kon);
                DataTable table = new DataTable();
                adapter.Fill(table);
                CloseConnection();
                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}