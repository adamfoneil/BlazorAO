using AO.Models;
using AO.Models.Attributes;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    /// <summary>
    /// an employee's compensation rate for a certain work type
    /// </summary>
    [TrackChanges]
    public class CompensationRate : BaseTable
    {
        [Key]
        [References(typeof(WorkspaceUser))]
        public int WorkspaceUserId { get; set; }

        /// <summary>
        /// use 0 for all work types or a specific one
        /// </summary>
        [Key]        
        public int WorkTypeId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
