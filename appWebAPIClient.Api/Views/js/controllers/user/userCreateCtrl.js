app.controller('userCreateCtrl', function ($scope, $location, userAPI, showError) {
    $scope.user = {};
    $scope.validationErrors = [];

    $scope.addNewUser = function (user) {
        alert(user);
        userAPI.saveUser(user)
            .then(function (response) { // success

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                delete $scope.validationErrors;
                delete $scope.user;
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