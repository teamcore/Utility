(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.factory('authentication', ['$http', '$window', '$location', function ($http, $window, $location) {
        var factory = {};
        factory.authenticate = function (loginModel) {

            $http.post('api/authentication', loginModel).success(function (data, status, headers, config) {
                $window.sessionStorage.Token = data.Token;
                $window.sessionStorage.DisplayName = data.DisplayName;
                $window.sessionStorage.UserName = data.UserName;
                $location.path('/');
                $window.location.reload();
            }).error(function (data, status, headers, config) {
                delete $window.sessionStorage.Token;
                delete $window.sessionStorage.DisplayName;
                delete $window.sessionStorage.UserName;
            });

        };

        factory.logout = function () {
            delete $window.sessionStorage.Token;
            delete $window.sessionStorage.DisplayName;
            delete $window.sessionStorage.UserName;
            $location.path('/');
            $window.location.reload();
        };

        return factory;
    }]);

}());