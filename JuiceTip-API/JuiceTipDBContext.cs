using JuiceTip_API.Model;
using Microsoft.EntityFrameworkCore;

namespace JuiceTip_API
{
    public class JuiceTipDBContext : DbContext
    {
        public DbSet<MsUser> MsUser { get; set; }
        public DbSet<MsRegion> MsRegion { get; set; }
        public JuiceTipDBContext(DbContextOptions<JuiceTipDBContext> options) : base(options) { }
    }
}
