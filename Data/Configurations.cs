using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class Configurations
    {
        public static string ConnectionString
        {
            get
            {
                return "data source=192.168.15.68; database=nwsltr; user id=Demo; password=Demo; Pooling=false; Connection Lifetime=10000;";
            }

            private set { }
        }
    }
}
