(function () {
    'use strict';

    angular
        .module('app')
        .factory('UserService', UserService);

    UserService.$inject = ['$http', '$rootScope'];
    function UserService($http, $rootScope) {
        var service = {};

        service.GetAll = GetAll;
        service.GetById = GetById;
        service.GetByUsername = GetByUsername;
        service.Create = Create;
        service.Update = Update;
        service.Delete = Delete;

        service.updateListUsers = updateListUsers;
        return service;

        function GetAll() {
            return $http.get('http://webapiadmin.azurewebsites.net').then(handleSuccess, handleError('Error getting all users'));
        }

        function GetById(id) {
            return $http.get('/api/users/' + id).then(handleSuccess, handleError('Error getting user by id'));
        }

        function GetByUsername(username) {
            return $http.get('/api/users/' + username).then(handleSuccess, handleError('Error getting user by username'));
        }


        function Create(user) {
            return $http.post('/api/users', user).then(handleSuccess, handleError('Error creating user'));
        }

        function Update(user) {
            return $http.put('/api/users/' + user.id, user).then(handleSuccess, handleError('Error updating user'));
        }

        function Delete(id) {
            return $http.delete('/api/users/' + id).then(handleSuccess, handleError('Error deleting user'));
        }

        function getUsers() {
            return $http.get(`${apiUrl}users`)
                .success(function (data) { return data })
                .error(function (data) {
                    return { success: false, message: data };
                });
        }

        function updateListUsers() {
            getUsers().success(function (data) {
                $rootScope.userlist = data;
                $rootScope.userMenuList = [];
                $rootScope.userlist.forEach(function (item) {
                    $rootScope.userMenuList.push({
                        "title": `${item.LastName} ${item.Name}`,
                        "id": item.Id
                    });
                });
            });
        }

        // private functions

        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();
