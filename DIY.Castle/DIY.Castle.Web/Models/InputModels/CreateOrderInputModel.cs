using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Models.InputModels
{
    public class CreateOrderInputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
    }
}
