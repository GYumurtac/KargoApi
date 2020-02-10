using BilgeGameKargo.DesignPattern.SingletonPattern;
using BilgeGameKargo.DesignPattern.UnitOfWorks.IntRep;
using BilgeGameKargo.Models.Context;
using BilgeGameKargo.Models.Entities;
using BilgeGameKargo.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BilgeGameKargo.DesignPattern.UnitOfWorks.BaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        MyContext db;

        public BaseRepository()
        {
            db = DBTool.DBInstance;
        }

        void Save()
        {
            db.SaveChanges();
        }


        //Listeleme

        /// <summary>
        /// GetActives() metodundan farklı olarak pasif durumda olan verileri getirir.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        /// <summary>
        /// Pasif olmayanların dışındaki verileri getirir.
        /// </summary>
        /// <returns></returns>
        public List<T> GetActives()
        {
            return db.Set<T>().Where(x => x.Status != DataStatus.Deleted).ToList();
        }

        /// <summary>
        /// Sadece pasif verileri getirir.
        /// </summary>
        /// <returns></returns>
        public List<T> GetPassives()
        {
            return db.Set<T>().Where(x => x.Status == DataStatus.Deleted).ToList();
        }

        /// <summary>
        /// Sadece güncellenmiş verileri getirir.
        /// </summary>
        /// <returns></returns>
        public List<T> GetUpdateds()
        {
            return db.Set<T>().Where(x => x.Status == DataStatus.Updated).ToList();
        }


        //Ekleme-Silme-Guncelle

        public virtual void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        /// <summary>
        /// İlgili nesne veritabanından silinmeyip pasife çekilir.
        /// </summary>
        /// <param name="item"></param>
        public void Delete(T item)
        {
            item.Status = DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        /// <summary>
        /// İlgili nesneyi veritabanından tamamen kaldırır. Nesneye bir daha ulaşılamaz. Bu nedenle kullanırken dikkat edilmelidir.
        /// </summary>
        /// <param name="id">Veritabanından kaldırılmak istenen nesnenin ID numrasını tanımlar.</param>
        public void Destroy(int id)
        {
            db.Set<T>().Remove(Find(id));
            Save();
        }

        /// <summary>
        /// İlgili nesneyi günceller.
        /// </summary>
        /// <param name="item"></param>
        public virtual void Update(T item)
        {
            item.Status = DataStatus.Updated;
            item.UpdatedDate = DateTime.Now;
            T updated = Find(item.ID);
            db.Entry(updated).CurrentValues.SetValues(item);
            Save();
        }


        //Linq Sorguları

        /// <summary>
        /// ID numarasına göre sorgu yapar, geriye ilgili nesneyi döndürür.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(int id)
        {
            return db.Set<T>().Find(id);
        }

        /// <summary>
        /// Yazılan sorgu ifadesine göre arama yapar ve geriye varsa ilgili nesneyi yoksa da varsayılan olarak atanan değeri döndürür.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        /// <summary>
        /// Argüman olarak yazılan sorgu ifadesine göre sorgu yapar ve geriye true veya false değer döndürür.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return db.Set<T>().Select(exp).ToList();
        }

    }
}