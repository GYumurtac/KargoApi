using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Entities
{
    public class Alici : BaseEntity
    {
        public string TCKimlikNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //Relational Properties

        public virtual List<Kargo> Kargolar { get; set; }

        public virtual List<AdresBilgisi> AdresBilgileri { get; set; }
    }
}