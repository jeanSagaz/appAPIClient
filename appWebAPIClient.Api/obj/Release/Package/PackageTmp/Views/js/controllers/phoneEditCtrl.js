app.controller('phoneEditCtrl', function ($scope, $location, $routeParams, phoneAPI, showError) {
    $scope.phone = {};
    $scope.validationErrors = [];

    //$http({
    //    method: 'get',
    //    url: baseUrl + 'phones/getPhoneById/' + $routeParams.id,
    //})
    phoneAPI.getPhoneById($routeParams.id)
    .success(function (response) {
        if (response.errors) {
            showError.showValidationErrors($scope, response);
        } else {
            $scope.phone = response;
        }
    })
    .error(function (data, status) {
        if (status == 401)
            $location.path('/loginUser');
    });

    $scope.editPhone = function (phone) {

        //$http.put(baseUrl + 'phones/putPhone', phone, { dataType: 'json' })
        phoneAPI.editPhone(phone)
            .then(function (response) { // success

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                delete $scope.validationErrors;
                alert(data);
            }, function (response) { // error

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                if (status == 401)
                    $location.path('/loginUser');

                showError.showValidationErrors($scope, response);
            });

    };
});