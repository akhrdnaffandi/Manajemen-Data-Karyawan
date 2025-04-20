using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manajemen_Data_Karyawan
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Menyembunyikan form dashboard (bisa juga this.Close(); jika ingin menutup)
            Login loginForm = new Login(); // Membuat instance form Login
            loginForm.Show();
        }
    }
}
