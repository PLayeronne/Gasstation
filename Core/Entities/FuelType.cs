using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FuelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal PricePerUnit { get; set; }
        public FuelingStation FuelingStation { get; set; }
        public virtual ICollection<FuelInventory> FuelInventories { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {UnitOfMeasurement}, {PricePerUnit}, Дані про АЗС: {FuelingStation}";
        }
    }

}
