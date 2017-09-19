(function () {
	var app = angular.module('app');

	app.controller('CategoryController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.category = {};
			$scope.subdivisions = [];

			function initialize(categoryId) {
				var promises = categoryId ? getCategory(categoryId) : [];
				$http.get('webapi/api/subdivisions').then(function (response) {
					$scope.subdivisions = response.data;
				});
				$scope.ready = true;
			}

			var getCategory = function getCategory(id) {
				$http.get('webapi/api/categories/' + id).then(function (response) {
					$scope.category = response.data;
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('webapi/api/categories/' + entityMode, JSON.stringify($scope.category)).then(function (response) {
							$state.reload();
						});
					} else {
						$http.post('webapi/api/categories/' + entityMode, JSON.stringify($scope.category)).then(function (response) {
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			initialize($stateParams.id);
		}]);
})();
