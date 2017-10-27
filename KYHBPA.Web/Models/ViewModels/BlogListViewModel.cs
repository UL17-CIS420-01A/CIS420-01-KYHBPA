using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class BlogListViewModel
    {
        public IList<Post> Posts { get; set; }

        public int TotalPosts { get; set; }
    }
}