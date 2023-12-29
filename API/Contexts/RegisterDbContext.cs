using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts;

public partial class RegisterDbContext : DbContext
{
    public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<Vendor> Vendors { get; set; } = null!;

    
}
