using BilgeGameKargo.Models.Entities;
using BilgeGameKargo.Models.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {

        }

        //Konfigürasyon Ayarları
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KargoMap());
            modelBuilder.Configurations.Add(new AliciMap());
            modelBuilder.Configurations.Add(new HareketMap());
            modelBuilder.Configurations.Add(new AdresMap());
        }

        //Tablolar
        public DbSet<Kargo> Kargolar { get; set; }

        public DbSet<Alici> Alicilar { get; set; }

        public DbSet<Hareket> Hareketler { get; set; }

        public DbSet<AdresBilgisi> AdresBilgileri { get; set; }

    }
}