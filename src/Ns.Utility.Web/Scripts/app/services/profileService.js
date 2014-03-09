(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.factory('profileService', ['$http', '$window', function ($http, $window) {
        var factory = {};

        factory.get = function (id) {

            $http.get('api/users/' + id).success(function (data, status, headers, config) {

                
                $window.location.reload();
            }).error(function (data, status, headers, config) {

                
            });
        };

        factory.register = function (user) {

            $http.post('api/users', user).success(function (data, status, headers, config) {
                $window.location.reload();
            }).error(function (data, status, headers, config) {
                $window.location.reload();
            });
        };

        factory.update = function (user) {

            $http.put('api/users', user).success(function (data, status, headers, config) {

                $window.location.reload();
            }).error(function (data, status, headers, config) {

            });
        };

        return factory;
    }]);

}());