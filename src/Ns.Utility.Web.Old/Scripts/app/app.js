(function () {
    'use strict';

    var appModule = angular.module('mainApp', ['ngRoute', 'ngResource', 'ui.bootstrap']);
    appModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: 'Html/dashboard.html', controller: 'dashboardController' });
        $routeProvider.when('/dashboard', { templateUrl: 'Html/dashboard.html', controller: 'dashboardController' });
        $routeProvider.when('/login', { templateUrl: 'Html/login.html', controller: 'loginController' });
        $routeProvider.when('/projects', { templateUrl: 'Html/Project/projects.html', controller: 'projectController' });
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);

}());