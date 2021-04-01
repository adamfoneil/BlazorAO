using System;
using System.IO;

namespace SillyCodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var classNames = new string[]
            {
                "ApprovedExpense",
                "ApprovedWorkHours",
                "Budget",
                "Client",
                "Expense",
                "Invoice",
                "InvoicedWorkRecord",
                "InvoiceRate",
                "Job",
                "Permission",
                "RecurringTask",
                "RecurringTaskType",
                "Role",
                "UserProfile",
                "WorkHours",
                "Workspace",
                "WorkspaceUser",
                "WorkspaceUserPermission",
                "WorkType"
            };

            const string template = @"public class %Repository : Repository<%> 
    {
        public %Repository(ApplicationDbContext context) : base(context)
        {            
        }

        public override async Task<%> GetAsync(int id) => await _context.FindAsync<%>(id);
    }";

            using (var file = File.CreateText(@"C:\Users\adamo\AppData\LocalLow\SampleClasses.cs"))
            {
                foreach (var name in classNames)
                {
                    var output = template.Replace("%", name);
                    file.Write(output);
                    file.WriteLine();
                }
            }
        }
    }
}
