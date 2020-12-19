using System.Collections.Generic;

namespace hackatonbb.Models
{
    public class Guest
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Secondname { get; set; }

        public string Thirdname { get; set; }

        public virtual CreditCardProfile CreditCardProfile { get; set; }

        public virtual ICollection<GuestCourse> SelectedCources { get; set; }
    }

}
