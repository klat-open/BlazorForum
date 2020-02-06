using BlazorForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Models;

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
            return _context.ForumTopics.Where(p => p.ForumCategoryId == catId).ToList();
        }

        public async Task<List<ForumTopic>> GetForumTopicsLimitedAsync(int catId, int maxCount)
        {
            return _context.ForumTopics.ToList().Where(p => p.ForumCategoryId == catId)
                .OrderByDescending(p => p.PostedDate).Take(maxCount).ToList();
        }

        public async Task<ForumTopic> GetForumTopic(int topicId)
        {
            return _context.ForumTopics.Where(p => p.ForumTopicId == topicId).FirstOrDefault();
        }

        public async Task<bool> PostNewTopicAsync(ForumTopic newTopic)
        {
            var topics = _context.ForumTopics;
            topics.Add(newTopic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
