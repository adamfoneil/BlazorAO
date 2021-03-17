using AO.Models.Interfaces;
using AO.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorAO.Models
{
    public class UserProfile : UserProfileBase, ITenantUser<int>, IUserBaseWithRoles
    {
        public int? WorkspaceId { get; set; }        

        public int TenantId => WorkspaceId ?? 0;

        public HashSet<string> Roles { get; set; }

        public bool HasRole(string roleName) => Roles?.Contains(roleName) ?? false;

        public bool HasAnyRole(params string[] roleNames) => roleNames?.Any(role => HasRole(role)) ?? false;
    }
}
