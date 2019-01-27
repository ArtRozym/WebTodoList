using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebTodoList.Models
{
    public class WebTodoListContext : DbContext
    {
        public WebTodoListContext (DbContextOptions<WebTodoListContext> options)
            : base(options)
        {
        }

        public DbSet<WebTodoList.Models.Event> Events { get; set; }
    }
}
