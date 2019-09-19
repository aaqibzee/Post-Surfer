using Microsoft.EntityFrameworkCore;
using Post_Surfer.Data;
using Post_Surfer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Services
{
    public class PostService : IPostService
    {

        private readonly ApplicationDbContext _datacontext;
        public PostService(ApplicationDbContext datacontext )
        {
            _datacontext = datacontext;
        }

        public async Task <List<Post>> GetAllAsync()
        {
            return await _datacontext.Posts.ToListAsync();
        }
        public async Task<Post> GetPostByIdAsync(Guid Id)
        {
            return await (_datacontext.Posts.FirstOrDefaultAsync(x => x.Id == Id));
        }
        public async Task<bool> CreatePostAsync(Post post)
        {
            _datacontext.Posts.AddAsync(post);
            var created = await _datacontext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeletePostAsync(Guid Id)
        {
            var _post = await GetPostByIdAsync(Id);
            if (_post == null)
                return false;
            var deleted =_datacontext.Posts.Remove(_post);
            await _datacontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePostAsync(Post post) 
        {
            _datacontext.Posts.Update(post);
            var upgradedCount = await _datacontext.SaveChangesAsync();
            return upgradedCount > 0;
        }
    }
}
