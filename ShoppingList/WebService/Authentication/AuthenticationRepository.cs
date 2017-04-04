using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebService.Authentication
{
    public class AuthenticationRepository : IDisposable
    {
        private AuthenticationContext context;

        private UserManager<IdentityUser>

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}