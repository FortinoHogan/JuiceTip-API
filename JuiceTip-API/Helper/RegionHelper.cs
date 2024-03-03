using JuiceTip_API.Data;
using JuiceTip_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Helper
{
    public class RegionHelper
    {
        private JuiceTipDBContext _dbContext;
        public RegionHelper(JuiceTipDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<MsRegion> GetRegion([FromBody] RegionRequest region)
        {
            try
            {
                if(region.RegionId != null) 
                { 
                    var data = _dbContext.MsRegion.Where(x => x.RegionId == region.RegionId).ToList();
                    if (data != null) return data;
                }
                else
                {
                    var allData = _dbContext.MsRegion.ToList();
                    if (allData != null) return allData;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
