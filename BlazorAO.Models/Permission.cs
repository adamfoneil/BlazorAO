using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    /// <summary>
    /// defines permissions at the workspace level (tenant-specific) as opposed to AspNetRole (application-level)
    /// </summary>
    public class Permission : BaseTable
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// what role do you need to grant this one?
        /// </summary>
        [References(typeof(Permission))]
        public int? GrantedByPermissionId { get; set; }
    }
}
