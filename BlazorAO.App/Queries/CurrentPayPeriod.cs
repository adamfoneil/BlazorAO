using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class CurrentPayPeriod : TestableQuery<PayPeriod>
    {
        public CurrentPayPeriod() : base(
            @"WITH [current] AS (
                SELECT MIN([EndDate]) AS [MinDate]
                FROM [dbo].[PayPeriod]
                WHERE [WorkspaceId]=@workspaceId AND [EndDate]>=getdate()
            ) SELECT 
                [pp].*,
                DATEADD(dd, ([ws].[PayPeriodWeeks] * -7) + 1, [pp].[EndDate]) AS [StartDate]
            FROM 
                [PayPeriod] [pp]
                INNER JOIN [dbo].[Workspace] [ws] ON [pp].[WorkspaceId]=[ws].[Id]
                INNER JOIN [current] ON [pp].[EndDate]=[current].[MinDate]")
        {
        }

        public int WorkspaceId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new CurrentPayPeriod() { WorkspaceId = 1 };
        }
    }
}
