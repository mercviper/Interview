var tuanDuongApp = angular.module('tuanDuongApp', ['ngRoute']);

tuanDuongApp.config(function ($routeProvider) {
     $routeProvider
		.when('/', {
		     templateUrl: 'TuanDuong_SimpleHTML.html',
		     controller: 'tuanDuongController'
		})

          .otherwise({
               redirectTo: '/TuanDuong_SimpleHTML.html'
          });
});

tuanDuongApp.controller('tuanDuongController', function ($scope, $routeParams, $window, $location, $http, $filter) {
     $scope.greeting = "Hello, my name is Tuan Duong";
     $scope.index = 1;
     $scope.ShowItem1 = false;
     $scope.ShowItem2 = false;
     $scope.ShowItem3 = false;
     $scope.ShowItem4 = false;
     $scope.ShowItem5 = false;
     $scope.ShowItem6 = false;

     $scope.loadInstruction = function (idx) {
          switch (idx) {
               case 1:
                    $scope.index = idx;
                    $scope.ShowItem1 = true;
                    $scope.ShowItem2 = false;
                    $scope.ShowItem3 = false;
                    $scope.ShowItem4 = false;
                    $scope.ShowItem5 = false;
                    $scope.ShowItem6 = false;
                    break;
               case 2:
                    $scope.index = idx;
                    $scope.ShowItem1 = false;
                    $scope.ShowItem2 = true;
                    $scope.ShowItem3 = false;
                    $scope.ShowItem4 = false;
                    $scope.ShowItem5 = false;
                    $scope.ShowItem6 = false;
                    break;
               case 3:
                    $scope.index = idx;
                    $scope.ShowItem1 = false;
                    $scope.ShowItem2 = false;
                    $scope.ShowItem3 = true;
                    $scope.ShowItem4 = false;
                    $scope.ShowItem5 = false;
                    $scope.ShowItem6 = false;
                    break;
               case 4:
                    $scope.index = idx;
                    $scope.ShowItem1 = false;
                    $scope.ShowItem2 = false;
                    $scope.ShowItem3 = false;
                    $scope.ShowItem4 = true;
                    $scope.ShowItem5 = false;
                    $scope.ShowItem6 = false;
                    break;
               case 5:
                    $scope.index = idx;
                    $scope.ShowItem1 = false;
                    $scope.ShowItem2 = false;
                    $scope.ShowItem3 = false;
                    $scope.ShowItem4 = false;
                    $scope.ShowItem5 = true;
                    $scope.ShowItem6 = false;
                    break;
               case 6:
                    $scope.index = idx;
                    $scope.ShowItem1 = false;
                    $scope.ShowItem2 = false;
                    $scope.ShowItem3 = false;
                    $scope.ShowItem4 = false;
                    $scope.ShowItem5 = false;
                    $scope.ShowItem6 = true;
                    break;
               default:
                    $scope.index = idx;
                    $scope.ShowItem1 = true;
                    $scope.ShowItem2 = false;
                    $scope.ShowItem3 = false;
                    $scope.ShowItem4 = false;
                    $scope.ShowItem5 = false;
                    $scope.ShowItem6 = false;
                    break;
          }
          
     }
})