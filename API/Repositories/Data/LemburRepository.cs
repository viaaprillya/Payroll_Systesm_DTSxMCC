using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class LemburRepository : ILemburRepository
    {
        MyContext myContext;
        public LemburRepository()
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Lembur.Find(id);
            myContext.Lembur.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Lembur> Get()
        {
            var data = myContext.Lembur.ToList();
            return data;
        }

        public Lembur Get(int id)
        {
            var data = myContext.Lembur.Find(id);
            return data;
        }

        public int Post(InputLembur inputLembur)
        {
            Lembur lembur = new Lembur();
            lembur.KaryawanID = inputLembur.KaryawanID;
            lembur.JumlahJam = inputLembur.JumlahJam;
            lembur.Tanggal = inputLembur.Tanggal;
            lembur.Keterangan = inputLembur.Keterangan;
            myContext.Lembur.Add(lembur);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Lembur lembur)
        {
            var data = myContext.Lembur.Find(bonus.ID);
            data.KaryawanID = lembur.KaryawanID;
            data.JumlahJam = lembur.JumlahJam;
            data.Tanggal = lembur.Tanggal;
            data.Keterangan = lembur.Keterangan;
            myContext.Lembur.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
