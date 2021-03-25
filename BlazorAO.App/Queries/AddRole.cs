using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    /// <summary>
    /// idempotent role insert
    /// </summary>
    public class AddRole : TestableQuery<int>
    {
        public AddRole() : base(
            @"INSERT INTO [dbo].[AspNetUserRoles] (
                [UserId], [RoleId]
            ) SELECT
                [u].[Id], [r].[Id]
            FROM
                [dbo].[AspNetUsers] [u],
                [dbo].[AspNetRoles] [r]
            WHERE
                [u].[Id]=@userId AND
                [r].[Id]=@roleId AND
                NOT EXISTS(SELECT 1 FROM [dbo].[AspNetUserRoles] WHERE [UserId]=@userId AND [RoleId]=@roleId)")
        {
        }

        public string UserId { get; set; }
        public string RoleId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new AddRole() { UserId = "nobody", RoleId = "whatever" };
        }
    }
}
