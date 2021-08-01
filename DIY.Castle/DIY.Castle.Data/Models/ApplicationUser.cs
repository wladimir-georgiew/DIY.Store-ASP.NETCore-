using Microsoft.AspNetCore.Identity;
using System;

namespace DIY.Castle.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
