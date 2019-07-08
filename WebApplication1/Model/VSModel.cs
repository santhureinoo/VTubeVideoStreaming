namespace WebApplication1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VSModel : DbContext
    {
        public VSModel()
            : base("name=VSModel")
        {
        }

        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MoviesReview> MoviesReviews { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLibrary> UserLibraries { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cast>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cast>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<Cast>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Cast>()
                .HasMany(e => e.Movies)
                .WithMany(e => e.Casts)
                .Map(m => m.ToTable("MoviesCast").MapLeftKey("CastID").MapRightKey("MoviesID"));

            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Director)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Budget)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Production)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Histories)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.MoviesReviews)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Seasons)
                .WithMany(e => e.Movies)
                .Map(m => m.ToTable("Episode").MapLeftKey("MoviesID").MapRightKey("SeasonID"));

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.UserLibraries)
                .WithMany(e => e.Movies)
                .Map(m => m.ToTable("MoviesInLibrary").MapLeftKey("MoviesID").MapRightKey("LibraryID"));

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Movies)
                .Map(m => m.ToTable("MoviesTag").MapLeftKey("MoviesID").MapRightKey("TagID"));

            modelBuilder.Entity<MoviesReview>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Season>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Series>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Series>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Series>()
                .HasMany(e => e.Seasons)
                .WithRequired(e => e.Series)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Series>()
                .HasOptional(e => e.Series1)
                .WithRequired(e => e.Series2);

            modelBuilder.Entity<Series>()
                .HasOptional(e => e.Series11)
                .WithRequired(e => e.Series3);

            modelBuilder.Entity<Tag>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Histories)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MoviesReviews)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLibraries)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserLibrary>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Display)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
