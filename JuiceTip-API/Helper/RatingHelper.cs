using JuiceTip_API.Data;
using JuiceTip_API.Model;
using JuiceTip_API.Output;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Helper
{
    public class RatingHelper
    {
        private JuiceTipDBContext _dbContext;
        public RatingHelper(JuiceTipDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public StatusOutput InsertRating([FromBody] RatingRequest rating)
        {
            try
            {
                var returnValue = new StatusOutput();
                var rate = _dbContext.MsRating.Where(x => x.Rating == rating.Rating).FirstOrDefault();

                var newRating = new TrReview
                {
                    Comment = rating.Comment,
                    RatingId = rate.RatingId,
                    CustomerId = rating.CustomerId,
                    UserId = rating.UserId,
                    ReviewDate = DateTime.Now
                };

                _dbContext.TrReview.Add(newRating);
                _dbContext.SaveChanges();

                returnValue.statusCode = 200;
                returnValue.message = "Success insert review";
                return returnValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
