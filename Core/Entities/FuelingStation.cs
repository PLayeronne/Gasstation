using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FuelingStation
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Location { get; set; }
        public string SupportedFuelTypes { get; set; }
        public int NumberOfDepots { get; set; }
        public string OtherTechnicalDetails { get; set; }
        public virtual ICollection<FuelType> FuelTypes { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Location}, {SupportedFuelTypes}, {NumberOfDepots}, {OtherTechnicalDetails}";
        }
    }

}
