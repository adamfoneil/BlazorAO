using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class WorkspaceUserPermissionsResult
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public string Name { get; set; }
    }

    public class WorkspaceUserPermissions : TestableQuery<WorkspaceUserPermissionsResult>
    {
        public WorkspaceUserPermissions() : base(
            @"SELECT
                [wup].[UserId],
                [wup].[PermissionId],
                [p].[Name]
            FROM
                [dbo].[WorkspaceUserPermission] [wup]
                INNER JOIN [dbo].[Permission] [p] ON [wup].[PermissionId]=[p].[Id]
            WHERE
                [wup].[WorkspaceId]=@workspaceId
            ORDER BY
                [p].[Name]")
        {
        }

        public int WorkspaceId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new WorkspaceUserPermissions() { WorkspaceId = 1 };
        }
    }
}
