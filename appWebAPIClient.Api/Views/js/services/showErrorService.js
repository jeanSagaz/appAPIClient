app.provider("showError", function () {

    this.$get = function () {
        return {
            showValidationErrors: function ($scope, error) {
                $scope.validationErrors = [];
                $scope.validationErrors.push(error.data);
            }

        };
    };

});