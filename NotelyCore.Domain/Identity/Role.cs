using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotelyCore.Domain.Identity
{
    public class Role
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}