using Bloggie.Data;
using Bloggie.Migrations;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext _context;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        //public AddBlogPost EditBlogPost;

        public EditModel(BloggieDbContext context)
        {
            _context = context;
        }

        
        public async Task OnGet(Guid id)
        {
            BlogPost =await  _context.BlogPosts.FindAsync(id);
        }

        public async Task<IActionResult> OnPostEdit() 
        {
            var existingBlogPost = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeatureImageUrl = BlogPost.FeatureImageUrl;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/Lists");
        }

        public async Task<IActionResult>  OnPostDelete()
        {
            var existingBlog = await _context.BlogPosts.FindAsync(BlogPost.Id);
            if (existingBlog != null)
            {
                _context.BlogPosts.Remove(existingBlog);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Admin/Blogs/lists");
            }
            return Page();
           
            
        }
    }
}
