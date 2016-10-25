app.controller("FlightRoundTripController", function ($scope, $http) {
    var origin = localStorage.getItem("origin");
    var destination = localStorage.getItem("destination");
    $scope.flightRoundTrip.originName = localStorage.getItem("originName");
    $scope.flightRoundTrip.destinationName = localStorage.getItem("destinationName");
    var departureDates = localStorage.getItem("departureDates");
    var ArriveDates = localStorage.getItem("arriveDates");
    var passengerQuantity = localStorage.getItem("passengerQuantity");

    var checkIndate = new Date(departureDates);
    var checkOutdate = new Date(ArriveDates);
    $scope.flightRoundTrip.firstFlights = [];
    $scope.flightRoundTrip.secondFlights = [];

    var url = "http://airlinereservation.somee.com/api/v1/Flights?origin=" + origin
        + "&destination=" + destination + "&departureDates=" + checkIndate.toISOString().slice(0, 10).replace('/g', "") + "&passengerquantity=" + passengerQuantity;

    $http.get(url)
        .success(function (data, status, headers, config) {
            $scope.flightRoundTrip.firstFlights.push(parseFlightData(data, checkIndate.toISOString().slice(0, 10).replace('/g', "")));
        }).error(function (data, status, headers, config) {
        // log error
        alert("Có lỗi!!!");
    });

    url = "http://airlinereservation.somee.com/api/v1/Flights?origin=" + destination
        + "&destination=" + origin + "&departureDates=" + checkOutdate.toISOString().slice(0, 10).replace('/g', "") + "&passengerquantity=" + passengerQuantity;

    $http.get(url)
        .success(function (data, status, headers, config) {
            $scope.flightRoundTrip.secondFlights.push(parseFlightData(data, checkOutdate.toISOString().slice(0, 10).replace('/g', "")));
        }).error(function (data, status, headers, config) {
        // log error
        alert("Có lỗi!!!");
    });

    function parseFlightData(data, departureDates) {
        var flight = {};
        flight["date"] = departureDates;
        flight["itemFlights"] = data;
        return flight;
    }

    $scope.onFirstFlightSelect = function (index) {
        $scope.flightRoundTrip.firstFlightSelect = index;
        $scope.passengerQuantity = passengerQuantity;
    };
    $scope.onSecondFlightSelect = function (index) {
        $scope.flightRoundTrip.secondFlightSelect = index;
        $scope.passengerQuantity = passengerQuantity;
    };

    $scope.flightRoundTrip.onContinueClick = function () {
        var bookingCode = createBookingCode();

        insertFlight(bookingCode, $scope.flightRoundTrip.firstFlightSelect.flightCode, $scope.flightRoundTrip.firstFlightSelect.departureDates,
            $scope.flightRoundTrip.firstFlightSelect.classLevel, $scope.flightRoundTrip.firstFlightSelect.priceLevel);

        insertFlight(bookingCode, $scope.flightRoundTrip.secondFlightSelect.flightCode, $scope.flightRoundTrip.secondFlightSelect.departureDates,
            $scope.flightRoundTrip.secondFlightSelect.classLevel, $scope.flightRoundTrip.secondFlightSelect.priceLevel);

        window.location = "/passengers"
    };

    function createBookingCode() {
        if ($scope.flightRoundTrip.firstFlightSelect != null && $scope.flightRoundTrip.secondFlightSelect != null) {
            $http.post("http://airlinereservation.somee.com/api/v1/Bookings?payment=" + ($scope.flightRoundTrip.firstFlightSelect.Price + $scope.flightRoundTrip.secondFlightSelect.Price))
                .success(function (data) {
                    localStorage.setItem("bookingCode", data);
                    return data;
                }).error(function (error) {
                alert("Có lỗi!!!");
                return null;
            });
        }
        else {
            alert("Vui lòng chọn chuyến bay!");
            return null;
        }
    }

    function insertFlight(bookingCode, flightCode, departureDates, classLevel, priceLevel) {
        $http.post("http://airlinereservation.somee.com/api/v1/FlightDetails?bookingcode=" + bookingCode +
            "&flightcode=" + flightCode + "&departuredates=" + departureDates + "&classlevel=" +
            classLevel + "&pricelevel=" + priceLevel).success(function (data) {
            return data;
        }).error(function (error) {
            alert("Có lỗi!!!");
            return false;
        });
    }
});