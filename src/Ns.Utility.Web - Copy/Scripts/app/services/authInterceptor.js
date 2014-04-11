(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.factory('authInterceptor', function ($rootScope, $q, $window) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                if ($window.sessionStorage.Token) {
                    config.headers.Authorization = $window.sessionStorage.Token;
                }
                return config;
            },
            response: function (response) {
                if (response.status === 401) {
                    // handle the case where the user is not authenticated
                }
                return response || $q.when(response);
            }
        };
    });

    appModule.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

}());