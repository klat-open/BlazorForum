using BlazorForum.Data;
using BlazorForum.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageForumTopics
    {
        Task<List<ForumTopic>> GetForumTopicsAsync(int categoryId);
        Task<List<ForumTopic>> GetForumTopicsLimitedAsync(int categoryId, int maxCount);

        Task<ForumTopic> GetForumTopicAsync(int topicId);
        Task<bool> PostNewTopicAsync(ForumTopic newTopic);
    }

    public class ManageForumTopics : IManageForumTopics
    {
        private readonly ApplicationDbContext _context;

        public event Action OnChange;

        public ManageForumTopics(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumTopic>> GetForumTopicsAsync(int categoryId) => 
            await new Data.Repository.ForumTopics(_context).GetForumTopicsAsync(categoryId);

        public async Task<List<ForumTopic>> GetForumTopicsLimitedAsync(int categoryId, int maxCount) =>
            await new Data.Repository.ForumTopics(_context).GetForumTopicsLimitedAsync(categoryId, maxCount);

        public async Task<ForumTopic> GetForumTopicAsync(int topicId) => 
            await new Data.Repository.ForumTopics(_context).GetForumTopic(topicId);

        public async Task<bool> PostNewTopicAsync(ForumTopic newTopic) => 
            await new Data.Repository.ForumTopics(_context).PostNewTopicAsync(newTopic);
    }
}
