using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class RemoveRole : TestableQuery<int>
    {
        public RemoveRole() : base(@"DELETE [ur] FROM [dbo].[AspNetUserRoles] [ur] WHERE [UserId]=@userId AND [RoleId]=@roleId")
        {
        }

        public string UserId { get; set; }
        public string RoleId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new RemoveRole() { UserId = "nobody", RoleId = "anyrole" };
        }
    }
}
