using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class UserSelectResult
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
    }

    public class UserSelect : TestableQuery<UserSelectResult>
    {
        public UserSelect() : base(
            @"SELECT
                [u].[UserId],
                [u].[LastName] + ', ' + [u].[FirstName] AS [DisplayName]
            FROM
                [dbo].[AspNetUsers] [u]
                INNER JOIN [dbo].[WorkspaceUser] [wu] ON [u].[UserId]=[wu].[UserId]
            WHERE
                [wu].[WorkspaceId]=@workspaceId
            ORDER BY
                [u].[LastName], [u].[FirstName]")
        {
        }

        public int WorkspaceId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new UserSelect() { WorkspaceId = 1 };
        }
    }
}
