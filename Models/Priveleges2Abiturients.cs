using System;

namespace hackatonbb.Models
{
    public class Priveleges2Abiturients
    {
        public int Id { get; set; }

        public virtual Abiturient Abiturient { get; set; }
    
        public virtual Privelege Privelege { get; set; }

        public bool IsUsed { get; set; }

        public DateTime ExpireTime { get; set; }
    }

}
