ngMetroApp.controller('RouteController', ['$scope', 'MapService', 'StationsService', 'RouteService', function ($scope, MapService, StationsService, RouteService) {

    // Добавление карты
    $scope.map = MapService.getMap('map', MapService.mapOptions);

    // Получаем маршрут из глобального объекта window
    $scope.route = window.routeJson;
    $scope.routeLength = $scope.route.length;
    
    // Добавляем на карту маркеры для станций маршрута
    $scope.route.RouteStations.forEach(function (routeStation) {
        MapService.createMarker($scope.map, routeStation.Station, MapService.MarkerIcons.greenIcon, routeStation.Station.StationName, false);
    });
    
    // Режим редактирования маршрута по умолчанию включен
    $scope.stateRouteEditing = true;
    
    // Обновляем параметры маршрута
    updateRouteParameters();

    // Список всех станций
    $scope.stations = [];
    StationsService.getStations()
        .then(function (stations) {
            $scope.stations = stations.data;
        },
        function (error) {
            console.log("Unable to load stations data");
        });
    
    // Список линий метрополитена
    $scope.lines = [];
    StationsService.getLines()
        .then(function (lines) {
            $scope.lines = lines.data;
        }, function (error) {
            console.log("Unable to load lines data");
        });    

    // Метод добавляющий станцию к маршруту
    $scope.addStationToRoute = function (station) {
        var detailedStation = $scope.stations.filter(function (s) {
            return s.StationId == station.StationId;
        })[0];

        var routeStation = {
            RouteId: $scope.route.RouteId,
            StationId: station.StationId,
            Station: detailedStation
        };        
        $scope.route.RouteStations.push(routeStation);
        console.log(routeStation);
        // Добавляем маркер
        MapService.createMarker($scope.map, detailedStation, MapService.MarkerIcons.greenIcon, station.StationName, false);

        // Обновляем параметры маршрута
        updateRouteParameters();
    };

    // Удаляем последнюю станцию из маршрута
    $scope.removeLastStationFromRoute = function () {
        var routeLength = $scope.route.RouteStations.length;
        $scope.route.RouteStations.splice(routeLength - 1, 1);

        // Удаляем маркер
        MapService.removeLastMarker();
        console.log($scope.route.RouteStations);
        // Обновляем параметры маршрута
        updateRouteParameters();
    };

    // Сохраняет маршрут
    $scope.saveRoute = function () {
        // Во время сохранения отключаем возможность редактирования маршрута
        $scope.stateRouteEditing = false;

        // Сохраняем маршрут на сервере
        RouteService.saveRoute($scope.route)
            .then(function (data) {
                $scope.route = data.data;
                $scope.stateRouteEditing = true;
            },
            function (error) {
                console.log("Unable to save route on server");
                $scope.stateRouteEditing = true;
            });
    };

    // Линия с которой начинается маршрут
    $scope.startLine = null;

    $scope.setStartLine = function (line) {
        $scope.startLine = line;
    };

    // Функция определяющая принадлежит ли станция метро заданной линии
    $scope.belongsToLine = StationsService.belongsToLine;
    // Функция, открывающая всплывающее окошко при клике на станцию
    $scope.openInfoWindow = MapService.openInfoWindow;

    // Добавляет элементу стиль enabled, если режим редактирования включен, disabled в противном случае
    $scope.enabledOnEditing = function () {
        return $scope.stateRouteEditing ? 'enabled' : 'disabled';
    }

    // Метод обновляющий параметры маршрута: количество станций, текущая ветка, последняя станция в маршруте
    function updateRouteParameters() {
        var route = $scope.route.RouteStations;
        $scope.routeLength = route.length;

        // Если маршрут не пустой, то запоминаем текущую последнюю станцию и ветку на которой она находится
        $scope.lastStation = route.length > 0 ? route[route.length - 1].Station : null;
        $scope.currentLine = $scope.lastStation != null ? $scope.lastStation.Line : null;
    };

}]);