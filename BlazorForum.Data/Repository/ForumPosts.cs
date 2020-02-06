using BlazorForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Models;

namespace BlazorForum.Data.Repository
{
    public class ForumPosts
    {
        private readonly ApplicationDbContext _context;

        public ForumPosts(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumPost>> GetTopicPosts(int topicId)
        {
            return _context.ForumPosts.Where(p => p.ForumTopicId == topicId).ToList();
        }

        public async Task<bool> AddNewPostAsync(ForumPost newPost)
        {
            var posts = _context.ForumPosts;
            posts.Add(newPost);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
