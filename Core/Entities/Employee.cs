using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ContactInformation { get; set; }
        public string OtherDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public override string ToString()
        {
            return $"{Id}, {FullName}, {Position}, {ContactInformation}, {OtherDetails}";
        }
    }

}
