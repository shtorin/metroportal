using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MetroPortal.Models {

    public class MetroPortalEntities : ApplicationDbContext {
       
        public MetroPortalEntities() {
            Database.SetInitializer(new SampleData());
            
        }

        public DbSet<Line> Lines { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }       

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Line>()
                .HasMany(l => l.Stations)
                .WithRequired(s => s.Line)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(t => t.TransfersTo)
                .WithMany(t => t.TransfersFrom)
                .Map(x => {
                    x.ToTable("Transfers");
                    x.MapLeftKey("StationFromId");
                    x.MapRightKey("StationToId");
                });                

            modelBuilder.Entity<Route>()
                .HasMany<RouteStation>(r => r.RouteStations)
                .WithRequired(rs => rs.Route)
                .HasForeignKey(rs => rs.RouteId)
                .WillCascadeOnDelete(false);
                
        }
    }
}
