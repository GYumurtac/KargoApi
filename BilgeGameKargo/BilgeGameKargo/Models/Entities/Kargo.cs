using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeGameKargo.Models.Entities
{
    public class Kargo : BaseEntity
    {
        public Kargo()
        {
            Guid takipNo = Guid.NewGuid();
            GonderiNo = takipNo;
        }

        public Guid GonderiNo { get; set; }

        //public sbyte Desi { get; set; }

        //public bool AliciOdemeli { get; set; }

        //decimal _tutar;

        //public decimal Tutar
        //{
        //    private set
        //    {
        //        _tutar = Convert.ToDecimal(Desi) * 20M;
        //    }
        //    get
        //    {

        //        return _tutar;
        //    }
        //}

        public int AliciID { get; set; }


        //Relational Properties

        public virtual List<Hareket> Hareketler { get; set; }

        public virtual Alici Alici { get; set; }
    }
}