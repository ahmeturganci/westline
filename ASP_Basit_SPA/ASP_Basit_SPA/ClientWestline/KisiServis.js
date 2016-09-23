(function (app) {

    var kisiservis = function ($http, kisiUrl) {
        //DETAY GİDERKEN ÜRÜNÜN İD Sİ 
        var hepsiGetir = function () {
            return $http.get(kisiUrl);
        };
        var idGetir = function (id) {
            return $http.get(kisiUrl + id);//api/uruns/3 ürünlerden 3 idliyi gerirmek
        };

        var guncelle = function (kisis) {
            return $http.put(kisiUrl + kisis.Id, kisis);
        };
        var ekle = function (kisis) {
            return $http.post(kisiUrl, kisis);
        };
        var destroy = function (kisis)//id de olur 
        {
            return $http.delete(kisiUrl + kisis.Id);
        };
        return {
            hepsiGetir: hepsiGetir,
            idGetir: idGetir,
            guncelle: guncelle,
            ekle: ekle,
            delete: destroy
        };
        //ekstraden eklenecek her hangibi bit fonksiyon öncelikle c#tarafına daha sonra bu kısıma eklenecek
    }
    app.factory("KisiServis", kisiservis)
}(angular.module("KisiModul")))