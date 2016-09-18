(function (app) {
    var DetayController=function($scope,UrunServis,$routeParams)
    {
        var id = $routeParams.id;
       UrunServis.idGetir(id) .success(function (data) {
            $scope.uruns = data;
       });
       $scope.ekle = function () {
           $scope.ekle.uruns = angular.copy($scope.uruns);
       }
    }
    app.controller("DetayController", DetayController);
}(angular.module("UrunModul")))