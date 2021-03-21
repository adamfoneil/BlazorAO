using BlazorAO.App.Queries;
using BlazorAO.Models;
using Dapper.CX.SqlServer.AspNetCore.Extensions;
using Dapper.CX.SqlServer.Services;
using System.Threading.Tasks;

namespace BlazorAO.App.Extensions
{
    public static partial class DapperCXExtensions
    {
        /// <summary>
        /// gets the current pay period or creates it if necessary
        /// </summary>

        public static async Task<PayPeriod> GetCurrentPayPeriodAsync(this DapperCX<int, UserProfile> data)
        {
            do
            {
                var result = await data.QuerySingleAsync(new CurrentPayPeriod()
                {
                    WorkspaceId = data.User?.WorkspaceId ?? 0
                });

                if (result != null) return result;


            } while (true);
                        
        }
    }
}
