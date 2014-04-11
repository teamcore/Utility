(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.factory('projectService', ['$http', '$window', function ($http, $window) {
        var factory = {};

        factory.get = function (id, successCallback, errorCallback) {

            $http.post('api/projects/' + id).success(function (data, status, headers, config) {

                if (successCallback) {
                    successCallback(data);
                }
                $window.location.reload();
            }).error(function (data, status, headers, config) {

                if (errorCallback) {
                    errorCallback();
                }
            });
        };

        factory.add = function (project, successCallback, errorCallback) {

            $http.post('api/projects', project).success(function (data, status, headers, config) {
                
                if (successCallback) {
                    successCallback();
                }
                $window.location.reload();
            }).error(function (data, status, headers, config) {
                
                if (errorCallback) {
                    errorCallback();
                }
            });
        };

        factory.update = function (project, successCallback, errorCallback) {

            $http.put('api/projects', project).success(function (data, status, headers, config) {

                if (successCallback) {
                    successCallback();
                }
                $window.location.reload();
            }).error(function (data, status, headers, config) {

                if (errorCallback) {
                    errorCallback();
                }
            });
        };

        return factory;
    }]);

}());