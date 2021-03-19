using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    public class WorkType : BaseTable
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
