using System;
using System.Windows.Forms;
using Manajemen_Data_Karyawan.Controller;
using Manajemen_Data_Karyawan.Model;

namespace Manajemen_Data_Karyawan
{
    public partial class Form1 : Form
    {
        private KaryawanController controller;

        public Form1()
        {
            InitializeComponent();
            controller = new KaryawanController();
            LoadData();
            dataGridViewKaryawan.CellClick += dataGridViewKaryawan_CellClick;
        }

        private void LoadData()
        {
            dataGridViewKaryawan.DataSource = controller.GetAllKaryawan();
        }

        private Karyawan AmbilDataDariForm(int? id = null)
        {
            return new Karyawan
            {
                ID = id ?? 0,
                Nama = textNama.Text,
                Jabatan = comboBoxJabatan.Text,
                Gaji = textGaji.Text,
                TanggalBergabung = dateTimeBergabung.Value.ToString("yyyy-MM-dd"),
                Status = comboBoxStatus.Text,
                Telepon = textTelepon.Text,
                Alamat = textAlamat.Text,
                Email = textEmail.Text
            };
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var karyawan = AmbilDataDariForm();
            controller.TambahKaryawan(karyawan);
            LoadData();
            MessageBox.Show("Data berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["ID"].Value);
                var karyawan = AmbilDataDariForm(id);
                controller.UpdateKaryawan(karyawan);
                LoadData();
                MessageBox.Show("Data berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridViewKaryawan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewKaryawan.SelectedRows[0].Cells["ID"].Value);
                controller.DeleteKaryawan(id);
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
            dataGridViewKaryawan.DataSource = controller.CariKaryawan(textCari.Text);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
        }
    }
}
