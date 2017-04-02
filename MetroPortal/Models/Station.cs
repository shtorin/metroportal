using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetroPortal.Models {
    
    // Станция метро
    public class Station {

        public Station() {
            TransfersTo = new List<Station>();
            TransfersFrom = new List<Station>();            
        }

        public int StationId { get; set; }
        public string StationName { get; set; }

        // Координаты
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public int LineId { get; set; }
        public virtual Line Line { get; set; }

        // На какие станции возможен переход с данной
        public virtual List<Station> TransfersTo { get; set; }
        // С каких станций возможен переход на данную
        public virtual List<Station> TransfersFrom { get; set; }

    }
}