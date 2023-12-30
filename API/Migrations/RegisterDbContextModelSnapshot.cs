﻿// <auto-generated />
using System;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(RegisterDbContext))]
    partial class RegisterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("role");

                    b.HasKey("Guid")
                        .HasName("PRIMARY");

                    b.ToTable("employee", (string)null);

                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_general_ci");
                });

            modelBuilder.Entity("API.Entities.Vendor", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("guid");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("ApprovedBy")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("approved_by");

                    b.Property<string>("BusinessField")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("business_field");

                    b.Property<string>("BusinessType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("business_type");

                    b.Property<string>("CompanyEmail")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("company_email");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("company_name");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_approved");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("phone");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("longblob")
                        .HasColumnName("photo");

                    b.HasKey("Guid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ApprovedBy" }, "vendor_FK_1");

                    b.ToTable("vendor", (string)null);

                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_general_ci");
                });

            modelBuilder.Entity("API.Entities.Vendor", b =>
                {
                    b.HasOne("API.Entities.Employee", "EmployeeNavigation")
                        .WithMany("Vendors")
                        .HasForeignKey("ApprovedBy")
                        .HasConstraintName("vendor_FK_1");

                    b.Navigation("EmployeeNavigation");
                });

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.Navigation("Vendors");
                });
#pragma warning restore 612, 618
        }
    }
}
