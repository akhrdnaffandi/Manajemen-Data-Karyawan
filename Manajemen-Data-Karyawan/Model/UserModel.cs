using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Manajemen_Data_Karyawan.Model
{
    public class UserModel
    {
        private MySqlConnection conn;

        public UserModel()
        {
            conn = new MySqlConnection("server=localhost;user=root;password=;database=karyawan_db;");
        }

        public bool CekLogin(string username, string password)
        {
            string query = "SELECT * FROM users WHERE username=@username AND password=@password";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return count > 0;
        }
    }
}