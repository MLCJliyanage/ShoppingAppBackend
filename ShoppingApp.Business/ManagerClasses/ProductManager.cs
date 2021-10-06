using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingApp.Business.ManagerClasses.Interfaces;
using ShoppingApp.Common;
using ShoppingApp.Common.Dtos;
using ShoppingApp.Data.Entities;
using ShoppingApp.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.ManagerClasses
{
    public class ProductManager : IProductManager
    {
        #region Propeties
        private readonly IGenericRepository<Product> genericRepository;
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IGenericRepository<Manufacturer> manufacturerRepository;
        private readonly IProductRepository productRepository;
        private readonly IConfiguration config;
        #endregion

        #region Constructor
        public ProductManager(
            IGenericRepository<Product> genericRepository,
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<Manufacturer> manufacturerRepository,
            IProductRepository productRepository,
            IConfiguration config
            )
        {
            this.genericRepository = genericRepository;
            this.categoryRepository = categoryRepository;
            this.manufacturerRepository = manufacturerRepository;
            this.productRepository = productRepository;
            this.config = config;
        }
        #endregion

        #region Public Methods
        public ProductDto GetProductById(int id)
        {
            Product product = productRepository.GetById(id).FirstOrDefault();

            ProductDto dto = new()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Color = product.Color,
                AddedUserId = product.AddedUserId,
                Image = product.Image,
                InStock = product.InStock,
                CreatedDateTime = product.CreatedDateTime,
                UpdatedDateTime = product.UpdatedDateTime,
                IsActive = product.IsActive,
                CategoryId = product.Category_id,
                ManufacturerId = product.Manufacturer_id,
                CategoryName = product.Category.Name,
                ManufacturerName = product.Manufacturer.Name
            };


            return dto;
            //return (from product in genericRepository.GetById(id)
            //        select new ProductDto { Id = product.Id, Name = product.Name }).FirstOrDefault();
        }

        public IList<ProductDto> GetProducts()
        {
            return productRepository.GetAllProducts().Select(Product => new ProductDto
            {
                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                Color = Product.Color,
                AddedUserId = Product.AddedUserId,
                Image = Product.Image,
                InStock = Product.InStock,
                CreatedDateTime = Product.CreatedDateTime,
                UpdatedDateTime = Product.UpdatedDateTime,
                IsActive = Product.IsActive,
                CategoryId = Product.Category_id,
                ManufacturerId = Product.Manufacturer_id,              
                CategoryName = Product.Category.Name,              
                ManufacturerName = Product.Manufacturer.Name
            }).Where(x => x.IsActive == true).ToList();
        }

        public async Task<StatusDto> AddProduct(AddProductDto addProduct)
        {
            
            StatusDto status = new();

            Product product = new()
            {
                Name = addProduct.Name,
                Price = addProduct.Price,
                Color = addProduct.Color,
                AddedUserId = addProduct.AddedUserId,
                Image = addProduct.Image,
                InStock = addProduct.InStock,
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                IsActive = addProduct.IsActive,
                Category_id = addProduct.CategoryId,
                Manufacturer_id = addProduct.ManufacturerId
            };


                if (await genericRepository.Insert(product))
                {
                    status.IsSuccess = true;
                } 
                else 
                {
                    status.IsSuccess = false;
                    status.ErrorMessage = Constants.ErrorSavingToDb;
                }

                return status;


        }

        public async Task<StatusDto> DeleteProduct(int id)
        {
            StatusDto status = new();


                if (await genericRepository.Delete(id))
                {
                    status.IsSuccess = true;
                }
                else
                {
                    status.IsSuccess = false;
                    status.ErrorMessage = Constants.ErrorSavingToDb;
                }

                return status;

        }

        public IList<CategoryDto> GetCategories()
        {
            return categoryRepository.GetAll().Select(Category => new CategoryDto
            {
                Id = Category.Id,
                Name = Category.Name
            }).ToList();
        }

        public IList<ProductDto> GetProductsByAdmin(int id)
        {
               return this.productRepository.GetAllProducts().Select(Product => new ProductDto
                {
                   Id = Product.Id,
                   Name = Product.Name,
                   Price = Product.Price,
                   Color = Product.Color,
                   AddedUserId = Product.AddedUserId,
                   Image = Product.Image,
                   InStock = Product.InStock,
                   CreatedDateTime = Product.CreatedDateTime,
                   UpdatedDateTime = Product.UpdatedDateTime,
                   IsActive = Product.IsActive,
                   CategoryId = Product.Category_id,
                   ManufacturerId = Product.Manufacturer_id,
                   CategoryName = Product.Category.Name,
                   ManufacturerName = Product.Manufacturer.Name
               }).Where(x => x.AddedUserId == id).ToList();
        }

        public StatusDto UpdateProduct(AddProductDto updateProduct)
        {
            StatusDto status = new();

                Product exsistingProduct = this.productRepository.GetById(updateProduct.Id).First();

                if (exsistingProduct != null)
                {
                    exsistingProduct.Name = updateProduct.Name;
                    exsistingProduct.Price = updateProduct.Price;
                    exsistingProduct.Color = updateProduct.Color;
                    exsistingProduct.Image = updateProduct.Image;
                    exsistingProduct.InStock = updateProduct.InStock;
                    exsistingProduct.IsActive = updateProduct.IsActive;
                    exsistingProduct.Category_id = updateProduct.CategoryId;
                    exsistingProduct.Manufacturer_id = updateProduct.ManufacturerId;
                    exsistingProduct.UpdatedDateTime = DateTime.Now;

                    genericRepository.Update(exsistingProduct);
                    status.IsSuccess = true;
                    return status;
                } else
                {
                    status.IsSuccess = false;
                    status.ErrorMessage = Constants.ErrorSavingToDb;
                    return status;
                }

        }

        public StatusDto UploadImage(byte[] file, string fileName)
        {
            StatusDto status = new();
            string containerName = config.GetSection("AppSettings:ContainerName").Value;
            string storageConnection = config.GetSection("AppSettings:StorageConnection").Value;
            try
            {
                HelperMethods.UploadToBlob(file, fileName, storageConnection, containerName);
                status.IsSuccess = true;
                return status;
            }
            catch (Exception)
            {
                status.IsSuccess = false;
                status.ErrorMessage = Constants.ErrorUploadingFile;
                return status;
            }
        }

        public IList<ProductDto> GetSearchedProducts(string searchTerm)
        {
            return productRepository.GetSearchedProducts(searchTerm).Select(Product => new ProductDto
            {
                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                Color = Product.Color,
                AddedUserId = Product.AddedUserId,
                Image = Product.Image,
                InStock = Product.InStock,
                CreatedDateTime = Product.CreatedDateTime,
                UpdatedDateTime = Product.UpdatedDateTime,
                IsActive = Product.IsActive,
                CategoryId = Product.Category_id,
                ManufacturerId = Product.Manufacturer_id,
                CategoryName = Product.Category.Name,
                ManufacturerName = Product.Manufacturer.Name
            }).ToList();
        }

        public IList<ManufactureDto> GetManufactureres()
        {
            return manufacturerRepository.GetAll().Select(M => new ManufactureDto
            {
                Id = M.Id,
                Name = M.Name
            }).ToList();
        }

        public IList<ProductDto> GetProductsByCategory(int id)
        {
            return this.productRepository.GetAllProducts().Select(Product => new ProductDto
            {
                Id = Product.Id,
                Name = Product.Name,
                Price = Product.Price,
                Color = Product.Color,
                AddedUserId = Product.AddedUserId,
                Image = Product.Image,
                InStock = Product.InStock,
                CreatedDateTime = Product.CreatedDateTime,
                UpdatedDateTime = Product.UpdatedDateTime,
                IsActive = Product.IsActive,
                CategoryId = Product.Category_id,
                ManufacturerId = Product.Manufacturer_id,
                CategoryName = Product.Category.Name,
                ManufacturerName = Product.Manufacturer.Name
            }).Where(x => x.CategoryId == id).ToList();
        }

        #endregion
    }
}

