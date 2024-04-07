using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FuelInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal QuantityAvailable { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public decimal MinStockLevel { get; set; }
        public string OtherDetails { get; set; }
        public FuelType FuelType { get; set; }
        public override string ToString()
        {
            return $"{Id}, {QuantityAvailable}, {LastUpdateDateTime}, {MinStockLevel}, {OtherDetails}, Дані про тип палива: {FuelType}";
        }
    }

}
