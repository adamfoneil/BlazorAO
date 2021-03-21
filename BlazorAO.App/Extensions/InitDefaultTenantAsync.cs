using BlazorAO.Models;
using Dapper.CX.SqlServer.Services;
using System.Threading.Tasks;

namespace BlazorAO.App.Extensions
{
    public static partial class DapperCXExtensions
    {
        /// <summary>
        /// In a multi-tenant app, users would have processes for joining and leaving a tenant.
        /// For this sample app intended to run locally, we can generate a sample tenant and assume the user always belongs to it.
        /// In this app, a tenant is a "Workspace"
        /// </summary>
        public static async Task InitDefaultTenantAsync(this DapperCX<int, UserProfile> data)
        {
            if (data.HasUser && !data.User.WorkspaceId.HasValue)
            {
                // find or create default workspace
                var wsId = await data.MergeAsync(new Workspace()
                {
                    Name = "Default Workspace"
                });

                // add current user if not there already
                await data.MergeAsync(new WorkspaceUser()
                {
                    WorkspaceId = wsId,
                    UserId = data.User.UserId                    
                });

                // set the current workspace on the user profile row
                data.User.WorkspaceId = wsId;
                await data.UpdateUserAsync(field => field.WorkspaceId);
            }
        }
    }
}
