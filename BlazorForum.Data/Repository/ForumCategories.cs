using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Models;

namespace BlazorForum.Data.Repository
{
    public class ForumCategories
    {
        private readonly ApplicationDbContext _context;

        public ForumCategories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumCategory>> GetForumCategoriesAsync()
        {
            return _context.ForumCategories.ToList();
        }

        public async Task<ForumCategory> GetForumCategory(int categoryId)
        {
            return _context.ForumCategories.Where(p => p.ForumCategoryId == categoryId).FirstOrDefault();
        }
    }
}
