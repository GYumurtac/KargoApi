using BilgeGameKargo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Maps
{
    public class KargoMap : BaseMap<Kargo>
    {
        public KargoMap()
        {
            ToTable("Kargolar");


        }
    }
}