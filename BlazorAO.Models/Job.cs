using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    public class Job : BaseTable
    {
        [Key]
        [References(typeof(Client))]
        public int ClientId { get; set; }

        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        [References(typeof(UserProfile))]
        public int? ManagerId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
