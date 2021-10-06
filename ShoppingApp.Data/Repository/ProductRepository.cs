using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Data;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingApp.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Product> GetSearchedProducts(string searchTerm)
        {
            return context.Products.Include(x => x.Category)
                                    .Include(x => x.Manufacturer)
                                    .Where(x => EF.Functions.Like(x.Name, $"%{searchTerm}%") ||
                                    EF.Functions.Like(x.Category.Name, $"%{searchTerm}%") ||
                                    EF.Functions.Like(x.Manufacturer.Name, $"%{searchTerm}%")).ToList();
        }


        public IEnumerable<Product> GetById(int id)
        {
            return context.Products.Include(x => x.Category)
                                    .Include(x => x.Manufacturer)
                                    .Where(i => i.Id == id);
             
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.Include(x => x.Category)
                                    .Include(x => x.Manufacturer).ToList();
        }
    }
}
