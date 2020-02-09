using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Data;
using BlazorForum.Models;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageForums
    {
        Task<List<Forum>> GetForumsAsync();
        Task<Forum> GetForumAsync(int id);
        Task<bool> CreateForumAsync(Forum newForum);
    }

    public class ManageForums : IManageForums
    {
        private readonly ApplicationDbContext _context;
        public ManageForums(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Forum>> GetForumsAsync() => 
            await new Data.Repository.Forums(_context).GetForumsAsync();

        public async Task<Forum> GetForumAsync(int id) => 
            await new Data.Repository.Forums(_context).GetForumAsync(id);

        public async Task<bool> CreateForumAsync(Forum newForum) => 
            await new Data.Repository.Forums(_context).CreateForumAsync(newForum);
    }
}
