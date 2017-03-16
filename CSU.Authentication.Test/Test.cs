
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
    using CSU.Authentication.General.Model;
    using Scopes.iLMS;

    class Test
    {
        static void Main(string[] args)
        {

            iLMS ilms = new iLMS("<account>","<password>");
            ilms.Login();

            /*
            ilms.Login(new Site
            {
                Target = "http://ilms.csu.edu.tw/sys/lib/ajax/login_submit.php",
                Parameters = new Parameters
                {
                    ["account"] = "40318223",
                    ["password"] = "S124791273",
                    ["secCode"] = "na",
                    ["stay"] = "1"
                }
            });*/

            Console.ReadKey();
        }
    }
}
