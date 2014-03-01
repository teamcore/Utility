(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('loginController', ['$scope',
        function loginController($scope) {
            $scope.Message = "";

            $scope.init = function () {
                $scope.Message = "Login Page";
            };

            $scope.init();

        }]);

}());