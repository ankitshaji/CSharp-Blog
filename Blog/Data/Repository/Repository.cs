using Blog.Models;
using Blog.Models.Comments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Post.Add(post);
        }

        public void AddSubComment(SubComment comment)
        {
            _ctx.SubComments.Add(comment);
        }

        public List<Post> GetAllPost()
        {
            return _ctx.Post.ToList();
        }
        public List<Post> GetAllPost(string caregory)
        {
            return _ctx.Post
                .Where(post => post.Caregory.ToLower().Equals(caregory.ToLower()))
                .ToList();
        }

        public Post GetPost(int id)
        {

            return _ctx.Post
                .Include(p => p.MainComments)
                .ThenInclude(mc => mc.SubComments)
                .FirstOrDefault(p => p.Id ==id);
        }

        public void RemovePost(int id)
        {
            _ctx.Post.Remove(GetPost(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync()>0) 
            {
                return true;
            }
            return false;
        }

        public void UpdatePost(Post post)
        {
            _ctx.Post.Update(post);
        }
    }
}
