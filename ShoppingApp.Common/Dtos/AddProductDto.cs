using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Common.Dtos
{
    public class AddProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int AddedUserId { get; set; }
        public string Image { get; set; }
        public bool InStock { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
    }
}
