using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotelyCore.Domain.Identity
{
    public  class ApplicationUser : IdentityUser
    {
        public bool IsCoolUser { get; set; }
    }
}
