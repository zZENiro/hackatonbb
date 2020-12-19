using System;

namespace hackatonbb.Models
{
    public class CreditCardProfile
    { 
        public int Id { get; set; }

        public string Email { get; set; }
        public string INN { get; set; }
        public string SNILS { get; set; }
        public string MobilePhone { get; set; }
        public DateTime BirthDate { get; set; }
    }

}
