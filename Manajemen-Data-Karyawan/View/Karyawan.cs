using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manajemen_Data_Karyawan.Model
{
    public class Karyawan
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Jabatan { get; set; }
        public string Gaji { get; set; }
        public string TanggalBergabung { get; set; }
        public string Status { get; set; }
        public string Telepon { get; set; }
        public string Alamat { get; set; }
        public string Email { get; set; }
    }
}