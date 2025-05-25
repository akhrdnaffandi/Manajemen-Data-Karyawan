using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Manajemen_Data_Karyawan.Model
{
    public class KaryawanModel
    {
        private MySqlConnection conn;

        public KaryawanModel()
        {
            conn = new MySqlConnection("server=localhost;user=root;password=;database=karyawan_db;");
        }

        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM karyawan";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            return dt;
        }

        public void SimpanData(Karyawan karyawan)
        {
            string query = @"INSERT INTO karyawan (Nama, Jabatan, Gaji, TanggalBergabung, Status, Telepon, Alamat, Email) 
                             VALUES (@Nama, @Jabatan, @Gaji, @TanggalBergabung, @Status, @Telepon, @Alamat, @Email)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nama", karyawan.Nama);
            cmd.Parameters.AddWithValue("@Jabatan", karyawan.Jabatan);
            cmd.Parameters.AddWithValue("@Gaji", karyawan.Gaji);
            cmd.Parameters.AddWithValue("@TanggalBergabung", karyawan.TanggalBergabung);
            cmd.Parameters.AddWithValue("@Status", karyawan.Status);
            cmd.Parameters.AddWithValue("@Telepon", karyawan.Telepon);
            cmd.Parameters.AddWithValue("@Alamat", karyawan.Alamat);
            cmd.Parameters.AddWithValue("@Email", karyawan.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Edit(Karyawan karyawan)
        {
            string query = @"UPDATE karyawan SET Nama=@Nama, Jabatan=@Jabatan, Gaji=@Gaji, TanggalBergabung=@TanggalBergabung,
                             Status=@Status, Telepon=@Telepon, Alamat=@Alamat, Email=@Email WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", karyawan.ID);
            cmd.Parameters.AddWithValue("@Nama", karyawan.Nama);
            cmd.Parameters.AddWithValue("@Jabatan", karyawan.Jabatan);
            cmd.Parameters.AddWithValue("@Gaji", karyawan.Gaji);
            cmd.Parameters.AddWithValue("@TanggalBergabung", karyawan.TanggalBergabung);
            cmd.Parameters.AddWithValue("@Status", karyawan.Status);
            cmd.Parameters.AddWithValue("@Telepon", karyawan.Telepon);
            cmd.Parameters.AddWithValue("@Alamat", karyawan.Alamat);
            cmd.Parameters.AddWithValue("@Email", karyawan.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Hapus(int id)
        {
            string query = "DELETE FROM karyawan WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable CariData(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM karyawan WHERE Nama LIKE @keyword OR Jabatan LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
    }
}