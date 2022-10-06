﻿using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class KaryawanRepository : IKaryawanRepository
    {
        MyContext myContext;
        public KaryawanRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Karyawan.Find(id);
            myContext.Karyawan.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Karyawan> Get()
        {
            var data = myContext.Karyawan.Include(x => x.Jabatan).ToList();
            return data;
        }

        public Karyawan Get(int id)
        {
            var data = myContext.Karyawan.Find(id);
            return data;
        }

        public int Post(InputKaryawan inputKaryawan)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.NamaLengkap = inputKaryawan.NamaLengkap;
            karyawan.Email = inputKaryawan.Email;
            karyawan.NomerRekening = inputKaryawan.NomerRekening;
            karyawan.NomerTelepon = inputKaryawan.NomerTelepon;
            karyawan.JabatanID = inputKaryawan.JabatanID;
            myContext.Karyawan.Add(karyawan);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Karyawan karyawan)
        {
            var data = myContext.Karyawan.Find(karyawan.ID);
            data.NamaLengkap = karyawan.NamaLengkap;
            data.Email = karyawan.Email;
            data.NomerRekening = karyawan.NomerRekening;
            data.NomerTelepon = karyawan.NomerTelepon;
            data.JabatanID = karyawan.JabatanID;
            myContext.Karyawan.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
