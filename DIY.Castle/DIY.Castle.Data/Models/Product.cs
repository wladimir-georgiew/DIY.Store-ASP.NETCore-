using DIY.Castle.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIY.Castle.Data.Models
{
    [Table("Products")]
    public class Product : IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(25)]
        [Required]
        public string ProductType { get; set; }

        [Range(0.00, 100000.00)]
        [Column(TypeName = "decimal(8,2)")]
        [Required]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string ImageSourcePath { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
