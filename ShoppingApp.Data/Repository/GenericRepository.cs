using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Data;
using ShoppingApp.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> table;

        public GenericRepository(AppDbContext _context)
        {
            context = _context;
            table = _context.Set<T>();
        }
        public async Task<bool> Delete(object id)
        {
                T exsisting = await table.FindAsync(id);
                table.Remove(exsisting);
                await context.SaveChangesAsync();
                return true;
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Insert(IEnumerable<T> collection)
        {
            table.AddRange(collection);
            context.SaveChanges();
        }

        public async Task<bool> Insert(T obj)
        {
                await table.AddAsync(obj);
                await context.SaveChangesAsync();
                return true;
        }


        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
