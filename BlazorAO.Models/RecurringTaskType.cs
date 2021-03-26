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

        public static IEnumerable<RecurringTaskType> SeedData => new RecurringTaskType[]
        {
            new RecurringTaskType() { Name = "Create Invoices", Url = "/Invoice", Icon = "oi-dollar" },
            new RecurringTaskType() { Name = "Approve Hours", Url = "/ApproveHours", Icon = "oi-clipboard" }
        };
    }
}
