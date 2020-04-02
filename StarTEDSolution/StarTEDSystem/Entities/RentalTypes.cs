using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarTEDSystem.Entities
{
    [Table("RentalTypes")]
    public class RentalTypes
    {
        [Key]
        public int RentalTypeID { get; set; }
        public string Description { get; set; }

    }
}
