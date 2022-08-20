using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> All
        {
            get { return _dbSet; }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T SelectById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">Kayıt id</param>
        public virtual void DeleteById(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// </summary>
        /// <param name="entityToDelete">Kayıt</param>
        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _context.Entry(entityToDelete).State = EntityState.Modified;
            _dbSet.Remove(entityToDelete);
            _context.SaveChanges();

        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
