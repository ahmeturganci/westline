(function (app) {

    var ListController = function ($scope, UrunServis) {

        UrunServis.hepsiGetir().success(function (data) {
            $scope.uruns = data;
        })

        $scope.Olustur = function () {
            $scope.ekle = {
                uruns: {
                    UrunAd: "urun adi",
                    UrunMiktar: 1,
                    UrunFiyat: 100
                }
            };
        }

        $scope.delete = function (uruns) {
            UrunServis.delete(uruns).success(function () {
                for (var i = 0; i < $scope.uruns.lenght; i++) {
                    if ($scope.uruns[i].Id == uruns.Id) {
                        $scope.uruns.splite(i, 1);
                    }
                }
            })
        }

    }


    app.controller("ListController", ListController);
    //app = angular.module("UrunModul");


}(angular.module("UrunModul")))