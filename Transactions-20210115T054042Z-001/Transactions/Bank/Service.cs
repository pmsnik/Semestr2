using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Service
    {
        public uint UserID { get; }
        
        public double Funds { get; set; }

        public Service(uint id)
        {
            UserID = id;
        }
    }
}
