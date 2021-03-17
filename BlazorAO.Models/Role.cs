using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    [Table("AspNetRoles")]        
    public class Role
    {
        [Key]
        [MaxLength(450)]
        [Column("Id")] // this is to work around atypical Id behavior
        public string RoleId { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]        
        public string NormalizedName { get; set; }
     
        public string ConcurrencyStamp { get; set; }

        /// <summary>
        /// so that we can toggle in UI
        /// </summary>
        [NotMapped]
        public bool IsEnabled { get; set; }
    }
}
