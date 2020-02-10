using BilgeGameKargo.DesignPattern.UnitOfWorks.ConcRep;
using BilgeGameKargo.Models.Entities;
using BilgeGameKargo.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BilgeGameKargo.Controllers
{
    public class HomeController : ApiController
    {
        KargoRepository krep;

        AliciRepository arep;

        HareketRepository hrep;

        AdresRepository adrep;

        public HomeController()
        {
            krep = new KargoRepository();

            arep = new AliciRepository();

            hrep = new HareketRepository();

            adrep = new AdresRepository();
        }

        [HttpPost]
        public HttpResponseMessage KargoOlustur(KargoVM item)
        {
            try
            {
                if (item != null)
                {
                    Alici alici = new Alici
                    {
                        FirstName = item.Adi.TrimEnd(),
                        LastName = item.Soyadi.TrimEnd(),
                        TCKimlikNo = item.TCKimlikNumarası
                    };

                    arep.Add(alici);

                    AdresBilgisi adresBilgisi = new AdresBilgisi
                    {
                        AliciID = alici.ID,
                        Adres = item.Adres.TrimEnd(),
                        EPosta = item.Mail.TrimEnd(),
                        Mahalle = item.Mahalle.TrimEnd(),
                        Ilce = item.Ilce.TrimEnd(),
                        Sehir = item.Il.TrimEnd(),
                        Telefon = item.Telefon.TrimEnd()
                    };

                    adrep.Add(adresBilgisi);

                    Kargo kargo = new Kargo
                    {
                        AliciID = alici.ID
                    };

                    krep.Add(kargo);

                    return Request.CreateResponse(HttpStatusCode.Created, $"Kargo Oluşturuldu/Takip Numarası : {kargo.GonderiNo} ");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Kargo Oluşturulamadı");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage KargoTakipEt(Guid kargoTakip)
        {
            try
            {
                if (kargoTakip != null)
                {
                    if (krep.Any(x => x.GonderiNo == kargoTakip))
                    {
                        Kargo kargo = krep.FirstOrDefault(x => x.GonderiNo == kargoTakip);

                        List<HareketVM> hareketler = hrep.GetActives().Where(x => x.KargoID == kargo.ID).Select(x => new HareketVM { KargoDetay = x.Aciklama, KargoDurum = x.Durum, KargoKonum = x.Birim, Tarih = x.CreatedDate }).ToList();

                        return Request.CreateResponse(HttpStatusCode.OK, hareketler);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Böyle bir kargo bulunamadı.");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Böyle bir kargo bulunamadı.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}