using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class JobDashboardResult
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string JobName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public decimal? CurrentBudget { get; set; }
        public decimal? TotalInvoices { get; set; }
        public int JobId { get; set; }
        public decimal? BalanceDollars { get; set; }
        public decimal? BalancePercent { get; set; }
        public int BalancePercentValue => Convert.ToInt32((BalancePercent ?? 0) * 100);
    }

    public class JobDashboard : TestableQuery<JobDashboardResult>
    {
        public JobDashboard() : base(
            $@"WITH [source] AS (
                SELECT
                    [j].[ClientId],
                    [c].[Name] AS [ClientName],
                    [j].[Name] AS [JobName],
                    [j].[ManagerId],
                    [u].[LastName] + ', ' + [u].[FirstName] AS [ManagerName],
                    {MyJobs.CurrentBudgetQuery} AS [CurrentBudget],
                    COALESCE({MyJobs.TotalInvoicesQuery}, 0) AS [TotalInvoices],
                    [j].[Id] AS [JobId]
                FROM
                    [dbo].[Job] [j]
                    INNER JOIN [dbo].[Client] [c] ON [j].[ClientId]=[c].[Id]
                    LEFT JOIN [dbo].[AspNetUsers] [u] ON [j].[ManagerId]=[u].[UserId]
                WHERE
                    [c].[WorkspaceId]=@workspaceId AND
                    [c].[IsActive]=1 {{andWhere}}
            ) SELECT
                [src].*,
                [CurrentBudget] - [TotalInvoices] AS [BalanceDollars],
                CASE 
                    WHEN [CurrentBudget] > 0 THEN ([CurrentBudget]-[TotalInvoices]) / [CurrentBudget]
                    ELSE 0
                END AS [BalancePercent]
            FROM
                [source] [src]")
        {
        }

        public int WorkspaceId { get; set; }

        [Where("[j].[ClientId]=@clientId")]
        public int? ClientId { get; set; }

        [Where("[j].[ManagerId]=@managerId")]
        public int? ManagerId { get; set; }

        [Where("[j].[IsActive]=@isActive")]
        public bool? IsActive { get; set; } = true;

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new JobDashboard() { WorkspaceId = 1 };
            yield return new JobDashboard() { WorkspaceId = 1, ClientId = 1 };
            yield return new JobDashboard() { WorkspaceId = 1, ManagerId = 1 };
        }
    }
}
