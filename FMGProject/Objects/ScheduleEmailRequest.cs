using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMG_Project
{
    public class ScheduleEmailRequest
    {
      
        public int PartyId { get; set; } 
        public string AssetIdentifier { get; set; }
        public DateTime DateTimeScheduled { get; set; }
        public List<int> ContactIds { get; set; }

        
    }
}
