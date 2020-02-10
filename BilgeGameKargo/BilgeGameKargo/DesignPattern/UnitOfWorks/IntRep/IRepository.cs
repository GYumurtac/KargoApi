using BilgeGameKargo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BilgeGameKargo.DesignPattern.UnitOfWorks.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Listeler
        List<T> GetAll();

        List<T> GetActives();

        List<T> GetPassives();

        List<T> GetUpdateds();


        //Ekleme-Silme-Guncelleme
        void Add(T item);

        void Update(T item);

        void Delete(T item);

        void Destroy(int id);


        //Linq Sorguları
        List<T> Where(Expression<Func<T, bool>> exp);

        bool Any(Expression<Func<T, bool>> exp);

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        T Find(int id);

        object Select(Expression<Func<T, object>> exp);
    }
}