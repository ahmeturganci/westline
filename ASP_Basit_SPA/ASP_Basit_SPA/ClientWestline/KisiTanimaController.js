(function (app) {
    //ekleme işi 
    var KisiTanimaController= function ($scope, $http) {
        $scope.kaydet = function () {

            //api
            /* $http.post("http://localhost:11226/Api/Kisi?tcKimlikNo=" +$scope.tc+ "&ad="+$scope.ad+"&ortaAd="+$scope.ortaAd+"&soyad="+$scope.soyad+"&email="+$scope.email+"&tel="+$scope.tel).
                 success(function (data) {
                     console.log("başarılı");
                 }).error(function (data) {
                     console.log("hata");
                 });
             
         }*/
            $http({
                url: 'http://localhost:11226/Api/Kisi?tcKimlikNo=' +$scope.tc+ "&ad="+$scope.ad+"&ortaAd="+$scope.ortaAd+"&soyad="+$scope.soyad+"&email="+$scope.email+"&tel="+$scope.tel,
                dataType: "json",
                method: "POST",
                data: JSON.stringify({ "foo": "bar" }),
                headers: {
                    "Content-Type": "application/json; charset=utf-8"
                }
            }).success(function (response) {
                $scope.response = response;
            }).error(function (error) {
                $scope.error = error;
            });
        }



    }
  app.controller("KisiTanimaController", KisiTanimaController);
    }(angular.module("KisiModul")))