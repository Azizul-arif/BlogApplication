using Bloggie.Data;
using Bloggie.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Pages.Admin.Blogs
{
    public class ListsModel : PageModel
    {
        private readonly BloggieDbContext _context;
        public List<BlogPost> BlogPosts { get; set; }

        public ListsModel(BloggieDbContext context)
        {
            _context = context;
        }

        
        public async Task OnGet()
        {
            BlogPosts = await _context.BlogPosts.ToListAsync();
        }
    }
}
