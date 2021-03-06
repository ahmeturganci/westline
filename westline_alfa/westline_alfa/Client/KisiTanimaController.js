﻿angular.module('KisiModul') // extending angular module from first part
.controller('KisiTanimaController', function ($scope, FileUploadService, $window, $http, $location, $filter) {

    var session = "";
    var sesData = -1;
    $http.get("/Kullanici/SessionGetir").success(function (data) {
        sesData = data;
        if (sesData.basari != 0) {
            session = sesData.id;
            $scope.session = sesData.id;

            $scope.aaa = "sasdasd";    // Ekran Değerleri
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
            $scope.ChechFileValid = function (file, tur) {
                var isValid = false;
                if ($scope.SelectedFileForUpload != null) {
                    if (tur == 0) {
                        if ((file.type == 'image/jpeg') && file.size <= (512 * 1024 * 5)) {
                            $scope.FileInvalidMessage = "";
                            isValid = true;
                        }
                        else {
                            $scope.FileInvalidMessage = "Selected file is Invalid. (only file type  jpeg  5 mb size allowed)";
                        }
                    }
                    else {
                        if ((file.type.indexOf("pdf") > -1 && file.size <= (512 * 1024 * 5))) {
                            $scope.FileInvalidMessage = "";
                            isValid = true;
                        }
                        else {
                            $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
                        }
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
            $scope.SaveFile = function (e, tur) {
                $scope.IsFormSubmitted = true;
                $scope.Message = "";
                $scope.ChechFileValid($scope.SelectedFileForUpload, tur);
                if ($scope.IsFormValid && $scope.IsFileValid) {
                    FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription, e).then(function (d) {
                        ClearForm();
                        if (tur == 0) {
                            $("#dort_" + e + "d").attr("src", "Images/" + d.Message);
                            $("#dort_" + e + "d").attr("width", 60);
                        }
                        else {
                            $("#dort_" + e + "d").attr("href", "Images/" + d.Message);
                            $("#dort_" + e + "d").show();
                        }
                        if(e==1) // WAT 
                        {
                            WatBildirimiGoster();
                        }
                    }, function (e) {
                        alert(e);
                    });
                }
                else {
                    alert($scope.Message);
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
                            $window.location.href = '#/TaksitBilgi';
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
                            $window.location.href = '#/Evrak';
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
                            $window.location.href = '#/Ds160';
                        } else {
                            $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                        }
                    }).error(function (data) {
                        alert("hata");
                    });
            };

            function egitimBilgiKayit(link) {
                $http.post("Ucuncu/egitimEkle?" + link).
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
            };

            function ekBilgiKayit(link) {
                $http.post("Ikinci/ekBilgiEkle?" + link).
                    success(function (data) {
                        console.log(data.basari);
                        if (data.basari == 1) {
                            $window.location.href = '#/Egitim';
                        } else {
                            $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                        }
                    }).error(function (data) {
                        alert("hata");
                    });
            };

            function dsBilgiKayit(link) {
                $http.post("Besinci/dsEkle?" + link).
                    success(function (data) {
                        console.log(data.basari);
                        if (data.basari == 1) {
                            $window.location.href = '#/Dashboard';
                        } else {
                            $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                        }
                    }).error(function (data) {
                        alert("hata");
                    });
            };

            var elemanSayac = 0;
            var link = "";
            function Kayit(formId) {
                elemanSayac = 0;
                link = "";
                $('#' + formId).find('input').each(function (idx, input) {
                    // Do your DOM manipulation here
                    if ($(input).attr('type') != "radio" && $(input).attr('type') != "file" && $(input).attr('type') != "submit") {
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
                    } else if ($(input).attr('type') == "radio") {
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
                } else if (formId == "egitimform") {
                    egitimBilgiKayit(link);
                } else if (formId == "randevuform") {
                    randevuBilgiKayit(link);
                } else if (formId == "ekbilgiform") {
                    ekBilgiKayit(link);
                } else if (formId == "dsForm") {
                    dsBilgiKayit(link);
                }
            }

            //Aktivasyon
            $scope.Aktivasyon = function () {
                $http.post("Birinci/Kontrol?kod=" + $scope.kod).
                    success(function (data) {
                        console.log(data.basari);
                        if (data.basari == 1) {
                            alert("Aktivasyon başarılı. Admin onayını bekliyorsunuz");
                        } else {
                            $scope.aktivasyonMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                        }
                    }).error(function (data) {
                        alert("hata");
                    });
            }


            $http.get("/Ikinci/UlkeCek").success(function (data) {
                $scope.ulkes = data;
            }).error(function (data) {
                console.log(data);
            });


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
                        if (data.basari == 1) {
                            $window.location.href = '#/RandevuAl';
                        } else {
                            $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                        }
                    }).error(function (data) {
                        alert("hata");
                    });
            }


            $scope.taksitOnay = function () {
                $http.post("Taksit/taksitOnay?" + link).
                    success(function (data) {
                        console.log(data.basari);
                        if (data.basari == 1) {
                            $window.location.href = '#/Wat';
                        } else {
                            $scope.birinciMesaj = "Yıldızlı(*) alanların doldurulması gerekiyor";
                        }
                    }).error(function (data) {
                        alert("hata");
                    });
            };

            $scope.sponsorSayfa = function () {
                console.log($scope.sponsor);
            };


            $scope.RandevuAl = function () {
                $http.get("/Randevu/randevuEkle?altBir=" + $("#r1").val() + "&altIki=" + $("#r2").val()).
                    success(function (data) {
                        if (data.basari == 1) {
                            RandevuBildirimiGoster();
                        }
                }).error(function (data) {
                    console.log(data);
                });
            };

            //Birinci sayfa eleman cek
            $http.get("/Birinci/elemans?sayfa=1&kisiId=" + session).success(function (data) {
                $scope.birinciElemans = data;
            }).error(function (data) {
                console.log(data);
            });


            $scope.profilSayfa = function (formId) {
                Kayit(formId);
            };

            //Cv sayfa eleman cek
            $http.get("/Cv/elemans?sayfa=2&kisiId=" + session).success(function (data) {
                $scope.cvElemans = data;
            }).error(function (data) {
                console.log(data);
            });

            $scope.cvKaydet = function (formId) {
                Kayit(formId);
            };


            //Evrak sayfa eleman cek
            $http.get("/Dorduncu/elemans?sayfa=3&kisiId=" + session).success(function (data) {
                $scope.evrakEleman = data;
            }).error(function (data) {
                console.log(data);
            });

            $scope.pasaportKaydet = function (formId) {
                Kayit(formId);
            };

            //Eğitim eleman çek
            $http.get("/Ucak/elemans?sayfa=4&kisiId=" + session).success(function (data) {
                $scope.ucakElemans = data;
            }).error(function (data) {
                console.log(data);
            });

            $scope.ucakKaydet = function (formId) {
                Kayit(formId);
            };

            //Eğitim eleman çek
            $http.get("/Ucuncu/elemans?sayfa=5&kisiId=" + session).success(function (data) {
                $scope.egitimElemans = data;
            }).error(function (data) {
                console.log(data);
            });

            $scope.egitimKayit = function (formId) {
                Kayit(formId);
            };

            

            //Ek bilgi eleman çek
            $http.get("/Ikinci/elemans?sayfa=7&kisiId=" + session).success(function (data) {
                $scope.ekBilgiElemans = data;
            }).error(function (data) {
                console.log(data);
            });

            $scope.EkBilgi = function (formId) {
                Kayit(formId);
            };

            //ds eleman çek
            $http.get("/Besinci/elemans?sayfa=9&kisiId=" + session).success(function (data) {
                $scope.dsElemans = data;
            }).error(function (data) {
                console.log(data);
            });

            $scope.dsKayit = function (formId) {
                Kayit(formId);
            };

            //Dashboard eleman çek
            $http.get("/dashboard/GirisLog?Id=" + session).success(function (data) {
                $scope.logs = data;
            }).error(function (data) {
                console.log(data);
            });

            //taksitbilgi çek
            $http.get("/taksitbilgi/TaksitCek?Id=" + session).success(function (data) {
                $scope.taksits = data;
            }).error(function (data) {
                console.log(data);
            });
            //Wat Bilgi Çek
            $http.get("/Wat/BilgiCek").success(function (data) {
                $scope.Wat_URL = data;
            }).error(function (data) {
                console.log(data);
            });
        }
        else {
            window.location = "/Kullanici/Index";
        }
    }).error(function (data) {
        console.log(data);
    });



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
            if (d.Yesillendir == true) {
                $("#isler").attr("style", "background-color:green");
            } else {
                $("#isler").attr("style", "background-color:gray");
            }
        })
        .error(function () {
            defer.reject("File Upload Failed!");
        });

        return defer.promise;

    }
    return fac;

});