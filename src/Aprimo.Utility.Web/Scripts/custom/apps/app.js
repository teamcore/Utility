(function (window, angular, undefined) {
    'use strict';
    var mainApp = angular.module('mainApp', ['ngRoute', 'mainController']);

    mainApp.config(['$routeProvider', aprimoRouter]);

    var aprimoRouter = function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'Views/Home/home.html',
            controller: 'homeCtrl'
        }).when('/login', {
            templateUrl: 'Views/Home/home.html',
            controller: 'homeCtrl'
        }).otherwise({
            redirectTo: '/'
        });
    };
});