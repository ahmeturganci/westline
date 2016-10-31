
(function () {
    var app = angular.module("KisiModul", ["ngRoute"]);


    var config = (function ($routeProvider) {
        $routeProvider .when("/Profil", {
             templateUrl: "/Client/Views/BirinciSayfa.html"
         }).when("/Aktivasyon", {
             templateUrl: "/Client/Views/Aktivasyon.html"
         })
            .when("/Cv", {
                templateUrl: "/Client/Views/Cv.html"
            })
            .when("/EkBilgi", {
                templateUrl: "/Client/Views/IkinciSayfa.html"
            }).
       when("/Egitim", {
           templateUrl: "/Client/Views/UcuncuSayfa.html"
       }).when("/isler", {
           templateUrl: "/Client/Views/isler.html"
       }).
        when("/Evrak", {
            templateUrl: "/Client/Views/DorduncuSayfa.html"
        }).
        when("/RandevuAl", {
            templateUrl: "/Client/Views/RandevuAl.html"
        })
             .when("/Ds160", {
                 templateUrl: "/Client/Views/BesinciSayfa.html"
             })
            .when("/UcakBilgi", {
                templateUrl: "/Client/Views/UcakBilgi.html"
            })
            .when("/TaksitBilgi", {
                templateUrl: "/Client/Views/taksitbilgi.html"
            })
            .when("/Dashboard", {
                templateUrl: "/Client/Views/dashboard.html"
            })
            .when("/Wat", {
                templateUrl: "/Client/Views/Wat.html"
            })
            
         .otherwise({
             redirectTo: "/Dashboard"
         });
    });

    app.config(config);
}())