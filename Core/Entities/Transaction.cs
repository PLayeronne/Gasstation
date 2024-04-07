using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public string OtherDetails { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public override string ToString()
        {
            return $"{Id}, {DateTime}, {Amount}, {Quantity}, {OtherDetails}, Дані про замовника: {Customer}, Дані про робітника: {Employee}";
        }
    }

}
