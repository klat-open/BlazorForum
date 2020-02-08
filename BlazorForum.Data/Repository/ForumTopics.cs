using BlazorForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorForum.Data.Repository
{
    public class ForumTopics
    {
        private readonly ApplicationDbContext _context;

        public ForumTopics(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumTopic>> GetForumTopicsAsync(int catId)
        {
            return await _context.ForumTopics.Where(p => p.ForumCategoryId == catId).ToListAsync();
        }

        public async Task<List<ForumTopic>> GetForumTopicsLimitedAsync(int catId, int maxCount)
        {
            return await _context.ForumTopics.Where(p => p.ForumCategoryId == catId)
                .OrderByDescending(p => p.PostedDate).Take(maxCount).ToListAsync();
        }

        public async Task<ForumTopic> GetForumTopic(int topicId)
        {
            return await _context.ForumTopics.Where(p => p.ForumTopicId == topicId).FirstOrDefaultAsync();
        }

        public async Task<bool> PostNewTopicAsync(ForumTopic newTopic)
        {
            var topics = _context.ForumTopics; // Not sure how to async this at the moment
            topics.Add(newTopic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
