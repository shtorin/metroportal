ngMetroApp.factory('RouteService', ['$http', function ($http) {

    var RouteService = {};

    RouteService.saveRoute = function (route) {
        var result = $http.post('/Routes/Update', data = { route: route });
        return result;
    };

    return RouteService;

}]);