(function (app) {
    var KisiTanimaController = function ($scope, $http,$location,$window) {
        $scope.deneme = "asd";
        $scope.BirinciSayfa = function () {
            $http.post("Birinci/KisiEkle?tc=" + $scope.tc + "&ad=" + $scope.ad + "&ortaAd=" + $scope.ortaAd + "&soyad=" + $scope.soyad + "&email=" + $scope.email + "&tel=" + $scope.tel).
                
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/IkinciSayfa';
                    }
                }).error(function (data) {
                    console.log(data);
                });
        }
        $scope.IkinciSayfa = function () {
            $http.post("/Ikinci/KisiDetayEkle?babaAd=" + $scope.babaAd + "&anneAd=" + $scope.anneAd + "&ingilizceSeviye=" + $scope.ingilizceSeviye + "&pasaport=" + $scope.pasaport + "&dogumTarih=" + $scope.dogumTarih + "&skype=" + $scope.skype + "&adresIkinciSatir=" + $scope.adresIkinciSatir + "&sehir=" + $scope.sehir + "&eyalet=" + $scope.eyalet + "&postaKod=" + $scope.postaKod + "&ulkeId=" + $scope.ulkeId + "&acilAd=" + $scope.acilAd + "&acilSoyad=" + $scope.acilSoyad + "&acilTel=" + $scope.acilTel)
            success(function (data) {
                console.log(data.basari);
                if (data.basari == 1) {
                    $window.location.href = '#/UcuncuSayfa';
                }
            }).error(function (data) {
                console.log(data);
            });

        }
        $http.get("/Ikinci/UlkeCek").success(function (data) {
            $scope.ulkes = data;
        }).error(function (data) {
            console.log(data);
        });
        
    }
    app.controller("KisiTanimaController", KisiTanimaController);
}(angular.module("KisiModul")))