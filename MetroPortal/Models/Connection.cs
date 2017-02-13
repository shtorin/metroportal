using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroPortal.Models {

    // Связь между станциями разных веток
    public class Connection {
        
        public int ConnectionId { get; set; }
        public int StationFromId { get; set; }
        public int StationToId { get; set; }

        public virtual Station StationFrom { get; set; }
        public virtual Station StationTo { get; set; }
    }
}