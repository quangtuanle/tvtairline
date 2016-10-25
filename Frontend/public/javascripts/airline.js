(function () {
    var app = angular.module("AirlineReservation", []);

    app.controller("SearchController", function (){
        this.fromPlaces = [
            {
                groupName: 'Asian',
                items: [
                    'Vietnam',
                    'Lao',
                    'Campuchia'
                ]
            },
            {
                groupName: 'Europe',
                items: [
                    'Vietnam',
                    'Lao',
                    'Campuchia'
                ]
            }
        ];
        this.toPlaces = [
            {
                groupName: 'Asian',
                items: [
                    'Vietnam',
                    'Lao',
                    'Campuchia'
                ]
            },
            {
                groupName: 'Europe',
                items: [
                    'Vietnam',
                    'Lao',
                    'Campuchia'
                ]
            }
        ];
    });

    app.controller("FlightOneWayController", function(){

    });

    app.controller("FlightRoundTripController", function(){

    });

})();



