using System;

namespace DIY.Castle.Data.Interfaces
{
    public interface IDeletableEntity
    {
        DateTime CreatedOn { get; set; }

        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
