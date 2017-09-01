app.controller('phoneCreateCtrl', function ($scope, $routeParams, $location, phoneAPI, showError) {
    $scope.phone = {};
    $scope.validationErrors = [];
    $scope.phone.clientId = $routeParams.id;

    $scope.addPhone = function (phone) {

        //$http.post(baseUrl + '/phones/register', phone, { dataType: 'json' })
        phoneAPI.savePhone(phone)
            .then(function (response) { // success

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                delete $scope.validationErrors;
                delete $scope.phone.number;
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