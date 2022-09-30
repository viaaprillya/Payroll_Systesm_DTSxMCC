using System;

namespace API.ViewModels
{
    public class PengajuanCuti
    {
        public int KaryawanID { get; set; }
        public DateTime Tanggal { get; set; }
        public int JumlahHari { get; set; }
        public string Keterangan { get; set; }
    }
}
