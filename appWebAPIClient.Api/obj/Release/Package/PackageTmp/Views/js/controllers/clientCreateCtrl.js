app.controller('clientCreateCtrl', function ($scope, clientAPI, showError) {
    $scope.client = {};
    $scope.validationErrors = [];

    $scope.addClient = function (client) {

        clientAPI.saveClient(client)
            .then(function (response) { // success

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                delete $scope.validationErrors;
                delete $scope.client;
                alert(data);
            }, function (response) { // error

                var data = response.data,
                    status = response.status,
                    header = response.header,
                    config = response.config;

                showError.showValidationErrors($scope, response);
            });
    };

});