using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class RebuildUserPermissions : TestableQuery<int>
    {
        public RebuildUserPermissions() : base(
            @"DELETE [wup] FROM [dbo].[WorkspaceUserPermission] [wup] 
            WHERE [UserId]=@userId AND [WorkspaceId]=@workspaceId;

            INSERT INTO [dbo].[WorkspaceUserPermission] (
                [WorkspaceId], [UserId], [PermissionId], [CreatedBy], [DateCreated]
            ) SELECT
                @workspaceId, @userId, [p].[Id], @userName, @localTime
            FROM
                [app].[Permission] [p]
            WHERE
                [p].[Id] IN @permissionIds")
        {
        }

        public int WorkspaceId { get; set; }
        public int UserId { get; set; }
        public int[] PermissionIds { get; set; }
        public string UserName { get; set; }
        public DateTime LocalTime { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new RebuildUserPermissions() 
            { 
                WorkspaceId = 1, 
                UserId = -1, 
                LocalTime = DateTime.Now, 
                UserName = "adamo",
                PermissionIds = new int[] { -1, -2, -3 }
            };
        }
    }
}
