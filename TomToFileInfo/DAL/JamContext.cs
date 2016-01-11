using TomToFileInfo.Models; 
using System.Data.Entity; 
using System.Data.Entity.ModelConfiguration.Conventions; 
namespace TomToFileInfo.DAL 
{ 
    public class JamContext : DbContext 
    { 
        public JamContext() : base("JamContext") 
        { 
        } 
        
        public DbSet<Traject> Trajects { get; set; } 
        public DbSet<Jam> Jams { get; set; } 
        public DbSet<Region> Regions { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}