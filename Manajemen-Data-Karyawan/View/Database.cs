using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Manajemen_Data_Karyawan
{
    class Database
    {
        private static string koneksi = "server=localhost;user=root;password=;database=karyawan_db;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(koneksi);
            return conn;
        }
    }
}
