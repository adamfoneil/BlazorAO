using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class PayPeriodsResult
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkspaceId { get; set; }
    }

    public class PayPeriods : TestableQuery<PayPeriodsResult>
    {
        public PayPeriods() : base(
            @"WITH [recent_periods] AS (
                SELECT TOP (5)
                    [pp].*,
                    DATEADD(dd, ([ws].[PayPeriodWeeks] * -7) + 1, [pp].[EndDate]) AS [StartDate]
                FROM
                    [dbo].[PayPeriod] [pp]
                    INNER JOIN [dbo].[Workspace] [ws] ON [pp].[WorkspaceId]=[ws].[Id]
                WHERE
                    [WorkspaceId]=@workspaceId AND
                    [EndDate] < DATEADD(d, 15, getdate())
                ORDER BY
                    [EndDate] DESC
            ) SELECT
                [Id],
                [StartDate],
                [EndDate]
            FROM
                [recent_periods]
            ORDER BY
                [EndDate]")
        {
        }

        public int WorkspaceId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new PayPeriods() { WorkspaceId = 1 };
        }
    }
}
