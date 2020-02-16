using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorForum.Models
{
    public class ThemeInfo
    {
        public string ThemeName { get; set; }
        public string TextDomain { get; set; }
        public string ThemeUri { get; set; }
        public string Author { get; set; }
        public string AuthorUri { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
}
