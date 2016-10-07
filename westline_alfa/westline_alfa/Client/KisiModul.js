
(function () {
    var app = angular.module("KisiModul", ["ngRoute"]);


    var config = (function ($routeProvider) {
        $routeProvider
         .when("/Profil", {
             templateUrl: "/Client/Views/BirinciSayfa.html"
         }).when("/Aktivasyon", {
             templateUrl: "/Client/Views/Aktivasyon.html"
         })
            .when("/IkinciSayfa", {
                templateUrl: "/Client/Views/IkinciSayfa.html"
            }).
       when("/UcuncuSayfa", {
           templateUrl: "/Client/Views/UcuncuSayfa.html"
       }).when("/Pasaport", {
           templateUrl: "/Client/Views/Pasaport.html"
       }).
        when("/DorduncuSayfa", {
            templateUrl: "/Client/Views/DorduncuSayfa.html"
        })
             .when("/BesinciSayfa", {
                 templateUrl: "/Client/Views/BesinciSayfa.html"
             })
            .when("/UcakBilgi", {
                templateUrl: "/Client/Views/UcakBilgi.html"
             })

            
         .otherwise({
             redirectTo: "/UcakBilgi"
         });
    });

    app.config(config);
}())