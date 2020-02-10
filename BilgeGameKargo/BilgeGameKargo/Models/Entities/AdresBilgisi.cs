using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Entities
{
    public class AdresBilgisi : BaseEntity
    {
        public string Adres { get; set; }

        public string Sehir { get; set; }

        public string Ilce { get; set; }

        public string Mahalle { get; set; }

        public string Telefon { get; set; }

        public string EPosta { get; set; }

        public int AliciID { get; set; }


        //Relational Properties

        public virtual Alici Alici { get; set; }
    }
}