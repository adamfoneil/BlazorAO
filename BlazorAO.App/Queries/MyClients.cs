using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyClients : TestableQuery<Client>
    {
        public MyClients() : base("SELECT * FROM [dbo].[Client] WHERE [WorkspaceId]=@workspaceId {andWhere} ORDER BY [Name]")
        {
        }

        public int WorkspaceId { get; set; }

        [Where("[IsActive]=@isActive")]
        public bool? IsActive { get; set; } = true;

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyClients();
        }
    }
}
