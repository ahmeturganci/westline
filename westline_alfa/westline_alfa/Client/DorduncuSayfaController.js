angular.module('fupApp', [])
       .directive('ngFiles', ['$parse', function ($parse) {

           function fn_link(scope, element, attrs) {
               var onChange = $parse(attrs.ngFiles);
               element.on('change', function (event) {
                   onChange(scope, { $files: event.target.files });
               });
           };

           return {
               link: fn_link
           }
       }])
       .controller('fupController', function ($scope, $http) {

           var formdata = new FormData();
           $scope.getTheFiles = function ($files) {
               angular.forEach($files, function (value, key) {
                   formdata.append(key, value);
               });
           };

           // NOW UPLOAD THE FILES.
           $scope.uploadFiles = function () {

               var request = {
                   method: 'POST',
                   url: '/Dorduncu/BelgeEkle/',
                   data: formdata,
                   headers: {
                       'Content-Type': undefined
                   }
               };

               // SEND THE FILES.
               $http(request)
                   .success(function (d) {
                       alert(d);
                   })
                   .error(function () {
                   });
           }
       });