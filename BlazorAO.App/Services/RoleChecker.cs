using BlazorAO.App.Models;
using BlazorAO.Models;
using Dapper.CX.SqlServer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System.Linq;

namespace BlazorAO.App.Services
{
    public class RoleChecker
    {
        private readonly NavigationManager _navManager;
        private readonly DapperCX<int, UserProfile> _data;
        private readonly RoleCheckerOptions _options;

        public RoleChecker(
            NavigationManager navigationManager,
            DapperCX<int, UserProfile> data,
            IOptions<RoleCheckerOptions> options)
        {
            _navManager = navigationManager;
            _data = data;
            _options = options.Value;
        }

        public void RequireAny(params string[] roleNames)
        {
            if (!HasAny(roleNames))
            {
                string required = string.Join(",", roleNames);
                _navManager.NavigateTo($"{_options.AccessDeniedRoute}?roles={required}");
            }
        }

        public bool HasAny(params string[] roleNames) => _data.User.Roles.Intersect(roleNames).Any();
    }
}
