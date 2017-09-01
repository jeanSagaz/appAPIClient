//função fábrica
app.factory("clientAPI", function ($http, config, tokenAPI) {
    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenAPI.getToken();

    var _getClients = function () {
        return $http({
            method: 'get',
            url: config.baseUrl + 'clients/getClients',
            //configHeaders
        });
    };

    var _getClientById = function (id) {
        return $http({
            method: 'get',
            url: config.baseUrl + 'clients/getClientById/' + id,
        });
    };

    var _saveClient = function (client) {
        return $http.post(config.baseUrl + 'clients/register', client, {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + tokenAPI.getToken()
            }
        });

        //return $http({
        //    url: config.baseUrl + 'clients/register',
        //    method: 'post',
        //    data: client,
        //    headers: {
        //        'Content-Type': 'application/json',
        //        'Authorization': 'Bearer ' + tokenAPI.getToken()
        //    }
        //});
    };

    var _editClient = function (client) {
        return $http.put(config.baseUrl + 'clients/putClient', client, { dataType: 'json' });
    };

    var _deleteClient = function (clientId) {
        return $http.delete(config.baseUrl + "clients/deleteClient/?clientId=" + clientId, { dataType: 'json' });
    };    

    return {
        getClients: _getClients,
        getClientById: _getClientById,
        saveClient: _saveClient,
        editClient: _editClient,
        deleteClient: _deleteClient        
    }
});