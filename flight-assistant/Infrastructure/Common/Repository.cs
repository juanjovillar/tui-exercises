using Application.Interfaces;
using Domain.Common;
using System.Linq;

namespace Infrastructure.Common
{
    public class Repository<T>
        : IRepository<T>
        where T : class, IEntity
    {
        private readonly CustomContext _context;

        public Repository(CustomContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Get(int id)
        {
            return _context.Set<T>()
                .Single(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        
    }
}
