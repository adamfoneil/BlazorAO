using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class SubmitHours : TestableQuery<int>
    {
        public SubmitHours() : base(
            @"UPDATE [wh] SET
                [IsSubmitted]=@isSubmitted
            FROM
                [dbo].[WorkHours] [wh]
            WHERE
                [wh].[WorkspaceId]=@workspaceId AND
                [wh].[UserId]=@userId AND
                NOT EXISTS(SELECT 1 FROM [dbo].[ApprovedWorkHours] WHERE [WorkHoursId]=[wh].[Id])")
        {
        }

        public int WorkspaceId { get; set; }
        public int UserId { get; set; }
        public bool IsSubmitted { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new SubmitHours() { UserId = -1, IsSubmitted = true };
            yield return new SubmitHours() { UserId = -1, IsSubmitted = false };
        }
    }
}
