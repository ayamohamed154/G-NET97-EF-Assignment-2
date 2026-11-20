using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_2.models
{
    internal class Badge
    {
        public int Id { get; set; }
        public string CredentialNumber { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        // Foreign Key & Navigation Property (1-to-1 with Attendee)
        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;


    }
}
