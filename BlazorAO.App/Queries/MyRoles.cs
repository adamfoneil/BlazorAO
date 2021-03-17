using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.Queries
{
    public class MyRoles : TestableQuery<Role>
    {
        public MyRoles() : base(
            @"SELECT 
                [r].*,
                COALESCE((
                    (SELECT 1 
                    FROM [dbo].[AspNetUserRoles] [ur]
                    INNER JOIN [dbo].[AspNetUsers] [u] ON [ur].[UserId]=[u].[Id]
                    WHERE [u].[UserName]=@userName AND [ur].[RoleId]=[r].[Id])
                ), 0) AS [IsEnabled]
            FROM
                [dbo].[AspNetRoles] [r]")
        {
        }

        public string UserName { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyRoles() { UserName = "adamo" };
        }
    }
}
