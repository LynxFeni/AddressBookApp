/// <reference path="../scripts/angular.js" />
/// <reference path="App.js" />

app.controller('addressBookCtrl', function ($scope, $http, addressBookService) {

    //base url
    var baseURL = "http://localhost:11483/api/AddressBookAPI/";

    $scope.addressData = null;
    loadRecords();

    function loadRecords() {
        addressBookService.getallrecords().then(function (d) {
            $scope.addressData = d.data;
        }, function (response) {
            alert('error occurred' + response.data.ExceptionMesage);
        });
    }
    addressBookService.getallrecords().then(function (d) {
        $scope.addressData = d.data;
    }, function (response) {
        alert('error occurred' + response.data.ExceptionMesage);
    });
    $scope.Address = {
        Id: '',
        phoneNumber: '',
        name: '',
        surname: '',
        emailAddress: ''
    };
    $scope.clear = function () {
        $scope.Address.Id = '',
            $scope.Address.phoneNumber = '',
            $scope.Address.name = '',
            $scope.Address.surname = '',
            $scope.Address.emailAddress = '',
            $scope.addnewdiv = false;
        $scope.updatediv = false;
    };
    //Add new record
    $scope.save = function () {
        if ($scope.Address.phoneNumber !== '' && $scope.Address.name !== '' && $scope.Address.surname !== '' && $scope.Address.emailAddress !== '') {
            $http({
                method: 'POST',
                url: baseURL,
                data: $scope.Address

            }).then(function successCallback(response) {
                $scope.addressData.push(response.data);
                $scope.clear();
                alert('Inserted successfully!!');
                $scope.addnewdiv = false;
                loadRecords();
            }, function errorCallback(response) {
                alert('error:' + response.data.ExceptionMesage);
            });
        }
        else {
            alert('Please enter all the values!!');
        }
    };
    //Edit records
    $scope.edit = function (data) {
        $scope.Address = { Id: data.Id, phoneNumber: data.phoneNumber, name: data.name, surname: data.surname, emailAddress: data.emailAddress };
        $scope.updatediv = true;
    };
    //Cancel record
    $scope.cancel = function () {
        $scope.clear();
    };

    //Update record
    $scope.update = function () {
        if ( $scope.Address.phoneNumber !== '' && $scope.Address.name !== '' && $scope.Address.surname !== '' && $scope.Address.emailAddress !== '') {
            $http({
                method: 'PUT',
                url: baseURL + $scope.Address.Id,
                data: $scope.Address

            }).then(function successCallback(response) {
                $scope.addressData = response.data;
                $scope.clear();
                alert('Updated successfully!!');
                $scope.updatediv = false;
                loadRecords();
            }, function errorCallback(response) {
                alert('error:' + response.data.ExceptionMesage);
            });
        }
        else {
            alert('Please enter all the values!!');
        }
    };
    //Delete record
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: baseURL + $scope.addressData[index].Id

        }).then(function successCallback(response) {
            $scope.addressData.splice(index, 1);
            alert('Record deleted successfully');
        }, function failureCallback(response) {
            alert('error:' + response.data.ExceptionMesage);
        });

    };

});