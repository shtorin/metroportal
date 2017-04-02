using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetroPortal.Models {
    public class RouteStation {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }

        public int StationId { get; set; }
        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }
    }
}