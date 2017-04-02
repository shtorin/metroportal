ngMetroApp.factory('MapService', [function () {
    
    var MapService = {};

    MapService.MarkerIcons = {
        greenIcon: 'http://maps.google.com/mapfiles/ms/icons/green-dot.png',
        redIcon: 'http://maps.google.com/mapfiles/ms/icons/red-dot.png'
    };

    MapService.mapOptions = {
        zoom: 10,
        center: new google.maps.LatLng(55.753709, 37.61981338),
        mapTypeId: google.maps.MapTypeId.TERRAIN
    }

    MapService.options = {
        scrollwheel: false
    };

    MapService.markers = [];

    var infoWindow = new google.maps.InfoWindow();

    MapService.getMap = function (elemendId, mapOptions) {
        return new google.maps.Map(document.getElementById(elemendId), mapOptions);
    }

    MapService.createMarker = function (currentMap, station, icon, label, displayLabel) {

        var marker = new google.maps.Marker({
            map: currentMap,
            position: new google.maps.LatLng(station.Latitude, station.Longtitude),
            icon: google.maps.icon,
            content: getStationInfoContent(station),
            label: displayLabel ? label : null,
            icon: icon,
            // добавляем каждому маркеру ссылку на соответствующую ему станцию
            station: station
        });

        google.maps.event.addListener(marker, 'click', function () {
            // Устанавливаем содержимое инфоокна
            infoWindow.setContent(marker.content);
            infoWindow.open(currentMap, marker);
        });

        MapService.markers.push(marker);
    }

    MapService.removeLastMarker = function () {
        var markersCount = MapService.markers.length;        
        // Выключаем маркер
        MapService.markers[markersCount - 1].setMap(null);
        // Удаляем ссылку на маркер из массива
        MapService.markers.splice(markersCount - 1, 1);
    };

    MapService.openInfoWindow = function (e, selectedStation) {
        e.preventDefault();

        var markers = MapService.markers.filter(function (marker) {
            return marker.station.StationId == selectedStation.StationId;
        });

        var selectedMarker = markers.length > 0 ? markers[0] : null;

        if (selectedMarker != null) {
            google.maps.event.trigger(selectedMarker, 'click');
        };
    }
    
    var getStationInfoContent = function (station) {
        transfersContent = '<p>' + $.map(station.TransfersTo, function (s) {
            return '<span class="glyphicon glyphicon-th line_' + s.Line.Color + '"></span>' + s.StationName + ' (' + s.Line.LineName + ')</span>';
        }).join('<br/>') + '</p>';
        content = '<h3>' + station.StationName + '</h3>' + '<div class="infoWindowContent"><strong>Переходы:</strong> ' + (station.TransfersTo.length > 0 ? transfersContent : "—") + '</div>';

        return content;
    };

    return MapService;

}]);