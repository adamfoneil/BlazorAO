using BlazorAO.Models;
using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyJobs : TestableQuery<Job>
    {
        public const string CurrentBudgetQuery = "(SELECT SUM([Amount]) FROM [dbo].[Budget] [b] WHERE [JobId]=[j].[Id] AND DATEFROMPARTS([b].[Year], [b].[Month], 1) <= DATEFROMPARTS(YEAR(getdate()), MONTH(getdate()), 1))";
        public const string TotalBudgetQuery = "(SELECT SUM([Amount]) FROM [dbo].[Budget] [b] WHERE [JobId]=[j].[Id])";
        public const string TotalInvoicesQuery = "(SELECT SUM([Amount]) FROM [dbo].[Invoice] WHERE [JobId]=[j].[Id])";

        public MyJobs() : base(
            $@"SELECT 
                [j].*,
                [c].[Name] AS [ClientName],
                [u].[LastName] + ', ' + [u].[FirstName] AS [ManagerName],
                [c].[Name] + ' - ' + [j].[Name] AS [JobDisplayName],
                {CurrentBudgetQuery} AS [CurrentBudget],
                {TotalBudgetQuery} AS [TotalBudget],
                {TotalInvoicesQuery} AS [TotalInvoices]
            FROM 
                [dbo].[Job] [j]
                INNER JOIN [dbo].[Client] [c] ON [j].[ClientId]=[c].[Id]
                LEFT JOIN [dbo].[AspNetUsers] [u] ON [j].[ManagerId]=[u].[UserId]
            WHERE 
                [c].[WorkspaceId]=@workspaceId AND
                [c].[IsActive]=1 {{andWhere}}
            ORDER BY 
                [c].[Name], 
                [j].[Name] {{offset}}")
        {
        }

        public int WorkspaceId { get; set; }

        [Where("[j].[IsActive]=@isActive")]
        public bool? IsActive { get; set; }

        [Offset(30)]
        public int? Page { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyJobs() { WorkspaceId = 1 };
            yield return new MyJobs() { WorkspaceId = 1, IsActive = true };
        }
    }
}
