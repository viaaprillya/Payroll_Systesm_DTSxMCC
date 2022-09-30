﻿using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        //Atur connection string
        //Memasukkan model yang digunakan untuk melakukan operasi CRUD/Migrasi

        public DbSet<Karyawan> Karyawan { get; set; }
        public DbSet<Jabatan> Jabatan { get; set; }
        public DbSet<Bonus> Bonus { get; set; }
        public DbSet<Potongan> Potongan { get; set; }
        public DbSet<Cuti> Cuti { get; set; }
        public DbSet<Lembur> Lembur { get; set; }
        public DbSet<Gaji> Gaji { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }



    }
}
