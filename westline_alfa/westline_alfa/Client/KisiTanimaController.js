(function (app) {
    var KisiTanimaController = function ($scope, $http,$location,$window) {
        
        $scope.BirinciSayfa = function () {
            $http.post("/Birinci/EgitimEkle?tc=" + $scope.tc + "&liseAd=" + $scope.liseAd + "&baslangic=" + $scope.baslangic + "&bitis=" + $scope.bitis + "&alan=" + $scope.alan + "&liseTamAdres=" + $scope.liseTamAdres + "&liseTamAdresIkinciSatir=" + $scope.liseTamAdresIkinciSatir + "&liseSehir=" + $scope.liseSehir + "&liseEyalet=" + $scope.liseEyalet + "&lisePostaKod=" + $scope.lisePostaKod + "&liseUlkeId=" + $scope.liseUlkeId + "&uniAd=" + $scope.uniAd + "&sinif=" + $scope.sinif + "&bolum=" + $scope.bolum + "&okulNo=" + $scope.okulNo + "&acilisT=" + $scope.acilisT + "&kapanisT=" + $scope.kapanisT + "&uniTamAdres=" + $scope.uniTamAdres + "&uniTamAdresIki=" + $scope.uniTamAdresIki + "&uniSehir=" + $scope.uniSehir + "&uniEyalet=" + $scope.uniEyalet + "&uniPostaKod=" + $scope.uniPpstaKod + "&uniUlkeId=" + $scope.uniUlkeId).
                
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/IkinciSayfa';
                    }
                    
                }).error(function (data) {
                    console.log(data);
                });

            
           
        }
    }
    app.controller("KisiTanimaController", KisiTanimaController);
}(angular.module("KisiModul")))