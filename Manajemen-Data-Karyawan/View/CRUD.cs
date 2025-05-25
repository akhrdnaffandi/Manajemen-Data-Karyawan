using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Manajemen_Data_Karyawan
{
    public class CRUD
    {
        public bool Login(string username, string password)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Karyawan", conn);
                da.Fill(dt);
            }
            return dt;
        }

        public void SimpanData(string nama, string jabatan, string gaji, string tanggalBergabung, string status, string telepon, string alamat, string email)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Karyawan (Nama, Jabatan, Gaji, TanggalBergabung, Status, Telepon, Alamat, Email) VALUES (@Nama, @Jabatan, @Gaji, @TanggalBergabung, @Status, @Telepon, @Alamat, @Email)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@Jabatan", jabatan);
                    cmd.Parameters.AddWithValue("@Gaji", gaji);
                    cmd.Parameters.AddWithValue("@TanggalBergabung", tanggalBergabung);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Telepon", telepon);
                    cmd.Parameters.AddWithValue("@Alamat", alamat);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Edit(int id, string nama, string jabatan, string gaji, string tanggalBergabung, string status, string telepon, string alamat, string email)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Karyawan SET Nama=@Nama, Jabatan=@Jabatan, Gaji=@Gaji, TanggalBergabung=@TanggalBergabung, Status=@Status, Telepon=@Telepon, Alamat=@Alamat, Email=@Email WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nama", nama);
                    cmd.Parameters.AddWithValue("@Jabatan", jabatan);
                    cmd.Parameters.AddWithValue("@Gaji", gaji);
                    cmd.Parameters.AddWithValue("@TanggalBergabung", tanggalBergabung);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Telepon", telepon);
                    cmd.Parameters.AddWithValue("@Alamat", alamat);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Hapus(int id)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Karyawan WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable CariData(string nama)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Karyawan WHERE Nama LIKE @Nama";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", "%" + nama + "%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}