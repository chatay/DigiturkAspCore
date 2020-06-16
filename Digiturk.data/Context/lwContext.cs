using System;
using Digiturk.data.Model;
using Microsoft.EntityFrameworkCore;

namespace Digiturk.data.Context
{
    public class LwContext:DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=Digiturk;User ID=postgres;password=159753;");

        }
         public DbSet<Users> Users { get; set; }
         public DbSet<Posts> Posts { get; set; }
         public DbSet<PostFiles> PostFiles { get; set; }
         public DbSet<PostImages> PostImages { get; set; }
         public DbSet<PostTags> PostTags { get; set; }
         public DbSet<Categories> Categories { get; set; }
         public DbSet<Languages> Languages { get; set; }
         public DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UsersId);
            });







            modelBuilder.Entity<Posts>(entity =>
             {
                 entity.HasKey(e => e.PostsId);


                 entity.HasOne(d => d.UsersNavigation)
                     .WithMany(p => p.Posts)
                     .HasForeignKey(d => d.UserId);

                 entity.HasOne(d => d.CategoriesNavigation)
                     .WithMany(p => p.Posts)
                     .HasForeignKey(d => d.CategoryId);

                 entity.HasOne(d => d.LanguagesNavigation)
                     .WithMany(p => p.Posts)
                     .HasForeignKey(d => d.LanguagesId);

             });

             modelBuilder.Entity<PostFiles>(entity =>
             {



                 entity.HasOne(d => d.PostsNavigation)
                     .WithMany(p => p.PostFiles)
                     .HasForeignKey(d => d.PostId);

                 entity.HasOne(d => d.FilesNavigation)
                     .WithMany(p => p.PostFiles)
                     .HasForeignKey(d => d.FileId);
             });

             modelBuilder.Entity<PostImages>(entity =>
             {


                 entity.HasOne(d => d.PostsNavigation)
                     .WithMany(p => p.PostImages)
                     .HasForeignKey(d => d.PostId);
             });

             modelBuilder.Entity<PostTags>(entity =>
             {


                 entity.HasOne(d => d.PostsNavigation)
                     .WithMany(p => p.PostTags)
                     .HasForeignKey(d => d.PostId);
             });

             modelBuilder.Entity<Categories>(entity =>
             {
                 entity.HasKey(e => e.CategoriesId);

                 entity.HasOne(d => d.LanguagesNavigation)
                     .WithMany(p => p.Categories)
                     .HasForeignKey(d => d.LangId);
             });



             modelBuilder.Entity<Languages>().HasData(new Languages
             {
                 LanguagesId = 1,
                 Name = "Türkçe",
                 ShortForm = "TR",
                 LanguageCode = "tr-TR",
                 FolderName = "default",
                 TextDirection = "ltr",
                 Status = 1,
                 LanguageOrder = 1
             });

            modelBuilder.Entity<Users>().HasData(new Users
             {
                 UsersId = 1,
                 Username = "hakannguzell",
                 Name = "Hakan",
                 Surname = "GÜZEL",
                 Slug = "",
                 Email = "hakan-guzel@outlook.com",
                 Password = "4gu2odw+hdNL35KMDZikog==",
                 Role = "admin",
                 UserType = "registered",
                 GoogleId = null,
                 FacebookId = null,
                 Avatar = null,
                 Status = true,
                 AboutMe = null,
                 LastSeen = DateTime.Now,
                 FacebookUrl = null,
                 TwitterUrl = null,
                 InstagramUrl = null,
                 PinterestUrl = null,
                 LinkedinUrl = null,
                 VkUrl = null,
                 YoutubeUrl = null,
                 ShowEmailOnProfile = 1,
                 CreatedAt = DateTime.Now
             });



             modelBuilder.Entity<Categories>().HasData(new Categories
             {
                 CategoriesId = 1,
                 LangId = 1,
                 Name = "Category Name",
                 Slug = "Slug",
                 Description = "Description (Meta Tag)",
                 Keywords = "Keywords (Meta Tag)",
                 ParentId = 0,
                 CategoryOrder = 1,
                 ShowOnMenu = 1,
                 CreatedAt = DateTime.Now
             }, new Categories
             {
                 CategoriesId = 2,
                 LangId = 1,
                 Name = "Category Name",
                 Slug = "Slug-If-you-leave-it-blank,-it-will-be-generated-automatically.",
                 Description = "Description (Meta Tag)",
                 Keywords = "Keywords (Meta Tag)",
                 ParentId = 1,
                 CategoryOrder = null,
                 ShowOnMenu = 1,
                 CreatedAt = DateTime.Now
             });


             modelBuilder.Entity<Files>().HasData(new Files
             {
                 FilesId = 1,
                 FileName = "profile-3424631.json"
             });


             modelBuilder.Entity<PostFiles>().HasData(new PostFiles
             {
                 PostId = 1,
                 FileId = 1
             });


             modelBuilder.Entity<PostImages>().HasData(new PostImages
             {
                 PostId = 1,
                 ImagePath = "uploads/images/image_750x_5ee780bcf0d16.jpg"
             });



             modelBuilder.Entity<Posts>().HasData(new Posts
             {
                 PostsId = 1,
                 LanguagesId = 1,
                 Title = "Title",
                 TitleSlug = "Slug",
                 Summary = "Summary & Description (Meta Tag)",
                 Content = "123",
                 Keywords = "Keywords (Meta Tag)",
                 UserId = 1,
                 CategoryId = 2,
                 ImageBig = "uploads/images/image_750x_5ee780bcf0d16.jpg",
                 ImageMid = "uploads/images/image_750x415_5ee780bd3e8f0.jpg",
                 ImageSmall = "uploads/images/image_100x75_5ee780bd7bca8.jpg",
                 ImageSlider = "uploads/images/image_650x433_5ee780bda2a35.jpg",
                 ImageMime = "jpg",
                 IsSlider = 0,
                 IsPicked = 0,
                 Hit = 0,
                 SliderOrder = 0,
                 OptionalUrl = "Optional Url",
                 PostType = "post",
                 VideoUrl = "",
                 VideoEmbedCode = "",
                 ImageUrl = "",
                 NeedAuth = 0,
                 Visibility = 1,
                 Status = 1,
                 CreatedAt = DateTime.Now
             });


             modelBuilder.Entity<PostTags>().HasData(new PostTags
             {
                 PostId = 1,
                 Tag = "Tags",
                 TagSlug = "tags"
             });

        }
        
       
    }
}