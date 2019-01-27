using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebTodoList.Models;

namespace WebTodoList.Pages.Event
{
    public class IndexModel : PageModel
    {
        private readonly WebTodoListContext _context;
        public List<WebTodoList.Models.Event> Event { get; set; }

        public IndexModel(WebTodoListContext db)
        {
            _context = db;
        }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.AsNoTracking().ToListAsync();
        }


        //обрабатывает запросы post и который принимает id объекта на удаление
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var event = await _context.Events.FindAsync(id);

            if(event != null)
            {
                _context.Events.Remove(event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();

        }

        /*public void OnGet()
        {
            Event = _context.Events.AsNoTracking().ToList();
        }*/
    }
}