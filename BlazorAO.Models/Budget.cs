using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    public class Budget : BaseTable
    {
        [Key]
        [References(typeof(Project))]
        public int ProjectId { get; set; }

        [Key]
        public int Year { get; set; }

        [Key]
        public int Month { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
