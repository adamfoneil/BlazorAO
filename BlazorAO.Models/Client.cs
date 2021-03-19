using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations;

namespace BlazorAO.Models
{
    public class Client : BaseTable
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// if true, then we can invoice this client for work done
        /// if false, then it's considered overhead or an internal client
        /// </summary>
        public bool IsInvoiceable { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
