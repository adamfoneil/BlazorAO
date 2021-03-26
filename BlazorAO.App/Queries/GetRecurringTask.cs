using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class GetRecurringTask : TestableQuery<RecurringTask>
    {
        public GetRecurringTask() : base(
            @"SELECT [rt].*, DATEDIFF(d, getdate(), [rt].[NextDueDate]) AS [DaysAway]
            FROM [dbo].[RecurringTask] [rt]
            INNER JOIN [app].[RecurringTaskType] [rtt] ON [rt].[TaskTypeId]=[rtt].[Id]
            WHERE [rtt].[Name]=@name AND [rt].[WorkspaceId]=@workspaceId")
        {
        }

        public int WorkspaceId { get; set; }
        public string Name { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new GetRecurringTask() { WorkspaceId = 1, Name = "whatever" };
        }
    }
}
