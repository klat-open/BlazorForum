using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Data;
using BlazorForum.Models;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageForumCategories
    {
        Task<List<ForumCategory>> GetForumCategoriesAsync();
        Task<ForumCategory> GetForumCategoryAsync(int categoryId);
    }

    public class ManageForumCategories : IManageForumCategories
    {
        private readonly ApplicationDbContext _context;

        public ManageForumCategories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumCategory>> GetForumCategoriesAsync() => await new Data.Repository.ForumCategories(_context).GetForumCategoriesAsync();

        public async Task<ForumCategory> GetForumCategoryAsync(int categoryId) => await new Data.Repository.ForumCategories(_context).GetForumCategory(categoryId);
    }
}
