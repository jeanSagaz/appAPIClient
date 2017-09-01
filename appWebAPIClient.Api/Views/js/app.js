var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {
    $routeProvider.when("/", {
        templateUrl: "view/Login/Index.html",
        controller: "loginUserCtrl"
    });
    $routeProvider.when("/clients", {                
        templateUrl: "view/Client/Index.html",
        controller: "clientIndexCtrl"
    });
    $routeProvider.when("/newClient", {
        templateUrl: "view/Client/Create.html",
        controller: "clientCreateCtrl"
    });
    $routeProvider.when("/editClient/:id", {
        templateUrl: "view/Client/Edit.html",
        controller: "clientEditCtrl"
    });
    $routeProvider.when("/Phones/:id", {
        templateUrl: "view/Phone/Index.html",
        controller: "phoneIndexCtrl"
    });
    $routeProvider.when("/newPhone/:id", {
        templateUrl: "view/Phone/Create.html",
        controller: "phoneCreateCtrl"
    });
    $routeProvider.when("/editPhone/:id", {
        templateUrl: "view/Phone/Edit.html",
        controller: "phoneEditCtrl"
    });

    //Login
    $routeProvider.when("/loginUser", {
        templateUrl: "view/Login/Index.html",
        controller: "loginUserCtrl"
    });
    //Novo usuário
    $routeProvider.when("/newUser", {
        templateUrl: "view/User/Create.html",
        controller: "userCreateCtrl"
    });

    $routeProvider.otherwise({ redirectTo: "/loginUser" });
});