(function () {
	var app = angular.module('app');

	app.controller('DateController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.date = {};
			$scope.categories = [];

			function initialize(dateId) {
				var promises = dateId ? getDate(dateId) : [];
				$http.get('webapi/api/categories').then(function (response) {
					$scope.categories = response.data;
				});
				$scope.ready = true;
			}

			var getDate = function getDate(id) {
				$http.get('webapi/api/dates/' + id).then(function (response) {
					$scope.date = response.data;
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('webapi/api/dates/' + entityMode, JSON.stringify($scope.date)).then(function (response) {
							$state.reload();
						});
					} else {
						$http.post('webapi/api/dates/' + entityMode, JSON.stringify($scope.date)).then(function (response) {
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			initialize($stateParams.id);
		}]);
})();
