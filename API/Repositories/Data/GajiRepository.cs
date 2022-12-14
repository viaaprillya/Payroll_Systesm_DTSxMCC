using API.Context;
using API.Models;
using API.ViewModels;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;

namespace API.Repositories.Data
{
    public class GajiRepository
    {
        MyContext myContext;
        public GajiRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public SlipGaji CetakSlipGaji (CetakSlipGaji cetakSlipGaji)
        {
            SlipGaji slipGaji = new SlipGaji();
            var data = myContext.Gaji.FirstOrDefault(x =>
                    x.KaryawanID.Equals(cetakSlipGaji.KaryawanID)&& x.Bulan==cetakSlipGaji.Bulan && x.Tahun == cetakSlipGaji.Tahun);
            var karyawan = myContext.Karyawan.Find(cetakSlipGaji.KaryawanID);
            var bonuss = myContext.Bonus
                    .Include(x => x.Karyawan)
                    .Where(x =>
                    x.Karyawan.ID.Equals(cetakSlipGaji.KaryawanID) &&
                    x.Tanggal.Month == cetakSlipGaji.Bulan &&
                    x.Tanggal.Year == cetakSlipGaji.Tahun
                    )
                    .GroupBy(x => x.KaryawanID)
                    .Select(x => new { totalBonus = x.Sum(x => x.Jumlah) }).FirstOrDefault();
            var lemburs = myContext.Lembur
                    .Include(x => x.Karyawan)
                    .Where(x =>
                    x.Karyawan.ID.Equals(cetakSlipGaji.KaryawanID) &&
                    x.Tanggal.Month == cetakSlipGaji.Bulan &&
                    x.Tanggal.Year == cetakSlipGaji.Tahun
                    )
                    .GroupBy(x => x.KaryawanID)
                    .Select(x => new { totalLembur = x.Sum(x => x.JumlahJam) }).FirstOrDefault();
            var cutis = myContext.Cuti
                    .Include(x => x.Karyawan)
                    .Where(x =>
                    x.Karyawan.ID.Equals(cetakSlipGaji.KaryawanID) &&
                    x.Tanggal.Month == cetakSlipGaji.Bulan &&
                    x.Tanggal.Year == cetakSlipGaji.Tahun
                    )
                    .GroupBy(x => x.KaryawanID)
                    .Select(x => new { totalCuti = x.Sum(x => x.JumlahHari) }).FirstOrDefault();
            var potongans = myContext.Potongan
                    .Include(x => x.Karyawan)
                    .Where(x =>
                    x.Karyawan.ID.Equals(cetakSlipGaji.KaryawanID) && 
                    x.Tanggal.Month == cetakSlipGaji.Bulan && 
                    x.Tanggal.Year == cetakSlipGaji.Tahun 
                    )
                    .GroupBy(x => x.KaryawanID)
                    .Select(x => new { totalPotongan = x.Sum(x => x.Jumlah) }).FirstOrDefault();
            var cuti = 0;
            var potongan = 0;
            var lembur = 0;
            var bonus = 0;
            if (cutis != null)
            {
                cuti = cutis.totalCuti;
            }
            if (potongans != null)
            {
                potongan = potongans.totalPotongan;
            }
            if (lemburs != null)
            {
                lembur = lemburs.totalLembur;
            }
            if (bonuss != null)
            {
                bonus = bonuss.totalBonus;
            }
            var gaji = myContext.Jabatan.Find(karyawan.JabatanID).GajiPokok;
            var tunjangan = myContext.Jabatan.Find(karyawan.JabatanID).Tunjangan;
            double totalCuti = (double)cuti * (0.025 * (double)gaji);
            double totalLembur = (double)lembur* (0.005 * (double)gaji);

            if (data==null) {
                Post(cetakSlipGaji);
            }
            var slip = Get(cetakSlipGaji);
            slipGaji.KaryawanID = slip.KaryawanID;
            slipGaji.NamaKaryawan = karyawan.NamaLengkap;
            slipGaji.Tahun = slip.Tahun;
            slipGaji.Bulan = slip.Bulan;
            slipGaji.TotalPotongan = (double)potongan;
            slipGaji.TotalBonus = (double)bonus;
            slipGaji.TotalBonusLembur = totalLembur;
            slipGaji.TotalPotonganCuti = totalCuti;
            slipGaji.GajiPokok = gaji;
            slipGaji.Tunjangan = tunjangan;
            double totalGaji = gaji + tunjangan - potongan + bonus - totalCuti + totalLembur;
            slipGaji.TotalGaji = totalGaji;
            return slipGaji;
        }

        public Gaji Get(CetakSlipGaji cetakSlipGaji)
        {
            var data = myContext.Gaji.FirstOrDefault(x =>
                    x.KaryawanID.Equals(cetakSlipGaji.KaryawanID) && x.Bulan == cetakSlipGaji.Bulan && x.Tahun == cetakSlipGaji.Tahun);
            return data;

        }


        public int Post(CetakSlipGaji cetakSlipGaji)
        {
            Gaji gaji = new Gaji();
            gaji.KaryawanID = cetakSlipGaji.KaryawanID;
            gaji.Bulan = cetakSlipGaji.Bulan;
            gaji.Tahun = cetakSlipGaji .Tahun;
            myContext.Gaji.Add(gaji);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Gaji gaji)
        {
            var data = myContext.Gaji.Find(gaji.ID);
            data.KaryawanID = gaji.KaryawanID;
            data.Bulan = gaji.Bulan;
            data.Tahun = gaji.Tahun;
            myContext.Gaji.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
