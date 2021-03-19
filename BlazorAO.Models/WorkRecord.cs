using AO.Models;
using BlazorAO.Models.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    public class WorkRecord : BaseTable
    {
        [References(typeof(UserProfile))]
        public int EmployeeUserId { get; set; }

        [References(typeof(Project))]
        public int ProjectId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [References(typeof(WorkType))]
        public int WorkTypeId { get; set; }

        /// <summary>
        /// if true, then manager must approve hours so it can be invoiced
        /// if false, then work is considered overhead
        /// </summary>
        public bool IsInvoiceable { get; set; }

        [MaxLength(255)]
        public string Comments { get; set; }
    }
}
