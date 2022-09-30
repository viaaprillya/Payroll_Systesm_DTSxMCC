using API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace API.ViewModels
{
    public class InputCuti
    {
        public int KaryawanID { get; set; }
        public int JumlahHari { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; }
    }
}
