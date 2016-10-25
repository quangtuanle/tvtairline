(function () {
    var app = angular.module("AirlineReservation", []);

    app.controller("SearchController", function ($scope, $http){
        $scope.OriginClick = function() {
            $http.get('http://airlinereservation.somee.com/api/v1/Origins').success(function (data, status, headers, config) {
                $scope.search.fromPlaces = parseData(data);
            }).error(function (data, status, headers, config) {
                // log error
                alert("Có lỗi!!!");
            });
        }

        $scope.DestinationClick = function() {
            if ($scope.selectedOrigin == null) {
                $http.get('http://airlinereservation.somee.com/api/v1/Destinations').success(function (data, status, headers, config) {
                    $scope.search.toPlaces = parseData(data);
                }).error(function (data, status, headers, config) {
                    // log error
                    alert("Có lỗi!!!");
                });
            }
            else {
                //Test thử
                $scope.selectedOrigin = "SGN";
                $http.get('http://airlinereservation.somee.com/api/v1/Destinations?origin=' + $scope.selectedOrigin).success(function (data, status, headers, config) {
                    $scope.search.toPlaces = parseData(data);
                }).error(function (data, status, headers, config) {
                    // log error
                    alert("Có lỗi!!!");
                });
            }
        }

        function parseData(data) {
            var groups = [];
            var places = [];

            for (var i = 0; i < data.length; i++) {
                if (!groups.includes(data[i].Area)) {
                    groups.push(data[i].Area);
                }
            }
            for (var i = 0; i < groups.length; i++) {
                var items = [];
                for (var j = 0; j < data.length; j++) {
                    if (groups[i] == data[j].Area) {
                        items.push(data[j]);
                    }
                }
                var place = {};
                place["groupName"] = groups[i];
                place["items"] = items;
                places.push(place);
            }
            return places;
        }
    });

    app.controller("FlightOneWayController", function(){

    });

    app.controller("FlightRoundTripController", function(){

    });

})();



