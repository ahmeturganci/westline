(function (app) {
    //ekleme işi 
    var KisiTanimaController= function ($scope, $http) {
        $scope.kaydet = function () {
         
            //api
            $http.post("http://localhost:11226/Api/Kisi?tcKimlikNo=" +$scope.tc+ "&ad="+$scope.ad+"&ortaAd="+$scope.ortaAd+"&soyad="+$scope.soyad+"&email="+$scope.email+"&tel="+$scope.tel).
                success(function (data) {
                    console.log("başarılı");
                }).error(function (data) {
                    console.log("hata");
                });
            
        }

    }
  app.controller("KisiTanimaController", KisiTanimaController);
    }(angular.module("KisiModul")))