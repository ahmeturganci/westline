(function (app) {
    var IkinciSayfaController = function ($scope, $http) {
        $scope.IkinciSayfa = function () {
            $http.post("").
                success(function (data) {
                    console.log(data.basari);
                    if (data.basari == 1) {
                        $window.location.href = '#/UcuncuSayfa';
                    }
                }).error(function (data) {
                    console.log(data);
                });


        }
    }
    app.controller("IkinciSayfaController", IkinciSayfaController);
}(angular.module("KisiModul")))