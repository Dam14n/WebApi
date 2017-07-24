(function () {
	var app = angular.module('app');

	app.controller('GoalController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.goal = {};
			$scope.matches = [];
			$scope.teams = [];
			$scope.players = [];

			function initialize(goalId) {
				var promises = goalId ? getGoal(goalId) : [];
				$http.get('/api/matches').then(function (response) {
					$scope.matches = response.data;
				});
				$scope.ready = true;
			}

			$scope.updateTeams = function (matchId) {
				if (matchId != null) {
					$http.get('/api/matches/' + $scope.goal.MatchId + '/teams').then(function (response) {
						$scope.teams = response.data;
					});
				}
				$scope.players = [];
			};

			$scope.updatePlayers = function (teamId) {
				if (teamId != null) {
					$http.get('/api/teams/' + $scope.goal.TeamId + '/players').then(function (response) {
						$scope.players = response.data;
					});
				}
			};

			var getGoal = function getGoal(id) {
				$http.get('/api/goals/' + id).then(function (response) {
					$scope.goal = response.data;
					$http.get('/api/matches/' + $scope.goal.MatchId + '/teams').then(function (response) {
						$scope.teams = response.data;
						$http.get('/api/teams/' + $scope.goal.TeamId + '/players').then(function (response) {
							$scope.players = response.data;
						});
					});
				});
			}

			$scope.cancelForm = function () {
				$window.history.back();
			};

			$scope.submitForm = function () {
				if ($scope.form.$valid) {
					$scope.ready = false;
					if ($stateParams.id != "") {
						$http.put('/api/goals/' + entityMode, JSON.stringify($scope.goal)).then(function (response) {
							$state.reload();
						});
					} else {
						$http.post('/api/goals/' + entityMode, JSON.stringify($scope.goal)).then(function (response) {
							$state.reload();
						});
					}
				}
				$scope.ready = true;
			};

			initialize($stateParams.id);
		}]);
})();
