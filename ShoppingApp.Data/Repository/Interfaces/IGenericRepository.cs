using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(IEnumerable<T> collection);
        Task<bool> Insert(T obj);
        void Update(T obj);
        Task<bool> Delete(object id);
    }
}
