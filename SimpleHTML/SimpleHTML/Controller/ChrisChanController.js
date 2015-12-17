var myApp = angular.module('chrisChanApp', []);
//var connection = connector.GetConnectionFromConfig();
//connector.RegisterConnection("http://localhost/dokmee");
//var cabinets = connector.Login(new LogonInfo{Username = "admin", Password = "admin"});

myApp.controller('MenuController', function ($scope, $http) {
    $scope.page = 'Click on File Upload or File Structure';
    $scope.uploadFile = false;
    $scope.fileStructure = false;
    $scope.ufbackground = "background-color: whitesmoke;";
    $scope.fsbackground = "background-color: whitesmoke;";
    $scope.showfs = "display:none;";
    $scope.showuf = "display:none;";

    $scope.uploadFile = function () {
        //$scope.page = 'Now displays info/html for file upload page';
        $scope.ufbackground = "background-color: yellow;";
        $scope.fsbackground = "background-color: whitesmoke;"
        $scope.showfs = "display:none;";
        $scope.showuf = "display:block;";
        $scope.uf = "this is the uf";
    };

    $scope.fileStructure = function () {
        //$scope.page = 'Now Displays info/html for file structure page
        $scope.fsbackground = "background-color: yellow;";
        $scope.ufbackground = "background-color: whitesmoke;"
        $scope.showuf = "display:none;";
        $scope.showfs = "display:block;";
        var request = $http({
            method: "POST",
            url: "service.aspx/GetFileSystem",
            data: {}
        });

        request.success(function (data, status) {
            $scope.fs = data.d;
        })

        request.error(function (data, status) {
            $scope.status = status;
        });

    };
});