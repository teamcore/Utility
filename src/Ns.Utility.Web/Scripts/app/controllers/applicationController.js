(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('applicationController', ['$scope', '$window', '$location', 'authentication', function ($scope, $window, $location, authentication) {
        $scope.Name = $window.sessionStorage.Name;

        $scope.logout = function () {
            authentication.logout();
        };
    }]);
}());