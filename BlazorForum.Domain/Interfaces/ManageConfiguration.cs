using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Data;
using BlazorForum.Models;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageConfiguration
    {
        Configuration GetConfig();
        Task<Configuration> GetConfigAsync();
        Task<bool> UpdateConfigAsync(Configuration editedConfig);
    }

    public class ManageConfiguration : IManageConfiguration
    {
        private ApplicationDbContext _context;

        public ManageConfiguration(ApplicationDbContext context)
        {
            _context = context;
        }

        public Configuration GetConfig() => new Data.Repository.SiteConfiguration(_context).GetConfig();

        public async Task<Configuration> GetConfigAsync() => 
            await new Data.Repository.SiteConfiguration(_context).GetConfigAsync();

        public async Task<bool> UpdateConfigAsync(Configuration editedConfig) =>
            await new Data.Repository.SiteConfiguration(_context).UpdateConfigAsync(editedConfig);
    }
}
