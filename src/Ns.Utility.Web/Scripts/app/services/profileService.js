(function () {
    'use strict';
    var appModule = angular.module('mainApp');
    appModule.factory('Profile', ['$resource', function ($resource) {
        var Profile = $resource("api/users/:Id",
            { Id: '@id' },
            { register: { method: 'POST', isArray: false } },
            { update: { method: 'PUT', isArray: false } });
        return Profile;
    }]);

}());