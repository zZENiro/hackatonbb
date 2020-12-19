using System.Collections.Generic;

namespace hackatonbb.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Spec> Specs { get; set; }
    }

}
