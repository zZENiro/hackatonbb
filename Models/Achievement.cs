namespace hackatonbb.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        public int? ResultPlace { get; set; }

        public string EventName { get; set; }

        public string EventDescribtion { get; set; }

        public virtual EventRole EventRole { get; set; }

        public virtual EventLevel EventLevel { get; set; }
    }

}
