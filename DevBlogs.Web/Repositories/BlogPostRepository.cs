using DevBlogs.Web.Data;
using DevBlogs.Web.Models.Domain;

namespace DevBlogs.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DevBlogDbContext devBlogDbContext;

        public BlogPostRepository(DevBlogDbContext devBlogDbContext) 
        {
            this.devBlogDbContext = devBlogDbContext;
        }
        public Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
