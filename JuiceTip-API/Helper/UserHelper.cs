using JuiceTip_API.Data;
using JuiceTip_API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace JuiceTip_API.Helper
{
    public class UserHelper
    {
        private JuiceTipDBContext _dbContext;
        public UserHelper(JuiceTipDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MsUser GetUser([FromBody] LoginRequest user)
        {
            try
            {
                var data = _dbContext.MsUser.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (data != null) return data;

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
