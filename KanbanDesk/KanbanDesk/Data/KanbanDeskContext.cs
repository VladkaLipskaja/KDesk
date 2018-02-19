using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KanbanDesk.Models
{
    public class KanbanDeskContext : DbContext
    {
        public KanbanDeskContext (DbContextOptions<KanbanDeskContext> options)
            : base(options)
        {
        }

        public DbSet<KanbanDesk.Models.Goals> Goals { get; set; }
    }
}
