(function () {
    var app = angular.module("KisiModul", "ngRoute");

    var config = (function ($routeProvider) {
        $routeProvider
         .when("/kisitanima", {
             templateUrl: "/ClientWestline/Views/kisitanima.html"
         })
         .otherwise({
             redirectTo: "/list"
         });
    });
})