app.controller('clientEditCtrl', function ($scope, $routeParams, $location, clientAPI, showError) {
    $scope.client = {};
    $scope.validationErrors = [];

    //$http({
    //    method: 'get',
    //    url: baseUrl + 'clients/getClientById/' + $routeParams.id,
    //})
    clientAPI.getClientById($routeParams.id)
    .success(function (response) {
        if (response.errors) {
            showError.showValidationErrors($scope, response);
        } else {
            $scope.client = response;
        }
    })
    .error(function (data, status) {
        if (status == 401)
            $location.path('/loginUser');
    });

    $scope.editClient = function (client) {

        //$http.put(baseUrl + 'clients/putClient', client, { dataType: 'json' })
        clientAPI.editClient(client)
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