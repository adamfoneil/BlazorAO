using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    public class InvoiceRate : BaseTable
    {
        [Key]
        [References(typeof(WorkType))]        
        public int WorkTypeId { get; set; }

        /// <summary>
        /// use 0 for all employees or a specific UserProfile.UserId
        /// </summary>
        [Key]
        public int EmployeeUserId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
