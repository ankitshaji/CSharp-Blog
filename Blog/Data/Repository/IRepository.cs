using Blog.Models;
using Blog.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPost();
        List<Post> GetAllPost(string Caregory);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        void AddSubComment(SubComment comment);

        Task<bool> SaveChangesAsync();
    }
}
