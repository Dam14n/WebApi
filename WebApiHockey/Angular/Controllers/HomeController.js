(function () {
	var app = angular.module('app');

	app.controller('HomeController', ['$scope', function ($scope) {
		$scope.vm = {};
		//$scope.vm.message = $scope.hasAuthority('admin') ? "Bienvenido al sector de administradores." : "Bienvenido al sector de usuarios.";
	}]);
})();
