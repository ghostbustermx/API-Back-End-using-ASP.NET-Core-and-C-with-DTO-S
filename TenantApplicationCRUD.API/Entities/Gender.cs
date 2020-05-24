using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TenantApplicationCRUD.API.Entities
{
    public class Gender
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Do not enter more than 25 characters, 1 for minimum characters")]
        public virtual string Name { get; set; }
        public ICollection<TenantPersonnel> TenantPersonnels { get; set; }
            = new List<TenantPersonnel>();
    }
}
