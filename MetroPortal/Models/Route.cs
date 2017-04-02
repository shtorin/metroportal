using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetroPortal.Models {

    // Пользовательский маршрут 
    public class Route {

        public Route() {
            RouteStations = new List<RouteStation>();
        }

        public int RouteId { get; set; }
        [Required(ErrorMessage = "Введите название маршрута")]
        [Display(Name ="Название маршрута")]
        public string RouteName { get; set; }

        // Владелец маршрута
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        // Список станций маршрута        
        public virtual List<RouteStation> RouteStations { get; set; }
    }
}