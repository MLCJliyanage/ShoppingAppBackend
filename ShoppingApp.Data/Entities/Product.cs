using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Entities
{
    [Table("Sha_Products")]
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        public int AddedUserId { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        [ForeignKey("Category")]
        public int Category_id { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Manufacturer")]
        public int Manufacturer_id { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}
