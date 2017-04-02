ngMetroApp.factory('StationsService', ['$http', function ($http) {

    var StationsService = {};

    StationsService.getStations = function () {
        return $http.get('/Home/getStations');
    };

    StationsService.getLines = function () {
        return $http.get('/Home/getLines');
    };

    // Функция для использования в директиве ng-repeat — фильтр определяющий, принадлежит ли станция заданной ветке
    StationsService.belongsToLine = function (targetLine) {
        return function (station) {
            return targetLine != null ? station.LineId == targetLine.LineId : false;
        };
    };

    return StationsService;

}]);