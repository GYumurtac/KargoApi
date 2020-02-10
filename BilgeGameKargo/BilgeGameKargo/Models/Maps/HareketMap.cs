using BilgeGameKargo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Maps
{
    public class HareketMap : BaseMap<Hareket>
    {
        public HareketMap()
        {
            ToTable("KargoHareketleri");
            Property(x => x.Birim).HasMaxLength(50);
            Property(x => x.Aciklama).HasMaxLength(200);
        }
    }
}