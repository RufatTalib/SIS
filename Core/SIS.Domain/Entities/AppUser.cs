using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public string? JobDescription { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? IdentityRoleName { get; set; }

    }
}
