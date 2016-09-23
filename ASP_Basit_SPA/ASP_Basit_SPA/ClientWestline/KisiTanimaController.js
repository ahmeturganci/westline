(function (app) {
    //ekleme işi 
    var KisiTanimaController= function ($scope, $http, KisiServis) {
        $scope.kaydet = function () {
         
            
                //id yok ekleme 
                KisiServis.ekle($scope.ekle.kisi).success(function (kisi) {
                    $scope.kisi.push(kisi);
                    $scope.kisi = null;
                    
                })
            
        }

    }
  app.controller("KisiTanimaController", KisiTanimaController);
    }(angular.module("KisiModul")))