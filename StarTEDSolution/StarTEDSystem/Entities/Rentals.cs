using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarTEDSystem.Entities
{
    [Table("Rentals")]
    public class Rentals
    {
        [Key]
        public int RentalID { get; set; }
        public int AddressID { get; set; }
        public int? RentalTypeID { get; set; }
        public decimal MonthlyRent { get; set; }
        public byte Vacancies { get; set; }
        public byte MaxVacancy { get; set; }
        public decimal? DamageDeposit { get; set; }
        public DateTime? AvailableDate { get; set; }

        [NotMapped]
        public string AddressName { get; set; }
    }
}
