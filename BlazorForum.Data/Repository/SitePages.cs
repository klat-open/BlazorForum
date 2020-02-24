using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorForum.Models;

namespace BlazorForum.Data.Repository
{
    public class SitePages
    {
        private readonly ApplicationDbContext _context;

        public SitePages(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SitePage> GetIndexPageAsync()
        {
            await CreatePageIfNoneFound();
            return await _context.Pages.Where(p => p.IsIndex == true).FirstOrDefaultAsync();
        }

        public async Task<SitePage> GetPageAsync(int pageId)
        {
            return await _context.Pages.Where(p => p.SitePageId == pageId).FirstOrDefaultAsync();
        }

        public async Task<List<SitePage>> GetPagesAsync()
        {
            return await _context.Pages.ToListAsync();
        }

        public async Task<bool> UpdatePageAsync(SitePage editedPage)
        {
            var page = await _context.Pages.Where(p => p.SitePageId == editedPage.SitePageId).FirstOrDefaultAsync();
            if(page != null)
            {
                page.Title = editedPage.Title;
                page.MainContent = editedPage.MainContent;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private async Task CreatePageIfNoneFound()
        {
            // This is mostly used for the very first page visit after a fresh install.
            var pages = await _context.Pages.ToListAsync();
            if(pages.Count == 0)
            {
                var page = new SitePage
                {
                    Title = "Welcome",
                    MainContent = "<p>Welcome to my new BlazorForum website! BlazorForum is an open source " +
                    "forum app built in Blazor. The code can be found on the GitHub repository " +
                    "at <a href=\"https://github.com/ElliottBrand/BlazorForum\" target=\"_blank\">" +
                    "https://github.com/ElliottBrand/BlazorForum</a>.</p>",
                    IsIndex = true,
                    AllowDelete = false
                };
                await _context.Pages.AddAsync(page);
                await _context.SaveChangesAsync();
            }
        }
    }
}
