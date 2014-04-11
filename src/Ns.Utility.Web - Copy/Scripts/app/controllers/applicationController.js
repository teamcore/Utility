(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('applicationController', ['$scope', '$window', '$location', 'authentication', function ($scope, $window, $location, authentication) {
        $scope.DisplayName = $window.sessionStorage.DisplayName;

        $scope.logout = function () {
            authentication.logout();
        };
    }]);
}());