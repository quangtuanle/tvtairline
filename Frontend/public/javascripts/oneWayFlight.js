app.controller("FlightOneWayController", function ($scope, $http) {

    var origin = localStorage.getItem("origin");
    var destination = localStorage.getItem("destination");
    $scope.flightOneWay.originName = localStorage.getItem("originName");
    $scope.flightOneWay.destinationName = localStorage.getItem("destinationName");
    var departureDates = localStorage.getItem("departureDates");
    var passengerQuantity = localStorage.getItem("passengerQuantity");

    var date = new Date(departureDates);
    $scope.flightOneWay.flights = [];

    var url = "http://airlinereservation.somee.com/api/v1/Flights?origin=" + origin
        + "&destination=" + destination + "&departureDates=" + date.toISOString().slice(0, 10).replace('/g', "") + "&passengerquantity=" + passengerQuantity;

    $http.get(url)
        .success(function (data, status, headers, config) {
            $scope.flightOneWay.flights.push(parseFlightData(data, date.toISOString().slice(0, 10).replace('/g', "")));
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

    $scope.onFlightSelect = function (index) {
        $scope.flightOneWay.flightSelect = index;
        $scope.passengerQuantity = passengerQuantity;
    };

    $scope.flightOneWay.onContinueClick = function () {
        var bookingCode = createBookingCode();

        insertFlight(bookingCode, $scope.flightOneWay.flightSelect.FlightCode, $scope.flightOneWay.flightSelect.DepartureDates,
            $scope.flightOneWay.flightSelect.ClassLevel, $scope.flightOneWay.flightSelect.PriceLevel);

        localStorage.setItem("bookingCode", bookingCode);
        window.location = "/passengers"
    };

    function createBookingCode() {
        if ($scope.flightOneWay.flightSelect != null) {
            $http.post("http://airlinereservation.somee.com/api/v1/Bookings?payment=" + $scope.flightOneWay.flightSelect.Price)
                .success(function (data) {
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
            localStorage.setItem("bookingCode", data);
            return data;
        }).error(function (error) {
            alert("Có lỗi!!!");
            return false;
        });
    }
});