using hackatonbb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackatonbb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Abiturient> Abiturients { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CreditCardProfile> creditCardProfiles { get; set; }
        public DbSet<EventLevel> EventLevels { get; set; }
        public DbSet<EventRole> EventRoles{ get; set; }
        public DbSet<Faculty> Faculties{ get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestCourse> GuestsCources { get; set; }
        public DbSet<Privelege> Priveleges { get; set; }
        public DbSet<Priveleges2Abiturients> Priveleges2Abiturients  { get; set; }
        public DbSet<Priveleges2Students> Priveleges2Students { get; set; }
        public DbSet<RaitingTimeStamp> RaitingTimeStamps { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<Sphere> Spheres { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}