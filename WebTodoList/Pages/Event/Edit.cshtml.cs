using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTodoList.Models;
using Microsoft.EntityFrameworkCore;

namespace WebTodoList.Pages.Event
{
    public class EditModel : PageModel
    {
        private readonly WebTodoListContext _context;

        [BindProperty]
        public WebTodoList.Models.Event Event { get; set; }

        public EditModel(WebTodoListContext db)
        {
            _context = db;
        }

        // через параметр получаем id события, по этому id получаем из базы данных события и передаем его на страницу Edit.cshtml
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            Event = await _context.Events.FindAsync(id);

            if(Event ==null)
            {
                return NotFound();
            }

            return Page();
        }

        //сохраняем изменения в базе данных и выполняем переадресацию на страницу Index
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.Events.Any(e=>e.ID==Event.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
            
        }

       /* public void OnGet()
        {

        }*/
    }
}