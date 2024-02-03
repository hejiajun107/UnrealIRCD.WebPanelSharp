using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using UnrealIRCD.WebPanelSharp.Data.Entity;

namespace UnrealIRCD.WebPanelSharp.Data
{
    public class ApplicationDataContext: DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysUser>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<SysUser>().HasData(new SysUser { Id = 1, Name = "root", Password = "password" });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SysUser> SysUsers { get; set; } 
    }
}
