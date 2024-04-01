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

public DbSet<TuitionDbv1.Models.Student> Students { get; set; } = default!;

public DbSet<TuitionDbv1.Models.Subject> Subjects { get; set; } = default!;

public DbSet<TuitionDbv1.Models.Staff> Staffs { get; set; } = default!;

public DbSet<TuitionDbv1.Models.BatchStudent> BatchStudents { get; set; } = default!;

public DbSet<TuitionDbv1.Models.BatchFee> BatchFee { get; set; } = default!;

public DbSet<TuitionDbv1.Models.Batch> Batches { get; set; } = default!;
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