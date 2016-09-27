﻿(function () {
    var app = angular.module("KisiModul", ["ngRoute"]);


    var config = (function ($routeProvider) {
        $routeProvider
         .when("/BirinciSayfa", {
             templateUrl: "/Client/Views/BirinciSayfa.html"
         })
            .when("/IkinciSayfa", {
                templateUrl: "/Client/Views/IkinciSayfa.html"
            }).
       when("/UcuncuSayfa",{
        templateUrl: "/Client/Views/UcuncuSayfa.html"
    })
         .otherwise({
             redirectTo: "/BirinciSayfa"
         });
    });

    app.config(config);
}())