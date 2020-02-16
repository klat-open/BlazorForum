using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorForum.Models
{
    public class Theme
    {
        public int ThemeId { get; set; }

        public bool IsSelected { get; set; }

        [Required]
        [MaxLength(50)]
        public string TextDomain { get; set; }
    }
}
