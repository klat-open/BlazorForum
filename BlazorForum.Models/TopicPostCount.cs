using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorForum.Models
{
    public class TopicPostCount
    {
        public int ParentItemId { get; set; }
        public int ChildCount { get; set; }
    }
}
