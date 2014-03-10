(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('profileController', ['$scope', '$location', 'Profile', function ($scope, $location, Profile) {
        var message = { body: "Profile Registration", title: "" };
        $scope.UserModel = {};
        $scope.word = /^\s*\w*\s*$/;

        $scope.init = function () {
            
        };

        $scope.submit = function (user) {
            var areEqual = angular.equals(user.Password, user.ConfirmPassword);
            if (areEqual) {
                Profile.register(user, function () {
                    message.body = "Thank you " + user.FirstName + " " + user.LastName + ", You are registered with us.";
                    toastr.success(message.body, message.title);
                    $location.path("/login");
                }, function (data, status, headers, config) {
                    message.body = "Oops! Error occour in registration";
                    toastr.error(message.body, message.title);
                });
            }
            else {
                message.body = "Oops! Password and Confirm password is not same";
                toastr.error(message.body, message.title);
            }
        };

        $scope.cancel = function () {
            $scope.reset();
            $location.path('/');
        };

        $scope.reset = function () {
            $scope.UserModel = {};
        };

        $scope.init();

    }]);

}());