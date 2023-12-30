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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Employee>(entity =>
        {

            entity.HasKey(e => e.Guid)
                .HasName("PRIMARY");

            entity.ToTable("employee");

            entity.UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Guid)
                .HasMaxLength(36)
                .HasColumnName("guid");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");

            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Guid)
                .HasName("PRIMARY");

            entity.ToTable("vendor");

            entity.UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ApprovedBy, "vendor_FK_1");

            entity.Property(e => e.Guid)
                .HasMaxLength(36)
                .HasColumnName("guid");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("company_name");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");

            entity.Property(e => e.CompanyEmail)
                .HasMaxLength(50)
                .HasColumnName("company_email");

            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.Property(e => e.Photo).HasColumnName("photo");

            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");

            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");

            entity.Property(e => e.IsApproved).HasColumnName("is_approved");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(36)
                .HasColumnName("approved_by");

            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

            entity.Property(e => e.BusinessField)
                .HasMaxLength(50)
                .HasColumnName("business_field");

            entity.Property(e => e.BusinessType)
                .HasMaxLength(50)
                .HasColumnName("business_type");

            entity.HasOne(d => d.EmployeeNavigation)
                .WithMany(p => p.Vendors)
                .HasForeignKey(d => d.ApprovedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("vendor_FK_1");
        });
    }
}
