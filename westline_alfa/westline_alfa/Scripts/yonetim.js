var app = angular.module('myApp', []);
app.controller('yonetim', function ($scope,$http) {
    //ds eleman çek
    $http.get("/Besinci/elemans?sayfa=8&kisiId=1").success(function (data) {
        $scope.dsElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Ek bilgi eleman çek
    $http.get("/Ikinci/elemans?sayfa=7&kisiId=1").success(function (data) {
        $scope.ekBilgiElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Randevu eleman çek
    $http.get("/Randevu/elemans?sayfa=6&kisiId=1").success(function (data) {
        $scope.randevuElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Eğitim eleman çek
    $http.get("/Ucuncu/elemans?sayfa=5&kisiId=1").success(function (data) {
        $scope.egitimElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Uçak eleman çek
    $http.get("/Ucak/elemans?sayfa=4&kisiId=1").success(function (data) {
        $scope.ucakElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Evrak sayfa eleman cek
    $http.get("/Dorduncu/elemans?sayfa=3&kisiId=1").success(function (data) {
        $scope.evrakElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Cv sayfa eleman cek
    $http.get("/Cv/elemans?sayfa=2&kisiId=1").success(function (data) {
        $scope.cvElemans = data;
    }).error(function (data) {
        console.log(data);
    });

    //Birinci sayfa eleman cek
    $http.get("/Birinci/elemans?sayfa=1&kisiId=1").success(function (data) {
        $scope.birinciElemans = data;
    }).error(function (data) {
        console.log(data);
    });
});