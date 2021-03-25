using Dapper.QX.Abstract;
using Dapper.QX.Interfaces;
using System;
using System.Collections.Generic;

namespace BlazorAO.App.Queries
{
    public class MyRecurringTasksResult
    {
        public int Id { get; set; }
        public int WorkspaceId { get; set; }
        public DateTime NextDueDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string DateAddInterval { get; set; }
        public int DateAddNumber { get; set; }
        public int TaskTypeId { get; set; }
        public int UserId { get; set; }
        public string TaskTypeName { get; set; }        
    }

    public class MyRecurringTasks : TestableQuery<MyRecurringTasksResult>
    {
        public MyRecurringTasks() : base(
            @"SELECT
                [rt].*,
                [rtt].[Name] AS [TaskTypeName]
            FROM
                [dbo].[RecurringTask] [rt]
                INNER JOIN [app].[RecurringTaskType] [rtt] ON [rt].[TaskTypeId]=[rtt].[Id]                
            WHERE
                [rt].[WorkspaceId]=@workspaceId")
        {
        }

        public int WorkspaceId { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new MyRecurringTasks() { WorkspaceId = 1 };
        }
    }
}
