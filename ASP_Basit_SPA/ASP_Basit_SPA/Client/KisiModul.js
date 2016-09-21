(function () {
    var app = angular.module("KisiModul", ["ngRoute"]);


    var config = (function ($routeProvider) {
        $routeProvider
         .when("/KisiEkle", {
             templateUrl: "/Client/Views/KisiEkle.html"
         })
         .otherwise({
             redirectTo: "/list"
         });
    });

    app.constant("kisiUrl", "/api/kisis/");
    app.config(config);
}())