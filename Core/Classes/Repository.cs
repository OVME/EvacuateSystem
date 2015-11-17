using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Core.Interfaces;
using EvacuateSystem.Model.Classes;

namespace Core.Classes
{
    [Export(typeof(IRepository<>))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class Repository<T>: IRepository<T> where T : BaseEntity
    {
        private DbContext _context;
        public Repository()
        {
           
        }

        public void Initialize(object context)
        {
            _context = (DbContext)context;
            
        }
        public T Get(int id)
        {
            return _context.Set<T>().Find(new {Id = id});
        }

        public IEnumerable<T> Get(int offset, int count)
        {
            return _context.Set<T>().OrderBy(p => p.Id).Skip(offset).Take(count);
        }

        public IQueryable<T> GetAll()
        {
            
            return _context.Set<T>();
        }

        public void Add(T entry)
        {
            _context.Set<T>().Add(entry);
            _context.SaveChanges();
        }

        public void Update(T entry)
        {
            _context.Set<T>().AddOrUpdate(entry);
            _context.SaveChanges();
        }

        public void Delete(T entry)
        {
            _context.Set<T>().Remove(entry);
            _context.SaveChanges();
        }
    }
}
