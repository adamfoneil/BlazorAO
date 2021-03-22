using BlazorAO.Models.Conventions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    /// <summary>
    /// defines hour approval and invoicing as tasks that can be assigned to managers on a recurring basis
    /// </summary>
    public class RecurringTaskType : AppTable
    {
        [Key]
        [MaxLength(50)]        
        public string Name { get; set; }

        [MaxLength(255)]
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// open iconic image
        /// </summary>
        [MaxLength(50)]
        public string Icon { get; set; }

        /// <summary>
        /// T-SQL DATEADD interval default argument
        /// </summary>
        [MaxLength(10)]
        public string DateAddInterval { get; set; }

        /// <summary>
        /// T-SQL DATEADD default number argument
        /// </summary>
        public int DateAddNumber { get; set; }

        public static IEnumerable<RecurringTaskType> SeedData => new RecurringTaskType[]
        {
            new RecurringTaskType() { Name = "Create Invoices", Url = "/Invoice", DateAddInterval = "m", DateAddNumber = 1, Icon = "oi-dollar" },
            new RecurringTaskType() { Name = "Approve Hours", Url = "/ApproveHours", DateAddInterval = "wk", DateAddNumber = 2, Icon = "oi-clipboard" }
        };
    }
}
