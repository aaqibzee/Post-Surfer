using Post_Surfer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Surfer.Services
{
   public interface IPostService
    {
        Task<bool> CreatePostAsync(Post post);
        Task<bool> DeletePostAsync(Guid Id);
        Task<List<Post>> GetAllAsync();
        Task<Post> GetPostByIdAsync(Guid Id); 
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> UserOwnsPostAsync(Guid id, string getUserId);
    }
}
