using System.Collections.Generic;

namespace hackatonbb.Models
{
    public class Spec
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

}
