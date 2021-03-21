using AO.Models;
using BlazorAO.Models.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    public class PayPeriod : BaseTable
    {
        [Key]
        [References(typeof(Workspace))]
        public int WorkspaceId { get; set; }

        [Key]
        [Column(TypeName = "date")]        
        public DateTime EndDate { get; set; }

        [NotMapped]
        public DateTime StartDate { get; set; }
    }
}
