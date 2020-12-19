using System;

namespace hackatonbb.Models
{
    public class GuestCourse
    {
        public int Id { get; set; }

        public virtual Guest Guest { get; set; }

        public virtual Course Course { get; set; }

        public DateTime SubscriptionDate { get; set; }

        public DateTime ExpiringDate { get; set; }
    }

}
