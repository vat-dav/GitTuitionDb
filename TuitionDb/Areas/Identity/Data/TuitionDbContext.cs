using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TuitionDb.Models;

namespace TuitionDb.Areas.Identity.Data;

public class TuitionDbContext : IdentityDbContext<TuitionDbUser>
{
    public TuitionDbContext(DbContextOptions<TuitionDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
  
        builder.ApplyConfiguration(new TuitionDbUserEntityConfiguration());

    }

public DbSet<TuitionDb.Models.PplStudent> PplStudent { get; set; } = default!;

public DbSet<TuitionDb.Models.PplStaff> PplStaff { get; set; } = default!;

public DbSet<TuitionDb.Models.PplParent> PplParent { get; set; } = default!;

public DbSet<TuitionDb.Models.BatchSubject> ClassSubject { get; set; } = default!;

public DbSet<TuitionDb.Models.BatchStudent> ClassStudent { get; set; } = default!;

public DbSet<TuitionDb.Models.BatchFee> ClassFee { get; set; } = default!;

public DbSet<TuitionDb.Models.Batch> Class { get; set; } = default!;
}

internal class TuitionDbUserEntityConfiguration : IEntityTypeConfiguration<TuitionDbUser>
{
    void IEntityTypeConfiguration<TuitionDbUser>.Configure(EntityTypeBuilder<TuitionDbUser> builder)
    {
        // used 'l' as limit of length
        builder.Property(l => l.FirstName).HasMaxLength(35);
        builder.Property(l => l.LastName).HasMaxLength(35);
        builder.Property(l => l.StudentSchool).HasMaxLength(40);
   
    }

}