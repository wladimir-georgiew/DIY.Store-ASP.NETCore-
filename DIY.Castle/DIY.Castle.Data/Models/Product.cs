using DIY.Castle.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIY.Castle.Data.Models
{
    [Table("Products")]
    public class Product : IDeletableEntity
    {
        public Product()
        {
            this.Variations = new HashSet<Variation>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int SubcategoryId { get; set; }

        public Subcategory Subcategory { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string ImageSourcePath { get; set; }

        public virtual ICollection<Variation> Variations { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
