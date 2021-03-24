using BlazorAO.Models;
using Dapper.CX.SqlServer.Services;
using System.Threading.Tasks;

namespace BlazorAO.App.Extensions
{
    public static partial class DapperCXExtensions
    {
        public static async Task CreateSeedDataAsync(this DapperCX<int, UserProfile> data)
        {
            using (var cn = data.GetConnection())
            {
                foreach (var row in Permission.SeedData) await data.MergeAsync(row);
                foreach (var row in RecurringTaskType.SeedData) await data.MergeAsync(row);
            }
        }
    }
}
