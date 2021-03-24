using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyWorkTypes : TestableQuery<WorkType>
    {
        public MyWorkTypes() : base("SELECT * FROM [dbo].[WorkType] [wt] WHERE [WorkspaceId]=@workspaceId {andWhere} ORDER BY [Name]")
        {
        }

        public int WorkspaceId { get; set; }

        [Where("[wt].[IsActive]=@isActive")]
        public bool? IsActive { get; set; } = true;

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyWorkTypes() { WorkspaceId = 1 };
        }
    }
}
