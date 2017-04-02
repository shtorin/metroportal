using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MetroPortal.Models;
using Newtonsoft.Json;
using System.Data.Entity;


namespace MetroPortal.Controllers {

    public class HomeController : Controller {

        MetroPortalEntities metroDB = new MetroPortalEntities();

        public ActionResult Index() {

            return View();
        }

        /// <summary>
        /// Возвращает список станций в формате JSON
        /// </summary>
        /// <returns>Строка, </returns>
        public string GetStations() {

            // Выбираем станции, не включаем в отбор поля, которые могут привести к зацикливанию ссылок
            var stations = metroDB.Stations.Include(s => s.TransfersTo).Select(s => new {
                StationId = s.StationId,
                StationName = s.StationName,
                LineId = s.LineId,
                // Список станций линии метро не включается
                Line = new {
                    LineId = s.Line.LineId,
                    LineName = s.Line.LineName,
                    Color = s.Line.Color },
                Latitude = s.Latitude,
                Longtitude = s.Longtitude,
                // Станции, на которые возможен переход с данной не включают информацию об их собственных переходах
                TransfersTo = s.TransfersTo.Select(
                    ts => new { StationId = ts.StationId,
                                StationName = ts.StationName,                                
                                LineId = ts.LineId,
                                Line = new { LineName = ts.Line.LineName,
                                             Color = ts.Line.Color }
                    })
            });

            return JsonConvert.SerializeObject(stations, Formatting.Indented, new JsonSerializerSettings() {
                                               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }

        public string GetLines() {

            var lines = metroDB.Lines.ToList();

            return JsonConvert.SerializeObject(lines, Formatting.Indented, new JsonSerializerSettings() {
                                               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
        }
    }
}