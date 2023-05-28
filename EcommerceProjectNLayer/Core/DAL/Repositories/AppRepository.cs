using System;
using DAL.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class AppRepository<T> : IRepository<T> where T : class
    {
       
            private DbSet<T> entities;
            private AppDbContext db;
            public AppRepository(AppDbContext _db)
            {
                db = _db;
                entities = _db.Set<T>();
            }
            public IEnumerable<T> GetDatas => entities.AsEnumerable();
            public void Add(T test)
            {
                entities.Add(test);
                db.SaveChanges();
            }
        public List<T> List()
        {
            db.ChangeTracker.LazyLoadingEnabled = false;
            return entities.ToList();
        }
        public DbSet<T> Queryable()
        {
            db.ChangeTracker.LazyLoadingEnabled = false;
            return entities;
        }
        public T GetTestDb(int id)
            {
                T testd = entities.Find(id);
                return testd;
            }

            public void Remove(int id)
            {
                T testd = entities.Find(id);
                entities.Remove(testd);
                db.SaveChanges();
            }
        
    }
}



