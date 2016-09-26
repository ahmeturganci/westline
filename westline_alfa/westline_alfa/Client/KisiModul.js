(function () {

    var app = angular.module('KisiModul', ["ngRoute"]);
    var config = (function ($routeProvider) {
        $routeProvider
         .when("/BirinciSayfa", {
             templateUrl: "/Client/Views/BirinciSayfa.html"
         })
         .otherwise({
             redirectTo: "/BirinciSayfa"
         });
    });

    app.config(config);
}())