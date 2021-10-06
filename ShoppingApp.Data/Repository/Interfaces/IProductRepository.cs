using ShoppingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Repository.Interfaces
{
    public interface IProductRepository
    {

        IEnumerable<Product> GetById(int id);
        IEnumerable<Product> GetAllProducts();

        List<Product> GetSearchedProducts(string searchTerm);
    }
}
