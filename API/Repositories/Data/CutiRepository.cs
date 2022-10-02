using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class CutiRepository : ICutiRepository
    {
        MyContext myContext;
        public CutiRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Cuti.Find(id);
            myContext.Cuti.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Cuti> Get()
        {
            var data = myContext.Cuti.ToList();
            return data;
        }

        public Cuti Get(int id)
        {
            var data = myContext.Cuti.Find(id);
            return data;
        }

        public int Post(InputCuti inputCuti)
        {
            Cuti cuti = new Cuti();
            cuti.KaryawanID = inputCuti.KaryawanID;
            cuti.JumlahHari = inputCuti.JumlahHari;
            cuti.Tanggal = inputCuti.Tanggal;
            cuti.Keterangan = inputCuti.Keterangan;
            myContext.Cuti.Add(cuti);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Cuti cuti)
        {
            var data = myContext.Cuti.Find(cuti.ID);
            data.KaryawanID = cuti.KaryawanID;
            data.JumlahHari = cuti.JumlahHari;
            data.Tanggal = cuti.Tanggal;
            data.Keterangan = cuti.Keterangan;
            myContext.Cuti.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public int PengajuanCuti(PengajuanCuti pengajuanCuti)
        {
            int totalcuti=0;
            //var karyawan = myContext.Karyawan.Find(pengajuanCuti.KaryawanID);
            var data = myContext.Cuti
                .Include(x => x.Karyawan)
                .Where(x =>
                    x.Karyawan.ID.Equals(pengajuanCuti.KaryawanID) &&
                    x.Tanggal.Month==pengajuanCuti.Tanggal.Month &&
                    x.Tanggal.Year==pengajuanCuti.Tanggal.Year
                    )
                .GroupBy(x => x.KaryawanID)
                .Select(x => new { totalJumlahHari = x.Sum(x => x.JumlahHari) }).FirstOrDefault();
            if (data != null)
            {
                totalcuti = data.totalJumlahHari;
            }
            if (data==null || totalcuti <= 5)
            {
                InputCuti inputCuti = new InputCuti();
                inputCuti.Tanggal = pengajuanCuti.Tanggal;
                inputCuti.JumlahHari = pengajuanCuti.JumlahHari;
                inputCuti.KaryawanID = pengajuanCuti.KaryawanID;
                inputCuti.Keterangan = pengajuanCuti.Keterangan;
                var result = Post(inputCuti);
                return result;
            }
            int tolak = 0;
            return tolak;
        }
    }
}
