(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('profileController', ['$scope', '$location', 'authentication', function ($scope, $location, authentication) {

        $scope.User = {};
        $scope.UserModel = {};

        $scope.init = function () {
            $scope.User = angular.copy($scope.UserModel);
        };

        $scope.login = function () {
            authentication.authenticate($scope.UserModel);
        };

        $scope.cancel = function () {
            $scope.reset();
            $location.path('/');
        };

        $scope.reset = function () {
            $scope.UserModel = {};
        };

        $scope.isDirty = function (user) {
            return angular.equals(user, $scope.User);
        };

        $scope.init();

    }]);

}());