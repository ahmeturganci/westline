(function (app) {

    var urunservis = function ($http, urunUrl) {
        //DETAY GİDERKEN ÜRÜNÜN İD Sİ 
        var hepsiGetir = function () {
            return $http.get(urunUrl);
        };
        var idGetir = function (id) {
            return $http.get(urunUrl+id);//api/uruns/3 ürünlerden 3 idliyi gerirmek
        };

        var guncelle = function (uruns) {
            return $http.put(urunUrl + uruns.Id, uruns);
        };
        var ekle = function (uruns) {
            return $http.post(urunUrl, uruns);
        };
        var destroy = function (uruns)//id de olur 
        {
            return $http.delete(urunUrl + uruns.Id);
        };
        return {
            hepsiGetir: hepsiGetir,
            idGetir: idGetir,
            guncelle: guncelle,
            ekle: ekle,
            delete: destroy
        };
    }
    app.factory("UrunServis", urunservis)
}(angular.module("UrunModul")))