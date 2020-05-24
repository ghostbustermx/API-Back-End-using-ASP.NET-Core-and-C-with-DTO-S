using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TenantApplicationCRUD.API.Entities
{
    public class TenantPersonnel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter a first name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Do not enter more than 50 characters, 1 for minimum characters")]
        public virtual string FirstName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Do not enter more than 50 characters, 1 for minimum characters")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Enter a last name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Do not enter more than 50 characters, 1 for minimum characters")]
        public virtual string LastName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Do not enter more than 50 characters, 1 for minimum characters")]
        public virtual string NickName { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual bool Active { get; set; }
        public virtual int PrefixId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }
    }
}
