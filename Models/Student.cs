using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hackatonbb.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string VkId { get; set; }

        public virtual CreditCardProfile CreditCardProfile { get; set; }

        public string Password { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Secondname { get; set; }

        public string Thirdname { get; set; }

        public string StudentNumber { get; set; }

        public double Raiting { get; set; }

        public bool IsGoodScores { get; set; }

        public virtual Spec Spec { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }

        public virtual ICollection<RaitingTimeStamp> RaitingTimeStamps { get; set; }

        public virtual ICollection<Priveleges2Students> Priveleges { get; set; }
    }

}
