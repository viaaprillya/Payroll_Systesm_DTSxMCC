using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class PotonganRepository : IPotonganRepository
    {
        MyContext myContext;
        public PotonganRepository()
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Potongan.Find(id);
            myContext.Potongan.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Potongan> Get()
        {
            var data = myContext.Potongan.ToList();
            return data;
        }

        public Potongan Get(int id)
        {
            var data = myContext.Potongan.Find(id);
            return data;

        }

        public int Post(InputPotongan inputPotongan)
        {
            Potongan potongan = new Potongan();
            potongan.KaryawanID = inputPotongan.KaryawanID;
            potongan.Jumlah = inputPotongan.Jumlah;
            potongan.Tanggal = inputPotongan.Tanggal;
            potongan.Keterangan = inputPotongan.Keterangan;
            myContext.Potongan.Add(potongan);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Potongan potongan)
        {
            var data = myContext.Potongan.Find(potongan.ID);
            data.KaryawanID = potongan.KaryawanID;
            data.Jumlah = potongan.Jumlah;
            data.Tanggal = potongan.Tanggal;
            data.Keterangan = potongan.Keterangan;
            myContext.Potongan.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
