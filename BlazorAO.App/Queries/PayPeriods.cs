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
                    [pp].*, ROW_NUMBER() OVER (ORDER BY [EndDate] DESC) AS [RowNumber]
                FROM
                    [dbo].[PayPeriod] [pp]
                WHERE
                    [WorkspaceId]=@workspaceId AND
                    [EndDate] < DATEADD(d, 20, getdate())
                ORDER BY
                    [EndDate] DESC
            ) SELECT
                [current].[WorkspaceId],
                [current].[Id], 
                DATEADD(d, 1, [prior].[EndDate]) AS [StartDate],
                [current].[EndDate]    
            FROM
                [recent_periods] [current]
                INNER JOIN [recent_periods] [prior] ON [current].[RowNumber]-1 = [prior].[RowNumber]
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
