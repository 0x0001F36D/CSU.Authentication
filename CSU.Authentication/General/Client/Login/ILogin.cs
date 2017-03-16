
namespace CSU.Authentication.General.Client.Login
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;
    using Status;
    
    public interface ILogin : IReadOnlyDictionary<string,Site>
    {
        void Add(string key, Site site);
        bool Remove(string key);

        bool IsLogin { get; }

        IStatus Login();

        IStatus Logout();
    }
}
