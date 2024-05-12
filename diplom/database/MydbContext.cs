using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace books;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookGenre> BookGenres { get; set; }

    public virtual DbSet<BookLanguage> BookLanguages { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserBook> UserBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=qwe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor).HasName("Author_pkey");

            entity.ToTable("author");

            entity.Property(e => e.IdAuthor)
                .UseIdentityAlwaysColumn()
                .HasColumnName("idAuthor");
            entity.Property(e => e.NameAuthor).HasColumnName("nameAuthor");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_pkey");

            entity.ToTable("book");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Annotation)
                .HasMaxLength(5000)
                .HasColumnName("annotation");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Rating)
                .HasPrecision(19, 2)
                .HasColumnName("rating");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Votes).HasColumnName("votes");
            entity.Property(e => e.YearOfPublication).HasColumnName("yearOfPublication");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("book_author");

            entity.Property(e => e.Authorid).HasColumnName("authorid");
            entity.Property(e => e.Bookid).HasColumnName("bookid");

            entity.HasOne(d => d.Author).WithMany()
                .HasForeignKey(d => d.Authorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("authorid");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.Bookid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookid");
        });

        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("book_genre");

            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Genreid).HasColumnName("genreid");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.Bookid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookid");

            entity.HasOne(d => d.Genre).WithMany()
                .HasForeignKey(d => d.Genreid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("genreid");
        });

        modelBuilder.Entity<BookLanguage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("book_language");

            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Languageid).HasColumnName("languageid");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.Bookid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bookid");

            entity.HasOne(d => d.Language).WithMany()
                .HasForeignKey(d => d.Languageid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("languageid");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genre_pkey");

            entity.ToTable("genre");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.NameGenre).HasColumnName("nameGenre");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("language_pkey");

            entity.ToTable("language");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.NameLanguage).HasColumnName("nameLanguage");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<UserBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_book");

            entity.HasIndex(e => e.Bookid, "fki_bookid");

            entity.HasIndex(e => e.Userid, "fki_userid");

            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.FavoriteBook).HasColumnName("favoriteBook");
            entity.Property(e => e.RatingUser)
                .HasPrecision(19, 2)
                .HasColumnName("ratingUser");
            entity.Property(e => e.Review)
                .HasMaxLength(255)
                .HasColumnName("review");
            entity.Property(e => e.ToRead).HasColumnName("toRead");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.WasResd).HasColumnName("wasResd");

            entity.HasOne(d => d.Book).WithMany()
                .HasForeignKey(d => d.Bookid)
                .HasConstraintName("bookid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
