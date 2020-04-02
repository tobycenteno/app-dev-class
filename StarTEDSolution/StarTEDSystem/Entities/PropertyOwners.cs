using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarTEDSystem.Entities
{
    [Table("PropertyOwners")]
    public class PropertyOwners
    {
        [Key]
        public int LandlordID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public bool ActiveContract { get; set; }

    }
}
