using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    /// <summary>
    /// associates a user with a workspace
    /// </summary>
    public class WorkspaceUser : BaseTable
    {
        [Key]
        [References(typeof(Workspace))]
        public int WorkspaceId { get; set; }

        [Key]
        [References(typeof(UserProfile))]
        public int UserId { get; set; }
    }
}
