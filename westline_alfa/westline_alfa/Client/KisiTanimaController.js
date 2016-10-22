(function (app) {
    var KisiTanimaController = function ($scope, $http, $location, $window, $filter) {
        //1.Sayfa
        function Birinci(link) {
            $http.post("Birinci/KisiEkle?" + link).
                
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
        $scope.$watch('dogumTarih', function (newValue) {
            $scope.dogumTarih = $filter('date')(newValue, 'yyyy/MM/dd');
        });

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
        $scope.$watch('liseBaslangic', function (newValue) {
            $scope.liseBaslangic = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('liseBitis', function (newValue) {
            $scope.liseBitis = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('universiteBaslangic', function (newValue) {
            $scope.universiteBaslangic = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('universitekapanis', function (newValue) {
            $scope.universitekapanis = $filter('date')(newValue, 'yyyy/MM/dd');
        });

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

        //vize ekle
        $scope.$watch('birinciAlternatif', function (newValue) {
            $scope.birinciAlternatif = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('ikinciAlternatif', function (newValue) {
            $scope.ikinciAlternatif = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.RandevuAl = function () {
            $http.post("Randevu/Ekle?altBir=" + $scope.birinciAlternatif + "&altIki=" + $scope.ikinciAlternatif).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                   
                    }
                    else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
             }).error(function (data) {
                    alert("hata");
               });
        }

        //Uçak bilgi
        $scope.$watch('AgidisTarih', function (newValue) {
            $scope.AgidisTarih = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('BgidisTarih', function (newValue) {
            $scope.BgidisTarih = $filter('date')(newValue, 'yyyy/MM/dd');
        });

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
        $scope.$watch('amerikaBulunmaTarih', function (newValue) {
            $scope.amerikaBulunmaTarih = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('babaDogumTarihi', function (newValue) {
            $scope.babaDogumTarihi = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.$watch('anneDogumTarihi', function (newValue) {
            $scope.anneDogumTarihi = $filter('date')(newValue, 'yyyy/MM/dd');
        });

        $scope.BesinciSayfa = function () {
            $http.post("Besinci/BesinciSayfa?dogumYeri=" + $scope.dogumYeri + "&vatandasNo=" + $scope.vatandasNo + "&ikinciVatandasNo=" + $scope.ikinciVatandasNo + "&AbdSsn=" + $scope.AbdSsn + "&amerikadaBulunduMu=" + $scope.amerikadaBulunduMu + "&amerikaBulunmaTarih=" + $scope.amerikaBulunmaTarih + "&amerikaBulunduguSure=" + $scope.amerikaBulunduguSure + "&oncedenAmerikaVizesi=" + $scope.oncedenAmerikaVizesi + "&oncedenAmerikaVizeRet=" + $scope.oncedenAmerikaVizeRet + "&oncedenAmerikaVizeRetNedeni=" + $scope.oncedenAmerikaVizeRetNedeni + "&amerikaVatandasGocmenBasvuru=" + $scope.amerikaVatandasGocmenBasvuru + "&babaDogumTarihi=" + $scope.babaDogumTarihi + "&babaAmerikadaMi=" + $scope.babaAmerikadaMi + "&askerlikYapti=" + $scope.askerlikYapti + "&sonBesYil=" + $scope.sonBesYil + "&anneDogumTarihi=" + $scope.anneDogumTarihi + "&anneAmerikadaMi=" + $scope.anneAmerikadaMi + "&amerikaAkrabaBilgi=" + $scope.amerikaAkrabaBilgi)
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

        $scope.updatePasIls = function () {
            $http.get("/Ikinci/EyaletCek?id=" + $scope.pasUlke).success(function (data) {
                $scope.pasEyalets = data;
            }).error(function (data) {
                console.log(data);
            });
        };
        
        //isleri getir
        $http.get("/Isler/IsleriGetir").success(function (data) {
            $scope.islers = data;
        }).error(function (data) {
            console.log(data);
        });


        //Birinci sayfa eleman cek
        $http.get("/Birinci/elemans?sayfa=1&kisiId=1").success(function (data) {
            console.log(data);
            $scope.birinciElemans = data;
        }).error(function (data) {
            console.log(data);
        });

        var elemanSayac = 0;
        var link = "";
        $scope.profilSayfa = function (formId) {
            elemanSayac = 0;
            link = "";
            $('#profile').find('input').each(function (idx, input) {
                // Do your DOM manipulation here
                if ($(input).attr('type') != "radio") {
                    if (elemanSayac == 0) {
                        link += elemanSayac + "=" + $(input).val();
                    } else {
                        link += "&" + elemanSayac + "=" + $(input).val();
                    }
                    elemanSayac++;
                    link += "&" + elemanSayac + "=" + $(input).attr('id');
                    elemanSayac++;
                    link += "&" + elemanSayac + "=" + $(input).attr('name');
                    elemanSayac++;
                } else {
                    if ($(input).is(':checked')) {
                        if (elemanSayac == 0) {
                            link += elemanSayac + "=" + $(input).val();
                        } else {
                            link += "&" + elemanSayac + "=" + $(input).val();
                        }
                        elemanSayac++;
                        link += "&" + elemanSayac + "=" + $(input).attr('id');
                        elemanSayac++;
                        link += "&" + elemanSayac + "=" + $(input).attr('name');
                        elemanSayac++;
                    }
                }
            });
            Birinci(link);
        };

        //Cv sayfa eleman cek
        $http.get("/Cv/elemans?sayfa=2&kisiId=1").success(function (data) {
            console.log(data);
            $scope.cvElemans = data;
        }).error(function (data) {
            console.log(data);
        });
    }
    app.controller("KisiTanimaController", KisiTanimaController);
}(angular.module("KisiModul")))