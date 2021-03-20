using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    /// <summary>
    /// indicates a manager's approval of a work record, allowing it to be invoiced
    /// </summary>
    public class ApprovedWorkRecord : BaseTable
    {
        [Key]
        [References(typeof(WorkRecord))]
        public int WorkRecordId { get; set; }

        /// <summary>
        /// WorkRecord.AllowInvoicing, but manager may override
        /// </summary>
        public bool AllowInvoicing { get; set; }
    }
}
