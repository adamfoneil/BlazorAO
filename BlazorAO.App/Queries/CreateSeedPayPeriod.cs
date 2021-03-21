using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class CreateSeedPayPeriod : TestableQuery<int>
    {
        public CreateSeedPayPeriod() : base(
            @"WITH [source] AS (
                SELECT
                    [ws].[Id], DATEADD(d, [ws].[PayPeriodEndDay] - DATEPART(dw, getdate()), getdate()) AS [EndDate]
                FROM
                    [dbo].[Workspace] [ws]
                WHERE
                    [ws].[Id]=@workspaceId
            ) INSERT INTO [dbo].[PayPeriod] (
                [WorkspaceId], [EndDate], [DateCreated], [CreatedBy]
            ) SELECT
                [Id], [EndDate], @localTime, @userName
            FROM
                [source]
            WHERE    
                NOT EXISTS(SELECT 1 FROM [dbo].[PayPeriod] WHERE [WorkspaceId]=[source].[Id] AND [EndDate]=[source].[EndDate])")
        {
        }

        public int WorkspaceId { get; set; }
        public DateTime LocalTime { get; set; }
        public string UserName { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new CreateSeedPayPeriod() { WorkspaceId = 1 };
        }
    }
}
