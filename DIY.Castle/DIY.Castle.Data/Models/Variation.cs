using DIY.Castle.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIY.Castle.Data.Models
{
    [Table("Variations")]
    public class Variation : IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VariationName { get; set; }


        [Range(0.00, 100000.00)]
        [Column(TypeName = "decimal(8,2)")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
