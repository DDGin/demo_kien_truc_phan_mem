using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Fine> Fines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .ToTable(t => t.HasCheckConstraint(
                    "CK_Book_Quantity",
                    "[QuantityAvailable] <= [QuantityTotal]"
                ));

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.Fine)
                .WithOne(f => f.Borrow)
                .HasForeignKey<Fine>(f => f.BorrowId);

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.Reader)
                .WithMany(u => u.ReaderBorrows)
                .HasForeignKey(b => b.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Borrow>()
                .HasOne(b => b.Librarian)
                .WithMany(u => u.LibrarianBorrows)
                .HasForeignKey(b => b.LibrarianId)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
