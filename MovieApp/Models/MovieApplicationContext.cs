using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Models;

public partial class MovieApplicationContext : DbContext
{
    public MovieApplicationContext()
    {
    }

    public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options): base(options)
    {

    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<HomeScroll> HomeScrolls { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CATEGORY");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<HomeScroll>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HOME_SCROLL");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMG_URL");
            entity.Property(e => e.MovieUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MOVIE_URL");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("Login");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("MOVIES", tb =>
                {
                    tb.HasTrigger("UPDATE_SUGGESTION");
                    tb.HasTrigger("update_home_scroll");
                });

            entity.Property(e => e.MovieId).HasColumnName("MOVIE_ID");
            entity.Property(e => e.MovieBigImg).HasColumnName("MOVIE_BIG_IMG");
            entity.Property(e => e.MovieCategory).HasColumnName("MOVIE_CATEGORY");
            entity.Property(e => e.MovieDate).HasColumnName("MOVIE_DATE");
            entity.Property(e => e.MovieSmallImg).HasColumnName("MOVIE_SMALL_IMG");
            entity.Property(e => e.MovieTitle).HasColumnName("MOVIE_TITLE");
            entity.Property(e => e.MovieUrl).HasColumnName("MOVIE_URL");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("Subscription");
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SUGGESTI__3214EC270923338E");

            entity.ToTable("SUGGESTIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImgUrl).HasColumnName("IMG_URL");
            entity.Property(e => e.MovieUrl).HasColumnName("MOVIE_URL");
            entity.Property(e => e.Title).HasColumnName("TITLE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
