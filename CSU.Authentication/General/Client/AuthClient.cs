namespace CSU.Authentication.General.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Status;
    using Login;
    using Model;

    public abstract class AuthClient : ILogin
    {
        private Dictionary<string,Site> sites;
        internal IntensifyClient Client;

        public WebHeaderCollection Headers
        {
            get
            {
                return this.Client.Headers;
            }
            set
            {
                this.Client.Headers = value;
            }
        }

        public abstract bool IsLogin { get; protected set; }

        public IEnumerable<string> Keys => this.sites.Keys;

        public IEnumerable<Site> Values => this.sites.Values;

        public int Count => this.sites.Count;

        public Site this[string key]=>this.sites[key];

        protected AuthClient(Encoding encoding) : this()
        {
            this.Client.Encoding = encoding;
        }

        protected AuthClient()
        {
            this.Client = new IntensifyClient();
            this.sites = new Dictionary<string ,Site>();
            this.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
        }

        #region GET

        protected async Task<string> GetAsync(string targetSite)
            => await this.Client.GetAsync(targetSite);

        protected async Task<string> GetAsync(string targetSite, Parameters parameters)
            => await this.Client.GetAsync(targetSite, parameters);

        protected async Task<string> GetAsync(Site site)
            => await this.GetAsync(site.Target, site.Parameters);

        #endregion

        #region POST

        protected async Task<string> PostAsync(string targetSite, Parameters parameters)
            => await this.Client.PostAsync(targetSite, parameters);

        protected async Task<string> PostAsync(Site site)
            => await this.PostAsync(site.Target, site.Parameters);

        #endregion

        public abstract IStatus Login();
        public abstract IStatus Logout();

        public bool ContainsKey(string key) => this.sites.ContainsKey(key);

        public bool TryGetValue(string key, out Site value) => this.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<string, Site>> GetEnumerator() => this.sites.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Add(string key, Site site)=>this.sites.Add(key, site);
        

        public bool Remove(string key)=>this.sites.Remove(key);
        
    }
}
