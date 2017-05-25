using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            String s;
            s = null;
            sb.Append("Value: ");
            if (s != null) sb.Append(s);
            Console.WriteLine("sb: "+sb) ;

        }
    }
}
