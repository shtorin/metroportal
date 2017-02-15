using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroPortal.Models {
    
    // Станция метро
    public class Station {

        public int StationId { get; set; }
        public string StationName { get; set; }
        // Адрес станции
        public string Address { get; set; }
        // Координаты
        public double Lattitude { get; set; }
        public double Longtitude { get; set; }
        // Район в котором находится станция
        public int DistrictId { get; set; }
        public int LineId { get; set; }

        public virtual Disctrict District { get; set; }
        public virtual Line Line { get; set; }
    }
}