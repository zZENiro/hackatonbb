namespace hackatonbb.Models
{
    public class Privelege
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Sphere Sphere { get; set; }
    }

}
