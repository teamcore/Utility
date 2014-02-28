(function () {
    'use strict';

    var appModule = angular.module('mainApp', ['ngRoute', 'ngResource', 'ui.bootstrap']);
    appModule.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', { templateUrl: 'Html/dashboard.html', controller: 'dashboardController' });
        $routeProvider.otherwise({ redirectTo: '/' });
    }]);

}());