using API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace API.ViewModels
{
    public class InputBonus
    {
        public int KaryawanID { get; set; }
        public int Jumlah { get; set; }
        public DateTime Tanggal { get; set; }
        public string Keterangan { get; set; }
    }
}
