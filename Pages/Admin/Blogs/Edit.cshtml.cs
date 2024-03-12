using Bloggie.Data;
using Bloggie.Migrations;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository _context;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        //public AddBlogPost EditBlogPost;

        public EditModel(IBlogPostRepository context)
        {
            _context = context;
        }

        
        public async Task OnGet(Guid id)
        {
            BlogPost = await _context.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit() 
        {
            await _context.UpdateAsync(BlogPost);
            return RedirectToPage("/Admin/Blogs/Lists");
        }

        public async Task<IActionResult>  OnPostDelete()
        {
            var deleted=await _context.DeleteAsync(BlogPost.Id);
            if (deleted)
            {
                return RedirectToPage("/Admin/Blogs/Lists");
            }
            return Page();
           
            
        }
    }
}
