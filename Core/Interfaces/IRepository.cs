using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> Get(int offset, int count);
        IQueryable<T> GetAll();
        void Add(T entry);
        void Update(T entry);
        void Delete(T entry);
        void Initialize(object context);

    }
}
