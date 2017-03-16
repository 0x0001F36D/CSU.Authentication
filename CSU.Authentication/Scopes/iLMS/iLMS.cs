
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
    using General.Extension;

    public class iLMS : AuthClient
    {
        public iLMS(string account, string password):base(Encoding.UTF8)
        {
            this.Headers.Add(System.Net.HttpRequestHeader.ContentType, "application/x-www-form-urlencoded; charset=UTF-8");

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
            var binding = respond.Bind(new
            {
                ret = new
                {
                    status = false,
                    divCode = 0,
                    divName = "",
                    email = "",
                    name = "",
                    phone = "",
                    info = "",
                    focus = "",
                    msg = ""
                }
            }).ret;

            if(binding.status)
            {
                return new Success<object>(binding);
            }
            else
            {
                return new Failure(binding.msg);
            }
            
        }

        public override IStatus Logout()
        {
            var o = this.PostAsync(this[nameof(Logout)]).Result
                .Bind(new
                {
                    ret = new
                    {
                        status = false,
                        msg = ""
                    }
                }).ret;
            if (o.status)
                return new Success();
            else
                return new Failure(o.msg);
        }
    }
}
