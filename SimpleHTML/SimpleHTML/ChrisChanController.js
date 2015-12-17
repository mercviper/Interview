var myApp = angular.module('chrisChanApp', []);

myApp.controller('MenuController', ['$scope', function ($scope) {
    $scope.spice = 'very';

    $scope.uploadFile = function () {
        $scope.spice = 'chili';
    };

    $scope.fileStructure = function () {
        $scope.spice = 'jalapeño';
    };
}]);