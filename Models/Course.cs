using System.Collections.Generic;

namespace hackatonbb.Models
{
    public class Course
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public virtual ICollection<GuestCourse> Guests { get; set; }
    }

}
