(function (app) {
    var KisiTanimaController = function ($scope, $http,$location,$window) {
        $scope.deneme = "asd";
        //1.Sayfa
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
        //2.sayfa
        $scope.IkinciSayfa = function () {
            $http.post("/Ikinci/KisiDetayEkle?babaAd=" + $scope.babaAd + "&anneAdSoyad=" + $scope.anneAd + "&ingilizceSeviye=" + $scope.ingilizceSeviye + "&pasaport=" + $scope.pasaport + "&dogumTarih=" + $scope.dogumTarih + "&skype=" + $scope.skype + "&tamAdres=" + $scope.tamAdres + "&adresIkinciSatir=" + $scope.adresIkinciSatir + "&eyalet=" + $scope.bilgiEyalet + "&postaKod=" + $scope.bilgiPostaKod + "&ulkeId=" + $scope.bilgiUlke + "&acilAd=" + $scope.acilAd + "&acilSoyad=" + $scope.acilSoyad + "&acilTel=" + $scope.acilTel + "&adresEyaletId=" + $scope.adresEyalet + "&adresUlkeId=" + $scope.adresUlke)
                .success(function (data) {
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

        $http.get("/Ikinci/EyaletCek").success(function (data) {
            $scope.eyalets = data;
        }).error(function (data) {
            console.log(data);
        });
        

        $scope.UcuncuSayfa = function () {
            $http.post("/Ucuncu/EgitimEkle?liseAd=" + $scope.liseAd + "&baslangic=" + $scope.liseBaslangic + "&bitis=" + $scope.liseBitis + "&alan=" + $scope.liseAlan + "&liseTamAdres=" + $scope.liseTamAdres + "&liseAdresIkinciSatir=" + $scope.liseAdresIki + "&liseEyalet=" + $scope.liseAdresEyalet + "&lisePostaKodu=" + $scope.liseAdresPostaKod + "&liseUlkeId=" + $scope.liseAdresUlke + "&universiteAd=" + $scope.universiteAd + "&sinif=" + $scope.universiteSinif + "&bolum=" + $scope.universiteBölüm + "&okulNo=" + $scope.universiteNo + "&acilis=" + $scope.universiteBaslangic + "&kapanis=" + $scope.universitekapanis + "&uniTel=" + $scope.universiteTel + "&uniTamAdres=" + $scope.universiteTamAdres + "&uniAdresIkinciSatir=" + $scope.universiteAdresIki + "&uniEyalet=" + $scope.universiteAdresEyalet + "&uniPostaKodu=" + $scope.universiteAdresPostaKod + "&uniUlkeId=" + universiteAdresUlke)
                .success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/DorduncuSayfa';
                    }
                }).error(function (data) {
                    console.log(data);
                });
        }
    }
    app.controller("KisiTanimaController", KisiTanimaController);
}(angular.module("KisiModul")))