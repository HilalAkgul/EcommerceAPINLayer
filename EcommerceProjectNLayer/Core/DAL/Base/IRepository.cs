using System;
namespace DAL.Base
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetDatas { get; }
        T GetTestDb(int id);
        void Add(T test);
        void Remove(int id);
        List<T> List();

    }
}

