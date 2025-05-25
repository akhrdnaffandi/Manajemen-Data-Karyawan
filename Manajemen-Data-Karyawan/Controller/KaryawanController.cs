using Manajemen_Data_Karyawan.Model;
using System.Data;

namespace Manajemen_Data_Karyawan.Controller
{
    public class KaryawanController
    {
        private KaryawanModel model;

        public KaryawanController()
        {
            model = new KaryawanModel();
        }

        public DataTable GetAllKaryawan()
        {
            return model.LoadData();
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            model.SimpanData(karyawan);
        }

        public void UpdateKaryawan(Karyawan karyawan)
        {
            model.Edit(karyawan);
        }

        public void DeleteKaryawan(int id)
        {
            model.Hapus(id);
        }

        public DataTable CariKaryawan(string keyword)
        {
            return model.CariData(keyword);
        }
    }
}