using BlazorForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorForum.Data.Repository
{
    public class ForumPosts
    {
        private readonly ApplicationDbContext _context;

        public ForumPosts(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumPost>> GetForumPostsAsync(int topicId)
        {
            return await _context.ForumPosts.Where(p => p.ForumTopicId == topicId).ToListAsync();
        }

        public async Task<bool> AddNewPostAsync(ForumPost newPost)
        {
            var posts = _context.ForumPosts;
            await posts.AddAsync(newPost);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
