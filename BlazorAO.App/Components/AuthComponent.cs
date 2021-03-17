using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorAO.Components
{
    /// <summary>
    /// idea from https://www.ripteq.com.au/blog/blazor-code-behinds-and-base-classes
    /// </summary>
    public class AuthComponent : ComponentBase
    {        
        public AuthComponent()
        {            
        }

        [Inject]
        public AuthenticationStateProvider AuthState { get; set; }

        public ClaimsPrincipal User { get; private set; }

        public bool IsLoggedIn { get => User.Identity.IsAuthenticated; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var state = await AuthState.GetAuthenticationStateAsync();
            User = state.User;
        }
    }
}
