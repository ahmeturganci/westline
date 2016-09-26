(function (app) {
       var KisiTanimaController = function ($scope, $http) {
        $scope.kaydet = function () {
            $http.post("Birinci/KisiEkle?ad=" + $scope.ad + "&email=" + $scope.email).
                success(function (data) {
                    console.log(data);
                }).error(function (data) {
                    console.log(data);
                });
        }
    }
    app.controller("KisiTanimaController", KisiTanimaController);
}(angular.module("KisiModul")))