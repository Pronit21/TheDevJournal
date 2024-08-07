using DevBlogs.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevBlogs.Web.Data
{
    public class DevBlogDbContext : DbContext
    {
        public DevBlogDbContext(DbContextOptions<DevBlogDbContext> options) : base(options)
        {
        }

        public class BloggingContextFactory : IDesignTimeDbContextFactory<DevBlogDbContext>
        {
            public DevBlogDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DevBlogDbContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-J493CPQ\\SQLEXPRESS; Database=DevBlogDB; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=True");

                return new DevBlogDbContext(optionsBuilder.Options);
            }
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
