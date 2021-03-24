using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyHoursResult
    {
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkspaceId { get; set; }
        public string JobName { get; set; }
        public int JobId { get; set; }
        public DateTime Date { get; set; }
        public string WorkTypeName { get; set; }
        public int WorkTypeId { get; set; }
        public decimal Hours { get; set; }
        public string Comments { get; set; }
        public bool IsSubmitted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }

    public class MyHours : TestableQuery<MyHoursResult>
    {
        public MyHours() : base(
            @"SELECT
                [c].[Name] AS [ClientName],
                [j].[ClientId],
                [j].[Name] AS [JobName],
                [wt].[Name] AS [WorkTypeName],
                [wh].*
            FROM
                [dbo].[WorkHours] [wh]
                INNER JOIN [dbo].[Job] [j] ON [wh].[JobId]=[j].[Id]
                INNER JOIN [dbo].[Client] [c] ON [j].[ClientId]=[c].[Id]
                INNER JOIN [dbo].[WorkType] [wt] ON [wh].[WorkTypeId]=[wt].[Id]
            WHERE
                [wh].[WorkspaceId]=@workspaceId AND
                [wh].[UserId]=@userId AND
                NOT EXISTS(SELECT 1 FROM [dbo].[ApprovedWorkRecord] WHERE [WorkHoursId]=[wh].[Id])")
        {
        }

        public int WorkspaceId { get; set; }
        public int UserId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyHours() { WorkspaceId = 1, UserId = 1 };
        }
    }
}
