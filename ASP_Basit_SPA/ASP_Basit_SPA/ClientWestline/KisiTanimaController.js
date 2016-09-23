(function (app) {
    //ekleme işi 
    var KisiTanimaController= function ($scope, $http) {
        $scope.kaydet = function () {
         
            
            //api
            $http.post("http://localhost:11226/Api/AcilDurum?ad=ertugrul&soyad=ungor&tel=111111111").
                success(function (data) {
                    console.log(data.content.username);
                }).error(function (data) {
                    console.log("hata");
                });
            
        }

    }
  app.controller("KisiTanimaController", KisiTanimaController);
    }(angular.module("KisiModul")))