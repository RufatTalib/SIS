using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Persistance.Contexts
{
    public class SISDbContext : IdentityDbContext
    {
        public SISDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<LessonEvent> LessonEvents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
