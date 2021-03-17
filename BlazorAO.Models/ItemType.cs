using AO.Models;
using AO.Models.Interfaces;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks;

namespace BlazorAO.Models
{
    public class ItemType : BaseTable, ITenantIsolated<int>
    {
        [Key]
        [References(typeof(Workspace))]
        public int WorkspaceId { get; set; }

        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public async Task<int> GetTenantIdAsync(IDbConnection connection, IDbTransaction txn = null) => await Task.FromResult(WorkspaceId);
    }
}
