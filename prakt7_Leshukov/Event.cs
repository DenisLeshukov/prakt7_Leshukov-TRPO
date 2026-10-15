using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt7_Leshukov
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Location { get; set; } = null!;

        public DateTime EventDate { get; set; }

        public decimal TicketPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
