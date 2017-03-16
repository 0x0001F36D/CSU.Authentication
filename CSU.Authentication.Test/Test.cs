
namespace CSU.Authentication.Test
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Scopes.iLMS;
    using General.Extension;

    class Test
    {
        static void Main(string[] args)
        {

            iLMS ilms = new iLMS(null,null);
            var o =  ilms.Login();

            foreach (var item in o.Reflect())
            { 
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
