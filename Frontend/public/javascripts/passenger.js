app.controller("PassengersController", function ($scope, $http) {
    $scope.passengers.onContinueClick = function () {
        var bookingCode = localStorage.getItem("bookingCode");
        var currentDate = new Date();
        var birthday = new Date($('.tb-input.datetimepickerWidget.date-of-birth').val());
        var age = currentDate.getYear() - birthday.getYear();
        var ageCode;
        if (age < 2)
            ageCode = 2;
        else if (age <= 12)
            ageCode = 1;
        else ageCode = 0;
        $http.post("http://airlinereservation.somee.com/api/v1/Passengers?bookingcode=" + bookingCode +
            "&epithets=" + $scope.passengers.genderType + "&firstname=" + $scope.passengers.firstname +
            "&lastname=" + $scope.passengers.lastname + "&agecode=" + ageCode)
            .success(function (data) {
                if (data == true) {
                    alert("Đặt vé thành công!!!");
                }
                else alert("Đặt vé thất bại!!!")
            }).error(function (error) {
            alert("Có lỗi!!!");
            return null;
        });
    }
});