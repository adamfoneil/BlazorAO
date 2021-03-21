using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    /// <summary>
    /// assigns a role to a user in a workspace
    /// </summary>
    public class WorkspaceUserPermission : BaseTable
    {
        [Key]
        [References(typeof(WorkspaceUser))]        
        public int WorkspaceUserId { get; set; }

        [Key]
        [References(typeof(Permission))]
        public int PermissionId { get; set; }
    }
}
