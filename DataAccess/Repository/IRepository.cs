using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{

    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        IQueryable<T> All { get; }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T SelectById(int id);

        /// <summary>
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(T entityToUpdate);

        /// <summary>

        /// </summary>
        /// <param name="id">Kayıt id</param>
        void DeleteById(int id);

        /// <summary>

        /// </summary>
        /// <param name="entityToDelete">Kayıt</param>
        void Delete(T entityToDelete);


        void SaveChanges();



    }


}
