using Microsoft.AspNetCore.Identity;
using SIS.Domain.Enumerations;
using SIS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Domain.Entities
{
    public class AppUser: IdentityUser
    {
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentityRoleName { get; set; }
        public DateTime? BirthDate { get; set; }
		public Gender? Gender { get; set; }
		public string? ImageSrc { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public string? JobDescription { get; set; }

		public List<Blog>? Blogs { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public List<Group> Groups { get; set; }

        // Teacher properties
        public int? ClassNumber { get; set; }
        public string? Qualification { get; set; }
        public int? Experience { get; set; }
        public List<Subject>? Subjects { get; set; }

        // Student properties
        public List<Attendance> Attendances { get; set; }


    }
}
