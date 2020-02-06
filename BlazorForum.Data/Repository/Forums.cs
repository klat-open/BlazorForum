using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Models;

namespace BlazorForum.Data.Repository
{
    public class Forums
    {
        private readonly ApplicationDbContext _context;

        public Forums(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Forum>> GetForumsAsync()
        {
            var forums = _context.Forums.ToList();

            foreach (var forum in forums)
            {
                forum.ForumCategories = new ForumCategories(_context).GetForumCategoriesAsync()
                    .Result
                    .Where(p => p.ForumId == forum.ForumId).ToList();
            }

            return forums;
        }
    }
}
