﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Capstone.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Week> Weeks { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<EventResponse> EventResponses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventViewModel> EventViewModels { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Student> Students { get; set; }
        
    }
}