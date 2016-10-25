app.controller("AdminFlightController", function ($scope, $http) {
    $http.get('http://airlinereservation.somee.com/api/v1/Flights').success(function (data, status, headers, config) {
        $scope.adminFlightCtrl.flights = data;
        console.log(data);
    }).error(function (data, status, headers, config) {
        // log error
        alert("Có lỗi!!!");
    });
});