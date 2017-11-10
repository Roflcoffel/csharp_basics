/// <reference path="angular.js" />

angular
    .module('AngularEx', [])
    .controller('AngController', function ($scope) {
        $scope.browse = "Browse";
        $scope.products = "Products";
        $scope.contact = "Contact";
        $scope.message = "Please click a menu item";

        $scope.clicked = function (num) {
            if (num == 1) {
                $scope.message = "You selected";
                $scope.selected = $scope.browse;
            }
            else if(num == 2){
                $scope.message = "You selected";
                $scope.selected = $scope.products;
            }
            else if (num == 3) {
                $scope.message = "You selected";
                $scope.selected = $scope.contact;
            }
        }
    });

$(document).ready(function () {
    $('a').click(function () {
        $('a').removeClass("active");
        $(this).addClass("active");
    })
})