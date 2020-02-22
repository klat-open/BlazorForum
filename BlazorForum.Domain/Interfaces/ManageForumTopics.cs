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
        Task<ForumTopic> GetForumTopicAsync(int topicId);
        Task<bool> PostNewTopicAsync(ForumTopic newTopic);
        Task<bool> DeleteForumTopicAsync(int id);
    }

    public class ManageForumTopics : IManageForumTopics
    {
        private readonly ApplicationDbContext _context;

        public ManageForumTopics(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumTopic>> GetForumTopicsAsync(int categoryId) => 
            await new Data.Repository.ForumTopics(_context).GetForumTopicsAsync(categoryId);

        public async Task<ForumTopic> GetForumTopicAsync(int topicId) => 
            await new Data.Repository.ForumTopics(_context).GetForumTopic(topicId);

        public async Task<bool> PostNewTopicAsync(ForumTopic newTopic) => 
            await new Data.Repository.ForumTopics(_context).PostNewTopicAsync(newTopic);

        public async Task<bool> DeleteForumTopicAsync(int id) =>
            await new Data.Repository.ForumTopics(_context).DeleteTopicAsync(id);
    }
}
