//função construtora
app.service("phoneAPI", function ($http, config, tokenAPI) {
    $http.defaults.headers.common['Authorization'] = 'Bearer ' + tokenAPI.getToken();

    this.getPhones = function (id) {
        return $http({
            method: 'get',
            url: config.baseUrl + 'phones/getAllbyClient/' + id,
        });
    };

    this.getPhoneById = function (id) {
        return $http({
            method: 'get',
            url: config.baseUrl + 'phones/getPhoneById/' + id,
        });
    };

    this.savePhone = function (phone) {
        return $http.post(config.baseUrl + '/phones/register', phone, {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + tokenAPI.getToken()
            }
        });
    };

    this.editPhone = function (phone) {
        return $http.put(config.baseUrl + 'phones/putPhone', phone, { dataType: 'json' });
    };

    this.deletePhone = function (phoneId) {
        return $http.delete(config.baseUrl + "phones/deletePhone/?phoneId=" + phoneId, { dataType: 'json' });
    };
});