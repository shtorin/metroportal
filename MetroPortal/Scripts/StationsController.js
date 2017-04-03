ngMetroApp.controller('StationsController', ['$scope', 'StationsService', 'MapService', function ($scope, StationsService, MapService) {

    $scope.map = MapService.getMap('map', MapService.mapOptions);

    $scope.lines = [];
    StationsService.getLines()
        .then(function (lines) {
            $scope.lines = lines.data;
        }, function (error) {
            console.log("Unable to load lines data");
        }
    );

    $scope.stations = [];
    StationsService.getStations()
        .then(function (data) {
            $scope.stations = data.data;
            for (var i = 0; i < $scope.stations.length; i++) {
                MapService.createMarker($scope.map, $scope.stations[i], MapService.MarkerIcons.redIcon, false);
            }
        }, function (error) {
            console.log("Unable to load stations data");
        }
    );

    $scope.belongsToLine = StationsService.belongsToLine;
    $scope.openInfoWindow = MapService.openInfoWindow;

    $scope.selectedLine = null;

    $scope.toggleSelection = function (selectedLineId) {

        $scope.selectedLine = $scope.selectedLine != selectedLineId ? selectedLineId : null;

        MapService.markers.forEach(function (marker) {
            if (marker.station.LineId == $scope.selectedLine) {
                marker.setIcon(MapService.MarkerIcons.greenIcon);
            } else {
                marker.setIcon(MapService.MarkerIcons.redIcon);
            }
        });
    };

}]);




