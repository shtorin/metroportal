namespace MetroPortal.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.IO;
    using MetroPortal.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MetroPortal.Models.MetroPortalEntities> {

        public Configuration() {

        }

        protected override void Seed(MetroPortalEntities context) {
            
            SampleData sampleData = new SampleData();
            sampleData.InitializeDatabase(context);
        }


    }

}