using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Notely.Persistence.Identity
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