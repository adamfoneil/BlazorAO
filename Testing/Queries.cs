using BlazorAO.App.Queries;
using Dapper.QX;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlServer.LocalDb;

namespace Testing
{
    [TestClass]
    public class Queries
    {
        [TestMethod]
        public void AddRole() => QueryHelper.Test<AddRole>(GetConnection);

        [TestMethod]
        public void JobDashboard() => QueryHelper.Test<JobDashboard>(GetConnection);

        [TestMethod]
        public void MyClients() => QueryHelper.Test<MyClients>(GetConnection);

        [TestMethod]
        public void MyHours() => QueryHelper.Test<MyHours>(GetConnection);

        [TestMethod]
        public void MyJobs() => QueryHelper.Test<MyJobs>(GetConnection);

        [TestMethod]
        public void MyRecurringTasks() => QueryHelper.Test<MyRecurringTasks>(GetConnection);

        [TestMethod]
        public void MyRoles() => QueryHelper.Test<MyRoles>(GetConnection);

        [TestMethod]
        public void MyWorkspace() => QueryHelper.Test<MyWorkspaces>(GetConnection);

        [TestMethod]
        public void MyWorkTypes() => QueryHelper.Test<MyWorkTypes>(GetConnection);

        [TestMethod]
        public void RebuildUserPermissions() => QueryHelper.Test<RebuildUserPermissions>(GetConnection);

        [TestMethod]
        public void RemoveRole() => QueryHelper.Test<RemoveRole>(GetConnection);

        [TestMethod]
        public void UserSelect() => QueryHelper.Test<UserSelect>(GetConnection);

        [TestMethod]
        public void WorkspaceUserPermissions() => QueryHelper.Test<WorkspaceUserPermissions>(GetConnection);

        [TestMethod]
        public void WorkspaceUsers() => QueryHelper.Test<WorkspaceUsers>(GetConnection);

        [TestMethod]
        public void SubmitHours() => QueryHelper.Test<SubmitHours>(GetConnection);

        [TestMethod]
        public void GetRecurringTask() => QueryHelper.Test<GetRecurringTask>(GetConnection);

        private SqlConnection GetConnection() => LocalDb.GetConnection("BlazorAO");
    }
}
