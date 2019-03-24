//função fábrica
app.factory("userAPI", function ($http, config) {
    var _getUsers = function () {
        return $http({
            method: 'get',
            url: config.baseUrl + 'users/getClients',
        });
    };

    var _getUserById = function (id) {
        return $http({
            method: 'get',
            url: config.baseUrl + 'users/getUserById/' + id,
        });
    };

    var _saveUser = function (user) {
        //return $http.post(config.baseUrl + 'users', user, { dataType: 'json' });

        return $http.post(config.baseUrl + 'users', user, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
    };

    var _editUser = function (user) {
        return $http.put(config.baseUrl + 'users/put', user, { dataType: 'json' });
    };

    var _deleteUser = function (userId) {
        return $http.delete(config.baseUrl + "users/deleteUser/?userId=" + userId, { dataType: 'json' });
    };

    return {
        getUsers: _getUsers,
        getUserById: _getUserById,
        saveUser: _saveUser,
        editUser: _editUser,
        deleteUser: _deleteUser
    }
});