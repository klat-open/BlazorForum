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

        public async Task<ForumTopic> GetForumTopic(int topicId)
        {
            return await _context.ForumTopics.Where(p => p.ForumTopicId == topicId).FirstOrDefaultAsync();
        }

        public async Task<bool> PostNewTopicAsync(ForumTopic newTopic)
        {
            var topics = _context.ForumTopics;
            await topics.AddAsync(newTopic);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTopicAsync(ForumTopic editedTopic)
        {
            var topic = await _context.ForumTopics
                .Where(p => p.ForumTopicId == editedTopic.ForumTopicId).FirstOrDefaultAsync();
            if(topic != null)
            {
                topic.Title = editedTopic.Title;
                topic.TopicText = editedTopic.TopicText;
                topic.IsApproved = editedTopic.IsApproved;
                topic.Flags = editedTopic.Flags;
                topic.IsModeratorChanged = editedTopic.IsModeratorChanged;
                topic.EditedDate = editedTopic.EditedDate;
                topic.EditedBy = editedTopic.EditedBy;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteTopicAsync(int id)
        {
            var topics = _context.ForumTopics;
            var topic = await topics.Where(p => p.ForumTopicId == id).FirstOrDefaultAsync();
            var removed = topics.Remove(topic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
