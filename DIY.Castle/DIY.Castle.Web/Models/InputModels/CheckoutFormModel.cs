using DIY.Castle.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DIY.Castle.Web.Models.InputModels
{
    public class CheckoutFormModel
    {
        [Required(ErrorMessage = "Полето 'Име' е задължително")]
        [MaxLength(50, ErrorMessage = "First Name is too long. Max characters 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето 'Фамилия' е задължително")]
        [MaxLength(50, ErrorMessage = "Last Name is too long. Max characters 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето 'Телефон' е задължително")]
        [MaxLength(50, ErrorMessage = "Phone Number is too long. Max characters 50")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето 'Град' е задължително")]
        [MaxLength(50, ErrorMessage = "City is too long. Max characters 50")]
        public string City { get; set; }

        [Required(ErrorMessage = "Полето 'Куриер' е задължително")]
        [MaxLength(50, ErrorMessage = "Courrier is too long. Max characters 50")]
        public string CourrierOption { get; set; }

        [MaxLength(100, ErrorMessage = "Address is too long. Max characters 100")]
        public string Address { get; set; }

        public string EcontOffice { get; set; }

        [MaxLength(50, ErrorMessage = "Delivery Option is too long. Max characters 50")]
        public string DeliveryOption { get; set; }

        [MaxLength(50, ErrorMessage = "Delivery Option is too long. Max characters 50")]
        public string CustomerEmailAddress { get; set; }
    }
}
