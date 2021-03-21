using AO.Models;
using BlazorAO.Models.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    /// <summary>
    /// record of hours worked by an employee on a job, or an employees expenses for reimbursment
    /// </summary>
    public class WorkRecord : BaseTable
    {
        [References(typeof(UserProfile))]
        public int EmployeeUserId { get; set; }

        [References(typeof(Job))]
        public int JobId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [References(typeof(WorkType))]
        public int WorkTypeId { get; set; }

        /// <summary>
        /// number of hours worked
        /// </summary>
        [Column(TypeName = "decimal(5,2)")]
        public decimal Hours { get; set; }

        /// <summary>
        /// if true, then manager must approve hours so it can be invoiced
        /// if false, then work is considered overhead
        /// </summary>
        public bool AllowInvoicing { get; set; }

        [MaxLength(255)]
        public string Comments { get; set; }
    }
}
