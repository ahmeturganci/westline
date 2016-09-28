(function (app) {
    var IkinciSayfaController = function ($scope, $http) {

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

        $scope.deneme = "ert";
        console.log("s");
        $http.get("/Ikinci/UlkeCek").success(function (data) {
            $scope.ulkes = data;
        }).error(function (data) {
            console.log(data);
        });
    }
    app.controller("IkinciSayfaController", IkinciSayfaController);
}(angular.module("KisiModul")))