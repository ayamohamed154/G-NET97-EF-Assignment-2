using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_2.models
{
    internal class Event
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxAttendees { get; set; }

        // Foreign Key & Navigation Property (1-to-Many with Organizer)
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;


    }
}
