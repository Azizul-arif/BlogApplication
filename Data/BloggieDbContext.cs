using Bloggie.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Bloggie.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPost>BlogPosts { get; set; }
        public DbSet<Tag>Tags { get; set; }
    }
}
