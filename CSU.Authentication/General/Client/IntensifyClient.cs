
namespace CSU.Authentication.General.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Collections.Specialized;
    using System.Web;
    using System.Net.NetworkInformation;
    using System.Threading;
    using Model;

    internal class IntensifyClient : WebClient
    {
        private CookieContainer cookies;
        public IntensifyClient()
        {
            this.cookies = new CookieContainer();
        }



        private string convertNVC2String(NameValueCollection nvc)
            => nvc == null ? string.Empty : string.Join("&", nvc.Cast<string>().Select(p => $"{p}={HttpUtility.UrlEncode(nvc[p])}"));

        internal async Task<IEnumerable<PingReply>> PingAsync(string targetSite)
            => await Task.Run(() =>
                        from adr in Dns.GetHostEntry(targetSite).AddressList
                        let ping = new Ping()
                        let ip = adr.MapToIPv4()
                        let _ = Task.Yield()
                        select ping.SendPingAsync(ip).Result);

        internal async Task<string> PostAsync(string targetSite, NameValueCollection param)
            => await this.UploadStringTaskAsync(targetSite, "POST", this.convertNVC2String(param));

        internal async Task<string> GetAsync(string targetSite)
            => await this.DownloadStringTaskAsync(targetSite);        

        internal async Task<string> GetAsync(string targetSite, NameValueCollection param)
            => await this.GetAsync(new StringBuilder()
                                    .Append(targetSite)
                                    .Append(param == null ? string.Empty : "?")
                                    .Append(this.convertNVC2String(param))
                                    .ToString());


        protected override WebRequest GetWebRequest(Uri address)
        {
            var req= base.GetWebRequest(address) as HttpWebRequest;
            if (req != null)
                req.CookieContainer = cookies;
            return req;
        }
    }
}
