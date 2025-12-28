using MySql.Data.MySqlClient;
using System.Data;

namespace P9_714240032
{
    internal class Koneksi
    {
        private MySqlConnection kon;
        private string connectionString =
            "Server=localhost;Database=pemrog2ulbi;Uid=root;Pwd=;";

        // ================= OPEN =================
        public void OpenConnection()
        {
            if (kon == null)
                kon = new MySqlConnection(connectionString);

            if (kon.State != ConnectionState.Open)
                kon.Open();
        }

        // ================= CLOSE =================
        public void CloseConnection()
        {
            if (kon != null && kon.State == ConnectionState.Open)
                kon.Close();
        }

        // ================= SHOW DATA =================
        public DataTable ShowData(string query)
        {
            OpenConnection();

            MySqlDataAdapter da = new MySqlDataAdapter(query, kon);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CloseConnection();
            return dt;
        }

        // ================= SHOW DATA PARAM =================
        public DataTable ShowDataParam(string query, params MySqlParameter[] param)
        {
            OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, kon);
            foreach (var p in param)
                cmd.Parameters.Add(p);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CloseConnection();
            return dt;
        }

        // ================= EXECUTE QUERY =================
        public void ExecuteQuery(MySqlCommand cmd)
        {
            OpenConnection();
            cmd.Connection = kon;
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        // ================= READER (UNTUK FORM LAMA) =================
        public MySqlDataReader reader(string query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, kon);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
