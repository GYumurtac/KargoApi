using BilgeGameKargo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.VMClasses
{
    public class HareketVM
    {
        public string KargoKonum { get; set; }

        public Durum KargoDurum { get; set; }

        public string KargoDetay { get; set; }

        public DateTime? Tarih { get; set; }
    }
}