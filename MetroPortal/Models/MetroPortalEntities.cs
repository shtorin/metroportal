using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MetroPortal.Models {

    public class MetroPortalEntities : ApplicationDbContext {
       
        public DbSet<Disctrict> Districts { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Connection> Conntections { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}