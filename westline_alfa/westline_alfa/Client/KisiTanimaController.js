(function (app) {
    var KisiTanimaController = function ($scope, $http,$location,$window) {
        //1.Sayfa
        $scope.BirinciSayfa = function () {
            $http.post("Birinci/KisiEkle?tc=" + $scope.tc + "&ad=" + $scope.ad + "&ortaAd=" + $scope.ortaAd + "&soyad=" + $scope.soyad + "&email=" + $scope.email + "&tel=" + $scope.tel + "&kendiIs=" + $scope.kendiIs).
                
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/Aktivasyon';
                    } else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        //Aktivasyon
        $scope.Aktivasyon = function () {
            $http.post("Birinci/Kontrol?kod=" + $scope.kod).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/IkinciSayfa';
                    } else {
                        $scope.aktivasyonMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        //2.sayfa
        $scope.IkinciSayfa = function () {
            
          
                $http.post("/Ikinci/KisiDetayEkle?babaAd=" + $scope.babaAd + "&anneAdSoyad=" + $scope.anneAd + "&ingilizceSeviye=" + $scope.ingilizceSeviye + "&pasaport=" + $scope.pasaport + "&dogumTarih=" + $scope.dogumTarih + "&skype=" + $scope.skype + "&tamAdres=" + $scope.tamAdres + "&adresIkinciSatir=" + $scope.adresIki + "&eyalet=" + $scope.bilgiEyalet + "&postaKodu=" + $scope.bilgiPostaKod + "&acilAd=" + $scope.acilAd + "&acilSoyad=" + $scope.acilSoyad + "&acilTel=" + $scope.acilTel + "&adresEyaletId=" + $scope.adresEyalet).success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/UcuncuSayfa';
                    } else {
                        $scope.ikinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    console.log(data);
                });
            
            $scope.date = new Date();
            
            $scope.$watch('date', function (date) {
                console.log("hop dedik");
                $scope.dogumTarih = dateFilter(date, 'yyyy-MM-dd');
            });

            $scope.$watch('dogumTarih', function (dogumTarih) {
                console.log("hop dedik");
                $scope.date = new Date(dogumTarih);
            });

        }

        //3. sayfa
        $scope.UcuncuSayfa = function () {
            if ($scope.liseBaslangic >= $scope.liseBitis )
            {
                alert('Lise başlangıc ve bitiş tarihlerini lütfen kontrol ediniz.');
            }
    else if($scope.universiteBaslangic>$scope.universitekapanis)
        {
        alert('Universite başlangıc ve bitiş tarihlerini lütfen kontrol ediniz.');

            }
            else
            {
                $http.post("/Ucuncu/EgitimEkle?liseAd=" + $scope.liseAd + "&baslangic=" + $scope.liseBaslangic + "&bitis=" + $scope.liseBitis + "&alan=" + $scope.liseAlan + "&liseTamAdres=" + $scope.liseTamAdres + "&liseAdresIkinciSatir=" + $scope.liseAdresIki + "&liseEyalet=" + $scope.liseAdresEyalet + "&lisePostaKodu=" + $scope.liseAdresPostaKod + "&universiteAd=" + $scope.universiteAd + "&sinif=" + $scope.universiteSinif + "&bolum=" + $scope.universiteBolum + "&okulNo=" + $scope.universiteNo + "&acilis=" + $scope.universiteBaslangic + "&kapanis=" + $scope.universitekapanis + "&uniTel=" + $scope.universiteTel + "&uniTamAdres=" + $scope.universiteTamAdres + "&uniAdresIkinciSatir=" + $scope.universiteAdresIki + "&uniEyalet=" + $scope.universiteAdresEyalet + "&uniPostaKodu=" + $scope.universiteAdresPostaKod)
                                .success(function (data) {
                                    console.log(data.basari);
                                    if (data.basari == 1) {
                                        $window.location.href = '#/DorduncuSayfa';
                                    }
                                }).error(function (data) {
                                    console.log(data);
                                });
            }
            
        };

        //Uçak bilgi
        $scope.UcakBilgi = function () {
            $http.post("Ucak/Ekle?agidisTarih=" + $scope.AgidisTarih + "&bgidisTarih=" + $scope.BgidisTarih + "&agidisSehir=" + $scope.AgidisSehir + "&bgidisSehir=" + $scope.BgidisSehir + "&ahavaKod=" + $scope.AhavaKod + "&bhavaKod=" + $scope.BhavaKod + "&avarisSehir=" + $scope.AvarisSehir + "&bvarisSehir=" + $scope.BvarisSehir + "&avarisKod=" + $scope.AvarisKod + "&bvarisKod=" + $scope.BvarisKod + "&aucusKod=" + $scope.AucusKod + "&bucusKod=" + $scope.BucusKod + "&akalkisSaat=" + $scope.AkalkisSaat + "&bkalkisSaat=" + $scope.BkalkisSaat + "&avarisSaat=" + $scope.AvarisSaat + "&bvarisSaat=" + $scope.BvarisSaat + "&agunDegisim=" + $scope.AgunDegisim + "&bgunDegisim=" + $scope.BgunDegisim).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/IkinciSayfa';
                    } else {
                        $scope.aktivasyonMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        //5. sayfa
        $scope.BesinciSayfa = function () {
            $http.post()//ayvayı yedik net.
                .success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/AltinciSayfa';
                    }
                }).error(function (data) {
                    console.log(data);
                });
        };

        $scope.CvKaydet = function () {
            $http.post("/CvController/cvAdre?=" + $scope.cvAdes + "&cvGsm=" + $scope.cvGsm + "&cvEvTel?=" + $scope.cvEvTel + "&cvAdres?=" + $scope.cvAdres + "&cvEmail?=" + $scope.cvEmail + "&cvHedef?=" + $scope.cvHedef + "&cvCalismaIstek?=" + $scope.cvCalismaIstek + "&cvYabanciDil?=" + $scope.cvYabanciDil + "&cvDogumTarih?=" + $scope.cvDogumTarih + "&cvAskerlik?=" + $scope.cvAskerlik + "&cvMedeni?=" + $scope.cvMedeni + "&cvPcBilgi?=" + $scope.cvPcBilgi + "&cvHobiler?=" + $scope.cvHobiler + "&cvRefTel?=" + $scope.cvRefTel+"&cvRefAdSoyad?="+$scope.cvRefAdSoyad)
            .success(function (data) {
                console.log(data.basari);
                if (data.basari == 1) {
                    $window.location.href = '#/UcuncuSayfa';
                }
            }).error(function (data) {
                console.log(data);
            });
        };
        

        $http.get("/Ikinci/UlkeCek").success(function (data) {
            $scope.ulkes = data;
        }).error(function (data) {
            console.log(data);
        });

        $http.get("/Ikinci/IngilizceCek").success(function (data) {
            $scope.ingilizces = data;
        }).error(function (data) {
            console.log(data);
        });

        //Ülkeye göre il seçme
        $scope.updateIls = function () {
            $http.get("/Ikinci/EyaletCek?id=" + $scope.bilgiUlke).success(function (data) {
                $scope.bilgiEyalets = data;
            }).error(function (data) {
                console.log(data);
            });
        };

        $scope.updateAdresIl = function () {
            $http.get("/Ikinci/EyaletCek?id=" + $scope.adresUlke).success(function (data) {
                $scope.adresEyalets = data;
            }).error(function (data) {
                console.log(data);
            });
        };

        $scope.updateLiseIl = function () {
            $http.get("/Ikinci/EyaletCek?id=" + $scope.liseAdresUlke).success(function (data) {
                $scope.liseEyalets = data;
            }).error(function (data) {
                console.log(data);
            });
        };

        $scope.updateUniIl = function () {
            $http.get("/Ikinci/EyaletCek?id=" + $scope.universiteAdresUlke).success(function (data) {
                $scope.uniEyalets = data;
            }).error(function (data) {
                console.log(data);
            });
        };
        
       
    }
    app.controller("KisiTanimaController", KisiTanimaController);
}(angular.module("KisiModul")))