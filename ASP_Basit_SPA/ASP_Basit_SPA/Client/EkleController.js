(function (app) {
    var EkleController = function ($scope, UrunServis) {

        $scope.kaydet = function () {
            if ($scope.ekle.uruns.Id) {
                //ürün var güncelleme
                UrunServis.guncelle($scope.ekle.uruns).success(function(){
                    angular.extend($scope.uruns, $scope.ekle.uruns);
                    $scope.ekle.uruns = null;
                })
                
            }
            else {
                //id yok ekleme 
                    UrunServis.ekle($scope.ekle.uruns).success(function(uruns){
                    $scope.uruns.push(uruns);
                    $scope.ekle.uruns=null; 
                })
            }
        }
    

        $scope.goster = function () {
            
            return $scope.ekle && $scope.ekle.uruns;
        }
    }
    app.controller("EkleController", EkleController);
}(angular.module("UrunModul")))