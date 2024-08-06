using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Persistence
{
    public sealed class BooksDbContext : DbContext
    {
        public BooksDbContext() { }
        public BooksDbContext(DbContextOptions<BooksDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(builder =>
            {
                builder.ToTable("Author");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Name).HasMaxLength(40).HasColumnType("varchar(40)");

                builder.HasMany(p => p.Books);
            });

            modelBuilder.Entity<Book>(builder =>
            {
                builder.ToTable("Book");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Title).HasMaxLength(40).HasColumnType("varchar(40)");

                builder.Property(p => p.Publisher).HasMaxLength(40).HasColumnType("varchar(40)");

                builder.Property(p => p.Edition);

                builder.Property(p => p.PublicationYear);

                builder.HasMany(p => p.Authors).WithMany(x => x.Books);

                builder
                    .HasMany(b => b.Authors)
                    .WithMany(a => a.Books)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookAuthor",
                        j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
                        j => j.HasOne<Book>().WithMany().HasForeignKey("BookId")
                    );

                builder
                    .HasMany(b => b.Subjects)
                    .WithMany(a => a.Books)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookSubject",
                        j => j.HasOne<Subject>().WithMany().HasForeignKey("SubjectId"),
                        j => j.HasOne<Book>().WithMany().HasForeignKey("BookId")
                    );

                builder.HasMany(p => p.Subjects);
                
                builder.HasMany(p => p.Prices);
            });

            modelBuilder.Entity<Subject>(builder =>
            {
                builder.ToTable("Subject");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Description).HasMaxLength(20).HasColumnType("varchar(20)"); ;

                builder.HasMany(p => p.Books);
            });

            modelBuilder.Entity<SaleType>(builder =>
            {
                builder.ToTable("SaleType");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Description).HasMaxLength(20).HasColumnType("varchar(20)"); ;

                builder.HasMany(p => p.Prices);
            });

            modelBuilder.Entity<Price>(builder =>
            {
                builder.ToTable("Price");

                builder.HasKey(p => new { p.BookId, p.SaleTypeId });

                builder.Property(p => p.BookId);

                builder.Property(p => p.SaleTypeId);

                builder.Property(p => p.Value);
            });
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<SaleType> SaleType { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}
