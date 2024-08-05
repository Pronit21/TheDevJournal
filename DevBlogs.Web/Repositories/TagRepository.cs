using DevBlogs.Web.Data;
using DevBlogs.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevBlogs.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly DevBlogDbContext _devBlogDbContext; //private readonly field to talk to the database

        public TagRepository(DevBlogDbContext devBlogDbContext) 
        {
            _devBlogDbContext = devBlogDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await _devBlogDbContext.AddAsync(tag);
            await _devBlogDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await _devBlogDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                _devBlogDbContext.Tags.Remove(existingTag);
                await _devBlogDbContext.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _devBlogDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return _devBlogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await _devBlogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                //saveChanges
                await _devBlogDbContext.SaveChangesAsync();

                return existingTag;

            }
            
            return null;
        }
    }
}
