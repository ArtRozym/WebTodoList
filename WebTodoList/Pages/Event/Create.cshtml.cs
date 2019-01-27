using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTodoList.Models;

namespace WebTodoList.Pages.Event
{
    public class CreateModel : PageModel
    {
        private readonly WebTodoListContext _context;
        [BindProperty]
        public WebTodoList.Models.Event Events { get; set; }
        public CreateModel(WebTodoListContext db)
        {
            _context = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                _context.Events.Add(Events);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}