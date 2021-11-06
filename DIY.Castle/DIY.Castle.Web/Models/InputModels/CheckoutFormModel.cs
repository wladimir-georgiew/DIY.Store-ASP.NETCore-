using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Models.InputModels
{
    public class CheckoutFormModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string EcontOffice { get; set; }

        public string DeliveryOption { get; set; }

        public string CustomerEmailAddress { get; set; }
    }
}
