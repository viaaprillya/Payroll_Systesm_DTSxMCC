using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Cuti
    {
        [Key]
        public int ID { get; set; }
        public Karyawan Karyawan { get; set; }
        [ForeignKey("Karyawan")]
        public int KaryawanID { get; set; }
        public int JumlahHari { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; }
    }
}
