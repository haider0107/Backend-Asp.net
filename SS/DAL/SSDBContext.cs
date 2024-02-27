using BOL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SSDBContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-QG8P7KSH\\SQLEXPRESS;Initial Catalog=SSUser;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        // data source=LAPTOP-QG8P7KSH\SQLEXPRESS;initial catalog=master;trusted_connection=true
        public DbSet<Story>? Stories { get; set; }
    }
}
