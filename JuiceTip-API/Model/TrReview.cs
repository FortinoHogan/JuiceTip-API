using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class TrReview
    {
        [Key]
        public Guid ReviewId { get; set; }
        public string Comment { get; set; }
        public Guid RatingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
