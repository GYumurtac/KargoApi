using BilgeGameKargo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Maps
{
    public class AliciMap : BaseMap<Alici>
    {
        public AliciMap()
        {
            ToTable("Alicilar");
            Property(x => x.FirstName).HasMaxLength(30);
            Property(x => x.LastName).HasMaxLength(30);
            Property(x => x.TCKimlikNo).HasMaxLength(11);
        }
    }
}