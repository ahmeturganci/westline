angular.module('KisiModul') // extending angular module from first part
.controller('KisiTanimaController', function ($scope, FileUploadService, $window, $http, $location, $filter) {
    
    // Ekran Değerleri
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });

    $http.get("/Ikinci/UlkeCek").success(function (data) {
        $scope.ulkes = data;
    }).error(function (data) {
        console.log(data);
    });

    $scope.updateIls = function (f) {
        $http.get("/Ikinci/EyaletCek?id=" + f).
            success(function (data) {
                $scope.Eyalets = data;
            }).error(function (data) {
                console.log(data);
            });
    };

    // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
    // ------------------------------------------------------------------------------------
    //File Validation
    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type.indexOf("pdf") > -1 || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file[0];
    }
    //----------------------------------------------------------------------------------------

    //Save File
    $scope.SaveFile = function (e) {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, e).then(function (d) {
                ClearForm();
                $("#" + e + "d").attr("src", "Images/" + d.Message);
                $("#" + e + "d").attr("width", 60);
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };
    //Clear form 
    function ClearForm() {
        $scope.FileDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;

    }

    function profilKayit(link) {
            $http.post("Birinci/KisiEkle?" + link).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/Cv';
                    } else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        function cvKayit(link) {
            $http.post("Cv/CvEkle?" + link).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/DorduncuSayfa';
                    } else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        function evrakPasaportKayit(link) {
            $http.post("Dorduncu/evrakPasaportEkle?" + link).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/isler';
                    } else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        function ucakBilgiKayit(link) {
            $http.post("Ucak/ucakBilgiEkle?" + link).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/isler';
                    } else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }

        var elemanSayac = 0;
        var link = "";
        function Kayit(formId) {
            elemanSayac = 0;
            link = "";
            $('#' + formId).find('input').each(function (idx, input) {
                // Do your DOM manipulation here
                if ($(input).attr('type') != "radio" && $(input).attr('type') != "file"  && $(input).attr('type') != "submit") {
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
                }else if($(input).attr('type') == "radio"){
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

            $('#' + formId).find('textarea').each(function (idx, textarea) {
                if (elemanSayac == 0) {
                    link += elemanSayac + "=" + $(textarea).val();
                } else {
                    link += "&" + elemanSayac + "=" + $(textarea).val();
                }
                elemanSayac++;
                link += "&" + elemanSayac + "=" + $(textarea).attr('id');
                elemanSayac++;
                link += "&" + elemanSayac + "=" + $(textarea).attr('name');
                elemanSayac++;
            });
            console.log(formId);
            if (formId == "profile") {
                profilKayit(link);
            } else if (formId == "cvKayit") {
                cvKayit(link);
            } else if (formId == "evrakvepasaport") {
                evrakPasaportKayit(link);
            } else if (formId == "ucakbilgiform") {
                ucakBilgiKayit(link);
            }
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

        $http.get("/Ikinci/UlkeCek").success(function (data) {
            $scope.ulkes = data;
        }).error(function (data) {
            console.log(data);
        });

        //Ülkeye göre il seçme

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

        
        
        //isleri getir
        $http.get("/Isler/IsleriGetir").success(function (data) {
            $scope.islers = data;
        }).error(function (data) {
            console.log(data);
        });

        $scope.IsEkle = function () {
            elemanSayac = 0;
            link = "";
            $('#frmIsler').find('input').each(function (idx, input) {
                if ($(input).attr('type') == "checkbox") {
                    if ($(input).is(':checked')) {
                        if (elemanSayac == 0) {
                            link += elemanSayac + "=" + $(input).val();
                        } else {
                            link += "&" + elemanSayac + "=" + $(input).val();
                        }
                        elemanSayac++;
                    }
                }
            });
            IsKayit(link);
        };
        
        function IsKayit(link) {
            console.log(link);
            $http.post("Isler/IsEkle?" + link).
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/Cv';
                    } else {
                        $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                    }
                }).error(function (data) {
                    alert("hata");
                });
        }
        
        

        //Birinci sayfa eleman cek
        $http.get("/Birinci/elemans?sayfa=1&kisiId=1").success(function (data) {
            $scope.birinciElemans = data;
        }).error(function (data) {
            console.log(data);
        });

        
        $scope.profilSayfa = function (formId) {
            Kayit(formId);
        };

        //Cv sayfa eleman cek
        $http.get("/Cv/elemans?sayfa=2&kisiId=1").success(function (data) {
            $scope.cvElemans = data;
        }).error(function (data) {
            console.log(data);
        });

        $scope.cvKaydet = function (formId) {
            Kayit(formId);
        };


    //Evrak sayfa eleman cek
        $http.get("/Dorduncu/elemans?sayfa=3&kisiId=1").success(function (data) {
            $scope.evrakElemans = data;
        }).error(function (data) {
            console.log(data);
        });

        $scope.pasaportKaydet = function (formId) {
            Kayit(formId);
        };

    //Uçak eleman çek
        $http.get("/Ucak/elemans?sayfa=4&kisiId=1").success(function (data) {
            $scope.ucakElemans = data;
        }).error(function (data) {
            console.log(data);
        });

        $scope.ucakKaydet = function (formId) {
            Kayit(formId);
        };

}).factory('FileUploadService', function ($http, $q) { // explained abour controller and service in part 2

    var fac = {};
    fac.UploadFile = function (file, description, e) {
        var formData = new FormData();
        formData.append("file", file);
        //We can send more data to server using append         
        formData.append("description", description);
        formData.append("e", e);

        var defer = $q.defer();
        $http.post("/Dorduncu/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });

        return defer.promise;

    }
    return fac;

});