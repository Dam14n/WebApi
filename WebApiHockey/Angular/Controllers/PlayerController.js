(function () {
	var app = angular.module('app');

	app.controller('PlayerController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.player = {};
			$scope.teams = [];

			function initialize(playerId) {
				var promises = playerId ? getPlayer(playerId) : [];
				$http.get('/api/teams').then(function (response) {
					$scope.teams = response.data;
					$scope.teams.push({Name: "SIN EQUIPO"});
				});
				$scope.ready = true;
			};

			var getPlayer = function getPlayer(id) {
				$http.get('/api/players/' + id).then(function (response) {
					$scope.player = response.data;
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('/api/players/' + entityMode, JSON.stringify($scope.player)).then(function (response) {
							$state.reload();
						});
					} else {
						$http.post('/api/players/' + entityMode, JSON.stringify($scope.player)).then(function (response) {
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			initialize($stateParams.id);
		}]);
})();
