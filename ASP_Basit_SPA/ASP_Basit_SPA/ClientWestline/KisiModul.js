(function () {

    var app = angular.module('KisiModul', ["ngRoute"]);



    var config = (function ($routeProvider) {
        $routeProvider
         .when("/kisitanima", {
             templateUrl: "/ClientWestline/ViewsWestline/kisitanima.html"
         })
           /* .when("/kisitanima", {
                templateUrl: "/ClientWestline/ViewsWestline/iletisim.html"
            })*/

         .otherwise({
             redirectTo: "/kisitanima"
         });
    });


    app.constant("kisiUrl", "/api/kisis/");
    app.config(config);
}())