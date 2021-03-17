using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorAO.App.Components
{
    /// <summary>
    /// idea from https://www.ripteq.com.au/blog/blazor-code-behinds-and-base-classes
    /// help from https://docs.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-5.0#expose-the-authentication-state-as-a-cascading-parameter
    /// </summary>
    public class AuthComponent : ComponentBase
    {        
        public AuthComponent()
        {            
        }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public ClaimsPrincipal User { get; private set; }

        public bool IsLoggedIn { get => User?.Identity.IsAuthenticated ?? false; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var state = await authenticationStateTask;
            User = state.User;
        }
    }
}
