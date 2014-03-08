(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('loginController', ['$scope', '$location', 'authentication', function ($scope, $location, authentication) {

        $scope.User = {};
        $scope.LoginModel = {};

        $scope.init = function () {
            $scope.User = angular.copy($scope.LoginModel);
        };

        $scope.login = function () {
            authentication.authenticate($scope.LoginModel, loginSuccess, loginErrorr);
        };

        $scope.cancel = function () {
            $scope.reset();
            $location.path('/');
        };

        $scope.reset = function () {
            $scope.LoginModel = {};
        };

        $scope.isDirty = function (login) {
            return angular.equals(login, $scope.User);
        };

        var loginSuccess = function () {
            $location.path('/');
        };

        var loginErrorr = function () {

        };

        $scope.init();

    }]);

}());