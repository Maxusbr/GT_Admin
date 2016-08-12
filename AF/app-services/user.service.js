(function () {
    'use strict';

    function userService($http, $rootScope) {
        var service = {};

        service.GetAll = function getAll() {
            return $http.get('http://webapiadmin.azurewebsites.net').then(handleSuccess, handleError('Error getting all users'));
        }

        service.GetById = function getById(id) {
            return $http.get('/api/users/' + id).then(handleSuccess, handleError('Error getting user by id'));
        }

        service.GetByUsername = function getByUsername(username) {
            return $http.get('/api/users/' + username).then(handleSuccess, handleError('Error getting user by username'));
        }

        service.Create = function create(user) {
            return $http.post('/api/users', user).then(handleSuccess, handleError('Error creating user'));
        }

        service.Update = function update(user) {
            return $http.post(`${serviceUrl}users/update/${user.Id}`, user).then(handleSuccess, handleError('Error updating user'));
        }

        service.Delete = function deleteUser(id) {
            return $http.delete('/api/users/' + id).then(handleSuccess, handleError('Error deleting user'));
        }

        service.getListUsers = function getListUsers() {
            $http.get(`${serviceUrl}users`)
                .success(function (data) {
                    $rootScope.userlist = data;
                    $rootScope.userMenuList = [];
                    $rootScope.userlist.forEach(function (item) {
                        $rootScope.userMenuList.push({
                            "title": `${item.LastName} ${item.Name}`,
                            "id": item.Id
                        });
                    });
                    console.log("load users");
                })
                .error(function (data) {
                    return { success: false, message: data };
                });
        }

        service.getListRoles = function getListRoles() {
            return $http.get(`${serviceUrl}sysroles`)
                .success(function (data) { return data })
                .error(function (data) {
                    return { success: false, message: data };
                });
        }

        service.registerUser = function registerUser(user) {
            return $http.post(`${serviceUrl}users/register`, user)
                .success(function (data) { return data })
                .error(function (data) { return data; });
        }

        return service;

        function getUsers() {
            return $http.get(`${serviceUrl}users`)
                .success(function (data) { return data })
                .error(function (data) {
                    return { success: false, message: data };
                });
        } // private functions

        function handleSuccess(res) {
            return { success: true, data: res.data };
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

    angular
        .module('app')
        .factory('userService', userService);

    userService.$inject = ['$http', '$rootScope'];
})();
