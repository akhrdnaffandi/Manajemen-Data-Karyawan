using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Manajemen_Data_Karyawan
{
    public partial class Login : Form
    {
        private string dbPath = "karyawan.db";
        private string connStr => $"Data Source={dbPath};Version=3;";

        public Login()
        {
            InitializeComponent();
            InitDatabase();
        }

        // Buat database dan tabel jika belum ada
        private void InitDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS users (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT NOT NULL UNIQUE,
                        password TEXT NOT NULL
                    );";
                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                
                string checkUserQuery = "SELECT COUNT(*) FROM users;";
                using (SQLiteCommand cmd = new SQLiteCommand(checkUserQuery, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertDefaultUser = "INSERT INTO users (username, password) VALUES ('admin', 'admin123');";
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertDefaultUser, conn))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textuser.Text.Trim();
            string password = textpass.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Silakan masukkan username dan password.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password;";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // Menyembunyikan form dashboard (bisa juga this.Close(); jika ingin menutup)
            dashboard dashboardForm = new dashboard(); // Membuat instance form Login
            dashboardForm.Show();
        }
    }
}
