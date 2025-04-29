using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Manajemen_Data_Karyawan
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;user id=root;password=;database=karyawan_db;";

        public Form1()
        {
            InitializeComponent();
            LoadData();
            dataGridViewKaryawan.CellClick += dataGridViewKaryawan_CellClick;
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Karyawan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewKaryawan.DataSource = dt;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Karyawan (Nama, Jabatan, Gaji, TanggalBergabung, Status, Telepon, Alamat, Email) VALUES (@Nama, @Jabatan, @Gaji, @TanggalBergabung, @Status, @Telepon, @Alamat, @Email)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
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
            MessageBox.Show("Data berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["ID"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Karyawan SET Nama=@Nama, Jabatan=@Jabatan, Gaji=@Gaji, TanggalBergabung=@TanggalBergabung, Status=@Status, Telepon=@Telepon, Alamat=@Alamat, Email=@Email WHERE ID=@ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
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
                MessageBox.Show("Data berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["ID"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Karyawan WHERE ID=@ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
                MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCari_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Karyawan WHERE Nama LIKE @Nama";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nama", "%" + textCari.Text + "%");
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewKaryawan.DataSource = dt;
                }
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
