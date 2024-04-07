using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public Customer Customer { get; set; }
        public override string ToString()
        {
            return $"{Id}, {OrderDateTime}, {TotalAmount}, {OrderStatus}, Дані про замовника: {Customer}";
        }
    }

}
