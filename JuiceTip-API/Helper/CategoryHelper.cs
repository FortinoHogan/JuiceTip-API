using JuiceTip_API.Data;
using JuiceTip_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace JuiceTip_API.Helper
{
    public class CategoryHelper
    {
        private JuiceTipDBContext _dbContext;
        public CategoryHelper(JuiceTipDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<MsCategory> GetCategory([FromBody] CategoryRequest category)
        {
            try
            {
                if (category.CategoryId != null)
                {
                    var data = _dbContext.MsCategory.Where(x => x.CategoryId == category.CategoryId).ToList();
                    if (data != null) return data;
                }
                else
                {
                    var allData = _dbContext.MsCategory.ToList();
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
