using AO.Models;
using BlazorAO.Models.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAO.Models
{
    public class Invoice : BaseTable
    {
        [References(typeof(Client))]
        public int ClientId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }        
    }
}
