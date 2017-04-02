using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MetroPortal.Models;


namespace MetroPortal.Controllers
{
    public class RoutesController : Controller
    {
        private MetroPortalEntities db = new MetroPortalEntities();

        // GET: Route
        [Authorize]
        public ActionResult Index()
        {
            // Получаем ID текущего пользователя
            string currentUserId = User.Identity.GetUserId();
            // Список маршрутов этого пользователя
            var userRoutes = db.Routes.Where(u => u.UserId == currentUserId).Include(s => s.RouteStations).ToList();

            return View(userRoutes);
        }

        /// <summary>
        /// Создание нового маршрута
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Create()
        {
            // Для нового маршрута задаем название по умолчанию и пустой список станций
            Route newRoute = new Route() {
                RouteName = "Новый маршрут",
                RouteStations = new List<RouteStation>()
            };

            return View("Route", newRoute);
        }


        // GET: Route/Details/5
        [Authorize]
        public ActionResult Details(int? routeId) {
            // Получаем ID текущего пользователя
            string currentUserId = User.Identity.GetUserId();

            // Если номер машрута не задан, возвращаем сообщение об ошибке
            if (routeId == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Ищем среди маршрутов текущего пользователя требуемый маршрут            
            try {
                Route route = db.Routes.Include(r => r.RouteStations).Single(r => r.RouteId == routeId && r.UserId == currentUserId);
                return View("Route", route);
            } catch (System.InvalidOperationException ex) {                
                return HttpNotFound();
            }

        }

        /// <summary>
        /// Удаление маршрута с заданным номером
        /// </summary>
        /// <param name="routeId">Номер маршрута</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Delete (int? routeId) {
            // Получаем ID текущего пользователя
            string currentUserId = User.Identity.GetUserId();

            // Если номер машрута не задан, возвращаем сообщение об ошибке
            if (routeId == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Ищем среди маршрутов текущего пользователя требуемый маршрут            
            try {
                Route route = db.Routes.Single(r => r.RouteId == routeId && r.UserId == currentUserId);
                // Удаляем найденный маршрут
                db.Routes.Remove(route);
                db.SaveChanges();       
                return RedirectToAction("Index");
            }
            catch (System.InvalidOperationException ex) {
                return HttpNotFound();
            }
        }

        /// <summary>
        /// Сохранение маршрута на сервере
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [HttpPost]
        public string Update(Route route) {

            if (ModelState.IsValid) {
                // Получаем айди текущего пользователя
                string currentUserId = User.Identity.GetUserId();

                // Маршрут полученный от клиента
                Route updatedRoute;

                // Если маршруту уже присвоен ID
                if (route.RouteId != 0) {
                    
                    // Ищем его в БД
                    try {
                        updatedRoute = db.Routes.Include(r => r.RouteStations).Single(r => r.RouteId == route.RouteId && r.UserId == currentUserId);                        
                    }
                    catch (System.InvalidOperationException) {

                        updatedRoute = new Route();
                    }
                                        
                } else {
                    // Иначе это новый маршрут
                    updatedRoute = new Route();                    
                }

                // Обновляем данные маршрута
                updatedRoute.RouteName = route.RouteName;
                updatedRoute.UserId = currentUserId;
                updatedRoute.User = db.Users.Single(u => u.Id == currentUserId);                

                // Если айди маршрута == 0, значит это новый маршрут, сохраняем его
                if (route.RouteId == 0) {
                    db.Routes.Add(updatedRoute);
                    db.SaveChanges();
                } else {
                    // Если редактируется старый маршрут, то удаляем текущие станции
                    updatedRoute.RouteStations.ToList().ForEach(rs => db.RouteStations.Remove(rs));
                }
                
                // Добавляем станции к маршруту
                foreach (var station in route.RouteStations) {
                    updatedRoute.RouteStations.Add(new RouteStation() {
                        RouteId = updatedRoute.RouteId,
                        Route = updatedRoute,
                        StationId = station.StationId,
                        Station = db.Stations.Single(s => s.StationId == station.StationId)
                    });
                }

                db.SaveChanges();

                return JsonConvert.SerializeObject(updatedRoute, Formatting.Indented, new JsonSerializerSettings() {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

            } else {
                return JsonConvert.SerializeObject(route, Formatting.Indented, new JsonSerializerSettings() {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
