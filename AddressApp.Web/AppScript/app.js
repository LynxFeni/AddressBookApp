
var app = angular.module('addressBookModule', []);
app.factory('addressBookService', function ($http) {
    var factory = {};
    var baseURL = "http://localhost:11483/api/AddressBookAPI/";
    factory.getallrecords = function () {
        return $http.get(baseURL);
    };
    return factory;
});