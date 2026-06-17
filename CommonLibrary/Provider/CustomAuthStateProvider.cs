using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace CommonLibrary.Provider
{

    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        private ClaimsPrincipal _currentUser;

        public CustomAuthStateProvider()
        {
            _currentUser = _anonymous;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void MarkUserAsAuthenticated(string username, List<string> roles)
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username)
            }, "CustomAuth");

            // 將多個角色依序加入至 Claims 中
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }

        public void MarkUserAsLoggedOut()
        {
            _currentUser = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
}