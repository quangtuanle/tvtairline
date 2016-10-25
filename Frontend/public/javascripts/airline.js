(function () {
    var app = angular.module("AirlineReservation", []);

    app.factory('dataShare',function($rootScope){
        var service = {};
        service.data = false;
        service.sendData = function(data){
            this.data = data;
            $rootScope.$broadcast('data_shared');
        };
        service.getData = function(){
            return this.data;
        };
        return service;
    });

    app.controller("SearchController", function ($scope, $http, dataShare){
        $scope.OriginClick = function() {
            $http.get('http://airlinereservation.somee.com/api/v1/Origins').success(function (data, status, headers, config) {
                $scope.search.fromPlaces = parseData(data);
            }).error(function (data, status, headers, config) {
                // log error
                alert("Có lỗi!!!");
            });
        };

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
                $http.get('http://airlinereservation.somee.com/api/v1/Destinations?origin=' + $scope.selectedOrigin.AirPortCode).success(function (data, status, headers, config) {
                    $scope.search.toPlaces = parseData(data);
                }).error(function (data, status, headers, config) {
                    // log error
                    alert("Có lỗi!!!");
                });
            }
        };

        $scope.getFromPlace = function(item) {
            $scope.selectedOrigin = item;
        };

        $scope.getToPlace = function(item) {
            $scope.selectedDestination = item;
        };

        // $scope.GoToFlight = function(origin, destination) {
        //     var flight = {};
        //     flight["origin"] = origin;
        //     flight["destination"] = destination;
        //     flight["departureDates"] = $('.tb-input.datetimepickerWidget.date-in').val();
        //     flight["passengerQuantity"] = 2;
        //     dataShare.sendData(flight);
        //     window.location = "/one-way-flights";
        // };

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


    app.controller("FlightOneWayController", function(dataShare, $scope, $http){

        var flight;
        $scope.$on('data_shared',function() {
            console.log(dataShare.getData());
            flight = dataShare.getData();
        });
        // console.log(flight.departureDates);
        // console.log(flight.destination);
        // //var date = new Date("2016-10-05");
        // $scope.flightOneWay.flights = [];
        // for (var i = 0; i < 7; i++) {
        //     var url = "http://airlinereservation.somee.com/api/v1/Flights?origin=" + flight.origin
        //         + "&destination=" + flight.destination + "&departureDates=" + date.toISOString().slice(0, 10).replace('/g',"") + "&passengerquantity=" + flight.passengerQuantity;
        //     //var url = "http://airlinereservation.somee.com/api/v1/Flights?origin=SGN&destination=TBB&departuredates=" + date.toISOString().slice(0, 10).replace('/g',"") + "&passengerquantity=1";
        //     $http.get(url)
        //         .success(function (data, status, headers, config) {
        //             $scope.flightOneWay.flights.push(parseFlightData(data, date.toISOString().slice(0, 10).replace('/g',"")));
        //         }).error(function (data, status, headers, config) {
        //         // log error
        //         alert("Có lỗi!!!");
        //     });
        //     date.setDate(date.getDate() + 1);
        // }
        //
        // function parseFlightData(data, departureDates) {
        //     var place = {};
        //     place["date"] = angular.copy(departureDates);
        //     place["itemFlights"] = data;
        //     return place;
        // }
    });

    app.controller("FlightRoundTripController", function(){

    });

})();




