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

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {

        }


        private void btnBersih_Click(object sender, EventArgs e)
        {

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
