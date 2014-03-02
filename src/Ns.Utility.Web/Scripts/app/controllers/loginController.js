(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('loginController', ['$scope', '$location', 'authentication', function ($scope, $location, authentication) {

        $scope.LoginModel = {};

        $scope.reset = function () {
            $scope.LoginModel = {};
        };

        $scope.submit = function (login) {
            authentication.authenticate(login, loginSuccess, loginErrorr);
        };

        $scope.cancel = function () {
            $scope.reset();
            $location.path('/');
        };

        $scope.isDirty = function (login) {
            var areEqual = angular.equals(login, $scope.LoginModel);
            return false;
        };

        var loginSuccess = function () {
            $location.path('/');
        };

        var loginErrorr = function () {

        };

    }]);

}());