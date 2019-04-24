using QuizzicalFBLA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizzicalFBLA.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Authenticate();
        void Logout();
        AuthenticationResult AuthenticationResult { get; }
    }
}
