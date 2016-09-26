(function (app) {
    var IkinciSayfaController = function ($scope, $http) {
        $scope.kaydet = function () {
            $http.post("Birinci/KisiEkle?tc=" + $scope.tc + "&ad=" + $scope.ad + "&ortaAd=" + $scope.ortaAd + "&soyad=" + $scope.soyad + "&email=" + $scope.email + "&tel=" + $scope.tel).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari==1) {
                        //sayfa değişcek
                    }
                    else {
                        //console.lof(data.aciklama);
                        // sıkıntı
                    }
                }).error(function (data) {
                    console.log(data);
                });


        }
    }
    app.controller("IkinciSayfaController", IkinciSayfaController);
}(angular.module("KisiModul")))