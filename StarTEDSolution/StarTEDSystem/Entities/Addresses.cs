using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarTEDSystem.Entities
{
    [Table("Addresses")]
    public class Addresses
    {
        [Key]
        public int AddressID { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string Community { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string ProvinceState { get; set; }
        public string PostalCodeZip { get; set; }
        public string CountryCode { get; set; }

        public int? LandLordID { get; set; }

        [NotMapped]
        public string FullAddress
        {
            get
            {
                return Number + ", " + Street + (Unit == null ? "" : " (" + Unit + ")");
            }
        }
    }
}
