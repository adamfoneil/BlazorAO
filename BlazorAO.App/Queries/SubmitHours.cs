using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class SubmitHours : TestableQuery<int>
    {
        public SubmitHours() : base(
            @"WITH [approve_hrs_task] AS (
                SELECT [rt].[NextDueDate]
                FROM [dbo].[RecurringTask] [rt]
                INNER JOIN [app].[RecurringTaskType] [rtt] ON [rt].[TaskTypeId]=[rtt].[Id]
                WHERE 
                    [rt].[WorkspaceId]=@workspaceId AND
                    [rtt].[Name]='Approve Hours'
            ) UPDATE [wh] SET
                [IsSubmitted]=@isSubmitted
            FROM
                [dbo].[WorkHours] [wh],
                [approve_hrs_task] [a]
            WHERE
                [wh].[WorkspaceId]=@workspaceId AND
                [wh].[UserId]=@userId AND
                NOT EXISTS(SELECT 1 FROM [dbo].[ApprovedWorkHours] WHERE [WorkHoursId]=[wh].[Id]) AND
                [wh].[Date]<=[a].[NextDueDate]")
        {
        }

        public int WorkspaceId { get; set; }
        public int UserId { get; set; }
        public bool IsSubmitted { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new SubmitHours() { WorkspaceId = 1, UserId = -1, IsSubmitted = true };
            yield return new SubmitHours() { WorkspaceId = 1, UserId = -1, IsSubmitted = false };
        }
    }
}
