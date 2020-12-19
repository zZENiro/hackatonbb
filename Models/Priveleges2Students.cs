using System;

namespace hackatonbb.Models
{
    public class Priveleges2Students
    {
        public int Id { get; set; }

        public virtual Student Student { get; set; }

        public virtual Privelege Privelege { get; set; }

        public bool IsUsed { get; set; }

        public DateTime ExpireDate { get; set; } 
    }

}
