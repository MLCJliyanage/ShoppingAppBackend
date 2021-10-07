using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.ManagerClasses.Interfaces;
using ShoppingApp.Common;
using ShoppingApp.Common.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ShoppingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        
        private readonly IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet("getallproducts")]
        public IEnumerable<ProductDto> Get()
        {
            return productManager.GetProducts();
           
        }

        [HttpGet("getallcategories")]
        public IEnumerable<CategoryDto> GetCategories()
        {
            return productManager.GetCategories();

        }

        [HttpGet("getallmanufactureres")]
        public IEnumerable<ManufactureDto> GetManufactureres()
        {
            return productManager.GetManufactureres();
        }

        [HttpGet("getproduct/{id:int?}")]
        public ProductDto GetProductById(int id)
        {
            return productManager.GetProductById(id);

        }

        [HttpGet("getproductbyadmin/{id:int}")]
        public IEnumerable<ProductDto> GetProductByAdmin(int id)
        {
            return productManager.GetProductsByAdmin(id);

        }

        [HttpGet("getproductsbycategory/{id:int}")]
        public IEnumerable<ProductDto> GetProductsByCategory(int id)
        {
            return productManager.GetProductsByCategory(id);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(AddProductDto newProduct)
        {
            if (ModelState.IsValid)
            {
                StatusDto status = await productManager.AddProduct(newProduct);

                if (status.IsSuccess)
                    return Ok(status);

                return BadRequest(status);

            } else
            {
                StatusDto status = new()
                {
                    IsSuccess = false,
                    ErrorMessage = Constants.InvalidData
                };
                return BadRequest(status);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("updateproduct")]
        public IActionResult UpdateProduct(AddProductDto updateProduct)
        {
            if (ModelState.IsValid)
            {
                StatusDto status =  productManager.UpdateProduct(updateProduct);

                if (status.IsSuccess)
                    return Ok(status);

                return BadRequest(status);

            }
            else
            {
                StatusDto status = new()
                {
                    IsSuccess = false,
                    ErrorMessage = Constants.InvalidData
                };
                return BadRequest(status);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteproduct/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                StatusDto status = await productManager.DeleteProduct(id);

                if (status.IsSuccess)
                    return Ok(status);

                return BadRequest(status);

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("searchproduct")]
        public IEnumerable<ProductDto> SearchedProduct(string search)
        {
            return this.productManager.GetSearchedProducts(search);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost("uploadimage")]
        public IActionResult ExcelUpload(IFormFile imageFile)
        {
            byte[] data;
            if (Request.Form.Files == null || Request.Form.Files.Count <= 0)
                return BadRequest(Constants.EmptyFile);

            using (var br = new BinaryReader(imageFile.OpenReadStream()))
            {
                data = br.ReadBytes((int)imageFile.OpenReadStream().Length);
            }

            var fileName = Request.Form.Files[0].FileName;
            StatusDto result = this.productManager.UploadImage(data, fileName);
            if (result.IsSuccess)
                return Ok();

            return BadRequest(result.ErrorMessage);
        }

    }
}
