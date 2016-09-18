(function (app) {

    var ListController = function ($scope, UrunServis,$http) {

        UrunServis.hepsiGetir().success(function (data) {
            $scope.uruns = data;

            //api
            $http.get("http://eu-api.jotform.com/user?apikey=09c407aeefdcd0b918b282df269fe015").
                success(function (data) {
                    console.log(data.content.username);
                }).error(function (data) {
                    console.log("hata");
                });

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