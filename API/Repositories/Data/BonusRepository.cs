using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class BonusRepository : IBonusRepository

    {
        MyContext myContext;
        public BonusRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Bonus.Find(id);
            myContext.Bonus.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Bonus> Get()
        {
            var data = myContext.Bonus.ToList();
            return data;
        }

        public Bonus Get(int id)
        {
            var data = myContext.Bonus.Find(id);
            return data;
        }

        public int Post(InputBonus inputBonus)
        {
            Bonus bonus = new Bonus();
            bonus.KaryawanID = inputBonus.KaryawanID;
            bonus.Jumlah = inputBonus.Jumlah;
            bonus.Tanggal = inputBonus.Tanggal;
            bonus.Keterangan = inputBonus.Keterangan;
            myContext.Bonus.Add(bonus);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Bonus bonus)
        {
            var data = myContext.Bonus.Find(bonus.ID);
            data.KaryawanID = bonus.KaryawanID;
            data.Jumlah = bonus.Jumlah;
            data.Tanggal = bonus.Tanggal;
            data.Keterangan = bonus.Keterangan;
            myContext.Bonus.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
