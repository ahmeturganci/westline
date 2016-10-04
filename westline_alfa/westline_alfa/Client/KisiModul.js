
(function () {
    var app = angular.module("KisiModul", ["ngRoute"]);


    var config = (function ($routeProvider) {
        $routeProvider
         .when("/BirinciSayfa", {
             templateUrl: "/Client/Views/BirinciSayfa.html"
         })
            .when("/IkinciSayfa", {
                templateUrl: "/Client/Views/IkinciSayfa.html"
            }).
       when("/UcuncuSayfa", {
           templateUrl: "/Client/Views/UcuncuSayfa.html"
       }).
        when("/DorduncuSayfa", {
            templateUrl: "/Client/Views/DorduncuSayfa.html"
        })
            .when("/EvrakSayfasi",{
                templateUrl: "/Client/Views/EvrakSayfasi.html"
            })
             .when("/BesinciSayfa", {
                 templateUrl: "/Client/Views/BesinciSayfa.html"
             })
            
         .otherwise({
             redirectTo: "/BirinciSayfa"
         });
    });

    app.config(config);
}())