
namespace CSU.Authentication.Scopes.iLMS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using General.Status;
    using General.Client;
    using General.Model;

    public class iLMS : AuthClient
    {
        public iLMS(string account , string password)
        {
            this.Add(nameof(this.Login), new Site
            {
                Target = "http://ilms.csu.edu.tw/sys/lib/ajax/login_submit.php",
                Parameters = new Parameters
                {
                    ["account"] = account,
                    ["password"] = password,
                    ["secCode"] = "na",
                    ["stay"] = "1"
                }
            });

            this.Add(nameof(this.Logout), new Site
            {
                Target = "http://ilms.csu.edu.tw/sys/lib/ajax/logout.php",
            });
        }

        public override bool IsLogin
        {
            get
            {
                throw new NotImplementedException();
            }

            protected set
            {
                throw new NotImplementedException();
            }
        }

        public override IStatus Login()
        {
            var respond = this.PostAsync(this[nameof(Login)]).Result;


            return null;
        }

        public override IStatus Logout()
        {
            throw new NotImplementedException();
        }
    }
}
