using BlazorForum.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageThemes
    {
        Task<string> GetSelectedThemeNameAsync();
        Task<bool> RemoveThemesAsync();
        Task<bool> AddThemeAsync(string textDomain);
    }

    public class ManageThemes : IManageThemes
    {
        private readonly ApplicationDbContext _context;

        public string ThemeName { get; set; }

        public ManageThemes(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetSelectedThemeNameAsync() => 
            await new Data.Repository.Themes(_context).GetSelectedThemeNameAsync();

        public async Task<bool> RemoveThemesAsync() =>
            await new Data.Repository.Themes(_context).RemoveThemesAsync();

        public async Task<bool> AddThemeAsync(string textDomain) =>
            await new Data.Repository.Themes(_context).AddThemeAsync(textDomain);
    }
}
