using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanDesk.Models
{
    public class Goals
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int State { get; set; } //1- todo 2- doing 3 - done 

    }
}
