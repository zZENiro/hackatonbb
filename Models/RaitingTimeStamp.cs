namespace hackatonbb.Models
{
    public class RaitingTimeStamp
    {
        public int Id { get; set; }

        public int RaitingValue { get; set; }

        public virtual Student Student { get; set; }
    }

}
