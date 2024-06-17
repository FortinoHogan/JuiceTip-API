using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class MsRating
    {
        [Key]
        public Guid RatingId { get; set; }
        public int Rating { get; set; }
    }
}
