app.controller('clientIndexCtrl', function ($scope, $location, clientAPI, showError) {
    $scope.clients = {};
    $scope.validationErrors = [];

    clientAPI.getClients()
    .success(function (response) {
        if (response.errors) {            
            showError.showValidationErrors($scope, response);
        } else {
            $scope.clients = response;
        }
    })
    .error(function (data, status) {
        if (status == 401)
            $location.path('/loginUser');
    });

    $scope.maritalStatus = function (codigo) {
        switch (codigo) {
            case 1:
                return result = 'Solteiro(a)';
                break;

            case 2:
                return result = 'Casado(a)';
                break;

            case 3:
                return result = 'Viúvo(a)';
                break;

            case 4:
                return result = 'Divorciado(a)';
                break;
        }
    };

    $scope.deleteClient = function (clientId) {

        var resp = confirm("Deseja realmente excluir o cliente?");

        if (resp) {
            //$http.delete(baseUrl + "clients/deleteClient/?clientId=" + clientId, { dataType: 'json' })
            clientAPI.deleteClient(clientId)
                .then(function (response) { // success

                    var data = response.data,
                        status = response.status,
                        header = response.header,
                        config = response.config;

                    alert(data);
                    location.reload();
                }, function (response) { // error

                    var data = response.data,
                        status = response.status,
                        header = response.header,
                        config = response.config;

                    if (status == 401)
                        $location.path('/loginUser');

                    showError.showValidationErrors($scope, response);
                });
        }

    };
});