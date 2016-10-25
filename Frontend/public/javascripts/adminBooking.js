app.controller("AdminBookingController", function ($scope, $http) {
    $http.get('http://airlinereservation.somee.com/api/v1/Bookings').success(function (data, status, headers, config) {
        $scope.adminBookingCtrl.bookings = data;
        console.log(data);
    }).error(function (data, status, headers, config) {
        // log error
        alert("Có lỗi!!!");
    });
});