using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Manajemen_Data_Karyawan
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=karyawan.db;Version=3;";

        public Form1()
        {
            InitializeComponent();
            CreateDatabase();
            LoadData();
            dataGridViewKaryawan.CellClick += dataGridViewKaryawan_CellClick;
        }

        private void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "CREATE TABLE IF NOT EXISTS Karyawan (ID INTEGER PRIMARY KEY AUTOINCREMENT, Nama TEXT, Jabatan TEXT, Gaji REAL, TanggalBergabung TEXT, Status TEXT, Telepon TEXT, Alamat TEXT, Email TEXT)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Karyawan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewKaryawan.DataSource = dt;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Karyawan (Nama, Jabatan, Gaji, TanggalBergabung, Status, Telepon, Alamat, Email) VALUES (@Nama, @Jabatan, @Gaji, @TanggalBergabung, @Status, @Telepon, @Alamat, @Email)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", textNama.Text);
                    cmd.Parameters.AddWithValue("@Jabatan", comboBoxJabatan.Text);
                    cmd.Parameters.AddWithValue("@Gaji", textGaji.Text);
                    cmd.Parameters.AddWithValue("@TanggalBergabung", dateTimeBergabung.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Status", comboBoxStatus.Text);
                    cmd.Parameters.AddWithValue("@Telepon", textTelepon.Text);
                    cmd.Parameters.AddWithValue("@Alamat", textAlamat.Text);
                    cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["ID"].Value);
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Karyawan SET Nama=@Nama, Jabatan=@Jabatan, Gaji=@Gaji, TanggalBergabung=@TanggalBergabung, Status=@Status, Telepon=@Telepon, Alamat=@Alamat, Email=@Email WHERE ID=@ID";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Nama", textNama.Text);
                        cmd.Parameters.AddWithValue("@Jabatan", comboBoxJabatan.Text);
                        cmd.Parameters.AddWithValue("@Gaji", textGaji.Text);
                        cmd.Parameters.AddWithValue("@TanggalBergabung", dateTimeBergabung.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Status", comboBoxStatus.Text);
                        cmd.Parameters.AddWithValue("@Telepon", textTelepon.Text);
                        cmd.Parameters.AddWithValue("@Alamat", textAlamat.Text);
                        cmd.Parameters.AddWithValue("@Email", textEmail.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["ID"].Value);
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Hapus data berdasarkan ID yang dipilih
                    string query = "DELETE FROM Karyawan WHERE ID=@ID";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Periksa apakah tabel kosong, lalu reset AUTOINCREMENT jika kosong
                    string checkQuery = "SELECT COUNT(*) FROM Karyawan";
                    using (SQLiteCommand cmd = new SQLiteCommand(checkQuery, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            string resetQuery = "DELETE FROM sqlite_sequence WHERE name='Karyawan'";
                            using (SQLiteCommand resetCmd = new SQLiteCommand(resetQuery, conn))
                            {
                                resetCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                LoadData();
            }
        }


        private void btnBersih_Click(object sender, EventArgs e)
        {
            textNama.Clear();
            comboBoxJabatan.SelectedIndex = -1;
            textGaji.Clear();
            dateTimeBergabung.Value = DateTime.Now;
            comboBoxStatus.SelectedIndex = -1;
            textTelepon.Clear();
            textAlamat.Clear();
            textEmail.Clear();
        }

        private void dataGridViewKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewKaryawan.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                DataGridViewRow row = dataGridViewKaryawan.Rows[e.RowIndex];
                textNama.Text = row.Cells["Nama"].Value?.ToString() ?? "";
                comboBoxJabatan.Text = row.Cells["Jabatan"].Value?.ToString() ?? "";
                textGaji.Text = row.Cells["Gaji"].Value?.ToString() ?? "";
                dateTimeBergabung.Value = DateTime.TryParse(row.Cells["TanggalBergabung"].Value?.ToString(), out DateTime date) ? date : DateTime.Now;
                comboBoxStatus.Text = row.Cells["Status"].Value?.ToString() ?? "";
                textTelepon.Text = row.Cells["Telepon"].Value?.ToString() ?? "";
                textAlamat.Text = row.Cells["Alamat"].Value?.ToString() ?? "";
                textEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            }
        }
    }
}
