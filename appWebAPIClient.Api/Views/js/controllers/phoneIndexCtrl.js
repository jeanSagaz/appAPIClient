app.controller('phoneIndexCtrl', function ($scope, $routeParams, $location, phoneAPI, showError) {
    $scope.phones = {};
    $scope.validationErrors = [];
    $scope.clientId = $routeParams.id;

    //$http({
    //    method: 'get',
    //    url: baseUrl + 'phones/getAllbyClient/' + $routeParams.id,
    //})
    phoneAPI.getPhones($routeParams.id)
    .success(function (response) {
        if (response.errors) {
            showError.showValidationErrors($scope, response);
        } else {
            $scope.phones = response;
        }
    })
    .error(function (data, status) {
        if (status == 401)
            $location.path('/loginUser');
    });

    $scope.deletePhone = function (phoneId) {

        var resp = confirm("Deseja realmente excluir o telefone?");
        if (resp) {
            //$http.delete(baseUrl + "phones/deletePhone/?phoneId=" + phoneId, { dataType: 'json' })
            phoneAPI.deletePhone(phoneId)
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