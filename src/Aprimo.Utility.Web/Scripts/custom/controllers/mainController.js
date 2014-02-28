(function (window, angular, undefined) {
    var mainController = angular.module('mainController', [])

    mainController.controller('loginController', ['$scope', '$http', '$location', function ($scope, $http, $location) {

        $scope.Login = {};

        $scope.reset = function () {
            $scope.Login = {};
        };

        $scope.update = function (login) {
            $scope.Login = login;
            $location.path('/');
        };

        $scope.cancel = function () {
            $scope.reset();
            $location.path('/');
        };

        $scope.isDirty = function (login) {
            return angular.equals(login, $scope.Login);
        };
    }]);

});