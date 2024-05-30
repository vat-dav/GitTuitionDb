using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TuitionDbv1.Areas.Identity.Data;
using TuitionDbv1.Models;
using TuitionDbv1.ViewModels;

namespace TuitionDb.Areas.Identity.Data
{
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

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<BatchStudent> BatchStudents { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<ViewBatchStudents> ViewBatchStudents { get; set; }
    }

    internal class TuitionDbUserEntityConfiguration : IEntityTypeConfiguration<TuitionDbUser>
    {
        void IEntityTypeConfiguration<TuitionDbUser>.Configure(EntityTypeBuilder<TuitionDbUser> builder)
        {
            // used 'l' as limit of length
            builder.Property(l => l.StaffPhone).HasMaxLength(15);
        }
    }
}
