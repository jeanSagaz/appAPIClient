//função fábrica
app.factory("loginAPI", function ($http, config) {

    var _loginUser = function (user) {
        var data = "grant_type=password&username=" + user.email + "&password=" + user.password;
        return $http.post(config.baseUrl + 'security/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
    };

    return {
        loginUser : _loginUser
    }
});