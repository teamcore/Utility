(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.controller('applicationController', ['$scope', '$routeParams',
         function applicationController($scope, $routeParams) {
             $scope.routeParams = $routeParams;
             $scope.isMenuCollapsed = true;
         }]);
}());