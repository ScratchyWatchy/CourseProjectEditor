using WebApplication1.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
public class ApplicationDbContext : IdentityDbContext
{
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<DiagramEditor> DiagramEditors { get; set; }
    }
}
 
