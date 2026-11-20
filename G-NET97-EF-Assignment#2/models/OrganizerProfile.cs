using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_2.models
{
    internal class OrganizerProfile
    {
        public int Id { get; set; }
        public string? Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        // Foreign Key & Navigation Property (1-to-1 with Organizer)
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;

    }
}
