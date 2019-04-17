using Auth0.OidcClient;
using QuizzicalFBLA.Config;
using QuizzicalFBLA.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.iOS.Services;

[assembly: Dependency(typeof(AuthenticationService))]
namespace QuizzicalFBLA.iOS.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private Auth0Client _auth0Client;

        public AuthenticationService()
        {
            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = Secrets.Auth0Domain,
                ClientId = Secrets.Auth0ClientId
            });
        }

        public AuthenticationResult AuthenticationResult { get; private set; }

        public async Task<AuthenticationResult> Authenticate()
        {
            var auth0LoginResult = await _auth0Client.LoginAsync(new { audience = Secrets.Auth0Audience });
            AuthenticationResult authenticationResult;

            if (!auth0LoginResult.IsError)
            {
                authenticationResult = new AuthenticationResult()
                {
                    AccessToken = auth0LoginResult.AccessToken,
                    IdToken = auth0LoginResult.IdentityToken,
                    UserClaims = auth0LoginResult.User.Claims
                };
            }
            else
                authenticationResult = new AuthenticationResult(auth0LoginResult.IsError, auth0LoginResult.Error);

            AuthenticationResult = authenticationResult;
            return authenticationResult;
        }
    }
}