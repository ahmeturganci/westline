(function (app) {
    var IkinciSayfaController = function ($scope, $http) {
        $scope.kaydet = function () {
            $http.post("Birinci/KisiEkle?tc=" + $scope.tc + "&ad=" + $scope.ad + "&ortaAd=" + $scope.ortaAd + "&soyad=" + $scope.soyad + "&email=" + $scope.email + "&tel=" + $scope.tel).
                success(function (data) {
                    console.log(data.basari);
                }).error(function (data) {
                    console.log(data);
                });


        }
    }
    app.controller("IkinciSayfaController", IkinciSayfaController);
}(angular.module("KisiModul")))