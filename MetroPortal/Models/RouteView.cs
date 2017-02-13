using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroPortal.Models {

    // Отображение маршрута
    public class RouteView {

        public int RouteId { get; set; }
        public string RouteName { get; set; }
        // Станции, которые уже добавлены в маршрут
        public List<Station> StationList { get; set; }
        // Станции, на которые возможен переход с последней текущей станции маршрута
        public List<Station> ConntectedStations { get; set; }
        // Станции ветки
        public List<Station> LineStations { get; set; }
    }
}