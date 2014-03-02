(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.factory('authentication', ['$http', '$window', function ($http, $window) {
        var factory = {};
        factory.authenticate = function (loginModel, successCallback, errorCallback) {

            $http.post('api/authentication', loginModel).success(function (data, status, headers, config) {
                $window.sessionStorage.Token = data.Token;
                $window.sessionStorage.Name = data.Name;
                if (successCallback) {
                    successCallback();
                }
            }).error(function (data, status, headers, config) {
                delete $window.sessionStorage.Token;
                delete $window.sessionStorage.Name;
                if (errorCallback) {
                    errorCallback();
                }
            });

        };

        return factory;
    }]);

}());