using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyWorkspaces : TestableQuery<Workspace>
    {
        public MyWorkspaces() : base(
            @"SELECT 
                [ws].*
            FROM
                [dbo].[Workspace] [ws]
                INNER JOIN [dbo].[WorkspaceUser] [wu] ON [ws].[Id]=[wu].[WorkspaceId]
            WHERE
                [wu].[UserId]=@userId")
        {
        }

        public int UserId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyWorkspaces();
        }
    }
}
