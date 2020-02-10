using BilgeGameKargo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Maps
{
    public class AdresMap : BaseMap<AdresBilgisi>
    {
        public AdresMap()
        {
            ToTable("AdresBilgileri");
            Property(x => x.Adres).HasMaxLength(200);
            Property(x => x.EPosta).HasMaxLength(60);
            Property(x => x.Ilce).HasMaxLength(30);
            Property(x => x.Sehir).HasMaxLength(20);
            Property(x => x.Telefon).HasMaxLength(11);

        }
    }
}