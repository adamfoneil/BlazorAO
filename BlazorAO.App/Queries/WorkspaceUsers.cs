using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class WorkspaceUsersResult
    {
        public int WorkspaceId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
    }

    public class WorkspaceUsers : TestableQuery<WorkspaceUsersResult>
    {
        public WorkspaceUsers() : base(
            @"SELECT
                [wu].[WorkspaceId],
                [u].[UserId],
                [u].[UserName],
                [u].[Email],
                [u].[FirstName],
                [u].[LastName],
                [wu].[ManagerId],
                [mgr].[LastName] + ', ' + [mgr].[FirstName] AS [ManagerName],
                [wu].[IsActive],
                [wu].[Id]
            FROM
                [dbo].[AspNetUsers] [u]
                INNER JOIN [dbo].[WorkspaceUser] [wu] ON [u].[UserId]=[wu].[UserId]
                LEFT JOIN [dbo].[AspNetUsers] [mgr] ON [wu].[ManagerId]=[mgr].[UserId]
            WHERE
                [wu].[WorkspaceId]=@workspaceId {andWhere}
            ORDER BY
                [u].[LastName], [u].[FirstName]")
        {
        }

        public int WorkspaceId { get; set; }

        [Where("[wu].[IsActive]=@isActive")]
        public bool? IsActive { get; set; } = true;

        [Where("[wu].[ManagerId]=@managerId")]
        public int? ManagerId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new WorkspaceUsers() { WorkspaceId = 1, IsActive = null };
            yield return new WorkspaceUsers() { WorkspaceId = 1, IsActive = true };
            yield return new WorkspaceUsers() { WorkspaceId = 1, ManagerId = 1 };
        }
    }
}
