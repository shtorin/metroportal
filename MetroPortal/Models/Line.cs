using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroPortal.Models {

    // Линия метрополитена
    public class Line {

        public int LineId { get; set; }
        public string LineName { get; set; }
        public int Color { get; set; }
        // Станции ветки
        public List<Station> Stations { get; set; }
    }
}