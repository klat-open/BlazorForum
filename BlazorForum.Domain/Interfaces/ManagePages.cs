using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Data;
using BlazorForum.Models;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManagePages
    {
        Task<SitePage> GetIndexPageAsync();
        Task<List<SitePage>> GetPagesAsync();
        Task<SitePage> GetPageAsync(int pageId);
        Task<bool> UpdatePageAsync(SitePage editedPage);
    }

    public class ManagePages : IManagePages
    {
        private readonly ApplicationDbContext _context;

        public ManagePages(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SitePage> GetIndexPageAsync() => 
            await new Data.Repository.SitePages(_context).GetIndexPageAsync();

        public async Task<List<SitePage>> GetPagesAsync() =>
            await new Data.Repository.SitePages(_context).GetPagesAsync();

        public async Task<SitePage> GetPageAsync(int pageId) =>
            await new Data.Repository.SitePages(_context).GetPageAsync(pageId);

        public async Task<bool> UpdatePageAsync(SitePage editedPage) =>
            await new Data.Repository.SitePages(_context).UpdatePageAsync(editedPage);
    }
}
