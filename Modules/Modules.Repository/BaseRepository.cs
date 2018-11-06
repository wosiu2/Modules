using Modules.Base.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Modules.Repository
{
    public abstract class BaseRepository<TEntity, C> : IBaseRepository<TEntity>
        where TEntity : class
        where C : DbContext, new()
    {
        protected C _context = new C();

        public C Context
        {
            get {
                return _context;
            }

            set
            {
                _context = value;
            }
        }

        /// <summary>
        /// usuwa element podany na wejsciu
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        /// <summary>
        /// Usuwa wszystkie encje danej klasy
        /// </summary>
        public virtual void DeleteAll()
        {
            foreach (TEntity entity in _context.Set<TEntity>())
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        /// <summary>
        /// metoda usuwa elementy danej klasy ktore przechowywane sa w kolekcji wejsciowej entities
        /// </summary>
        /// <param name="entities"></param>
        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Metoda abstrakcyjna ktorej wynikiem dzialania jest encja danej klasy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract TEntity Get(int id);

        /// <summary>
        /// Metoda zwraca kolekcje elementow danej klasy
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Select(n => n).ToList();
        }

        public virtual void Complete()
        {
            _context.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
    }
}
