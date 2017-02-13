using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroPortal.Models {

    // Пользовательский маршрут 
    public class Route {

        public int RouteId { get; set; }
        public string RouteName { get; set; }
        // Список станций маршрута
        public List<Station> StationList { get; set; }
    }
}