using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMG_Project
{
    public class ActionResult
    {
       public long? Id { get; set; }
       public string Error { get; set; }

        public bool Success
        {
            get
            {
                return Id.HasValue;
            }
            private set { }
        }

        public ActionResult(int id)
        {
            Id = id;
            Error = "";
        }

        public ActionResult(string error)
        {
            Error = error;
        }
    }
}
