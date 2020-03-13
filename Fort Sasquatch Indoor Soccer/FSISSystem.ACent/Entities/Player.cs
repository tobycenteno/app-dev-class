using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FSISSystem.ACent.Entities
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int GuardianID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender {
            get
            {
                return Gender;
            }
            set
            {
                char.ToUpper(Gender);
            }
        }
        public string AlbertaHealthCareNumber { get; set; }
        public string MedicalAlertDetails {
            get
            {
                return MedicalAlertDetails;
            }
            set
            {
                if(string.IsNullOrEmpty(MedicalAlertDetails))
                    MedicalAlertDetails = null;
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
