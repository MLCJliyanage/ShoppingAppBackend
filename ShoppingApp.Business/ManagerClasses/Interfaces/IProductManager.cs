using ShoppingApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.ManagerClasses.Interfaces
{
    public interface IProductManager
    {
        IList<ProductDto> GetProducts();

        ProductDto GetProductById(int id);

        Task<StatusDto> AddProduct(AddProductDto addProduct);

        StatusDto UpdateProduct(AddProductDto updateProduct);

        Task<StatusDto> DeleteProduct(int id);

        IList<CategoryDto> GetCategories();

        IList<ManufactureDto> GetManufactureres();

        IList<ProductDto> GetProductsByAdmin(int id);

        StatusDto UploadImage(byte[] file, string fileName);

        IList<ProductDto> GetSearchedProducts(string searchTerm);
        IList<ProductDto> GetProductsByCategory(int id);


    }
}
