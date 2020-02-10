using BilgeGameKargo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Entities
{
    public class Hareket : BaseEntity
    {

        public string Birim { get; set; }

        public Durum Durum { get; set; }

        public string Aciklama { get; set; }

        public int KargoID { get; set; }

        //Relational Properties

        public virtual Kargo Kargo { get; set; }

    }
}