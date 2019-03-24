app.controller('loginUserCtrl', function ($scope, $location, loginAPI, tokenAPI, showError) {
    $scope.user = {};
    $scope.validationErrors = [];

    $scope.login = function (user) {

        loginAPI.loginUser(user)
            .then(function (response) { // success

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                delete $scope.validationErrors;

                tokenAPI.setToken(data.access_token);
                $scope.isAuthenticated = true;
                $location.path('/clients');
                //$scope.token = response.access_token;
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