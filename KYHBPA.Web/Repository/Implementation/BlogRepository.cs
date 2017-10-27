using System.Collections.Generic;
using System.Linq;
using KYHBPA.Models;

namespace KYHBPA.Repository.Implementation
{
    public class BlogRepository
    {
        private EntityDbContext _context = new EntityDbContext();

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _context.Posts
                                  .Where(p => p.Published != false)
                                  .OrderByDescending(p => p.PostedOn)
                                  .Skip(pageNo * pageSize)
                                  .Take(pageSize)
                                  //.Fetch(p => p.Category)
                                  .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _context.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  //.FetchMany(p => p.Tags)
                  .ToList();
        }

        public int TotalPosts()
        {
            return _context.Posts.Where(p => p.Published != false).Count();
        }
    }
}