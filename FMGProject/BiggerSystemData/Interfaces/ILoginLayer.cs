using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMG_Project.Data
{
    public interface ILoginLayer
    {
        public string GetLoginToken(string username, string password);

        public bool ValidateToken(string g);
    }
}
