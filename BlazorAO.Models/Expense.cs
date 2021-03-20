using AO.Models;
using BlazorAO.Models.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    /// <summary>
    /// Any non-work, non-employee expense associated with a project (vendor payments, typically, but also other kinds of adjustments)
    /// </summary>
    public class Expense : BaseTable
    {
        [References(typeof(Job))]
        public int JobId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
