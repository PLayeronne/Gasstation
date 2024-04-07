using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal SaleAmount { get; set; }
        public string OtherSaleDetails { get; set; }
        public Transaction Transaction { get; set; }
        public override string ToString()
        {
            return $"{Id}, {SaleAmount}, {OtherSaleDetails}, Дані про транзакцію: {Transaction}";
        }
    }

}
