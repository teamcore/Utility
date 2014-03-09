(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('profileController', ['$scope', '$location', 'profileService', function ($scope, $location, profileService) {

        $scope.User = {};
        $scope.UserModel = {};

        $scope.init = function () {
            $scope.User = angular.copy($scope.UserModel);
        };

        $scope.submit = function (user) {
            var areEqual = angular.equals(user.Password, user.ConfirmPassword);
            if (areEqual)
            {
                profileService.register(user);
            }
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