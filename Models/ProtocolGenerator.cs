using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace intelectah.Models
{
    public class ProtocolGenerator
    {
        public int randomNum()
        {
            Random rnd = new Random();
            int protocol = rnd.Next(1000000000, 1999999999);
            return protocol;
        }   
    }
}
