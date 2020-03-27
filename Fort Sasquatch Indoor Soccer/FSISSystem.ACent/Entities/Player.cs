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
        private string _medalertdetails;
        private string _gender;

        [Key]
        public int PlayerID { get; set; }
        public int GuardianID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string Gender {
            
            get
            {
                return _gender;
            }
            set
            {
                _gender = value.ToUpper();
            }
        } 
        public string AlbertaHealthCareNumber { get; set; }

        public string MedicalAlertDetails {
            get
            {
                return _medalertdetails;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    _medalertdetails = null;
                }
                else
                {
                    _medalertdetails = value;
                }

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
