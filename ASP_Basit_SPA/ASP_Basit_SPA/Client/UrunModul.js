(function(){
    var app = angular.module("UrunModul", ["ngRoute"]);

  
    var config = (function ($routeProvider) {
        $routeProvider
         .when("/list", {
             templateUrl: "/Client/Views/list.html"
         })
         .when("/detay/:id", {
             templateUrl: "/Client/Views/detay.html"
         })
         .otherwise({
              redirectTo: "/list"
         });
    });
    
    app.constant("urunUrl", "/api/uruns/");
    app.config(config);
}())