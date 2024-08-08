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
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

                var optionsBuilder = new DbContextOptionsBuilder<DevBlogDbContext>();
                var connectionString = configuration.GetConnectionString("DevBlog");
                optionsBuilder.UseSqlServer(connectionString);

                return new DevBlogDbContext(optionsBuilder.Options);
            }
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
