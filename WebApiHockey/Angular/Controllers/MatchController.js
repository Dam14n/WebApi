(function () {
	var app = angular.module('app');

	app.controller('MatchController', ['$scope', '$state', '$stateParams', '$window', '$http',
		function ($scope, $state, $stateParams, $window, $http) {
			$scope.mode = $stateParams.id ? "Edición" : "Creación";
			var entityMode = $stateParams.id ? "put" : "create";

			$scope.ready = false;
			$scope.match = {};
			$scope.dates = [];
			$scope.teams = [];
			$scope.localGoals = [];
			$scope.enemyGoals = [];
			$scope.localPlayers = [];
			$scope.enemyPlayers = [];
			var goalsToDelete = [];

			function initialize(matchId) {
				var promises = matchId ? getMatch(matchId) : [];
				$http.get('/api/dates').then(function (response) {
					$scope.dates = response.data;
				});
				$http.get('/api/teams').then(function (response) {
					$scope.teams = response.data;
				});
				$scope.ready = true;
			}

			var getMatch = function getMatch(id) {
				$http.get('/api/matches/' + id).then(function (response) {
					$scope.match = response.data;
					$http.get('/api/teams/' + $scope.match.LocalTeamId + '/players').then(function (response) {
						$scope.localPlayers = response.data;
					});
					$http.get('/api/teams/' + $scope.match.EnemyTeamId + '/players').then(function (response) {
						$scope.enemyPlayers = response.data;
					});
					$http.get('/api/matches/' + $scope.match.Id + '/teams/' + $scope.match.LocalTeamId + '/goals').then(function (response) {
						$scope.localGoals = response.data;
					});
					$http.get('/api/matches/' + $scope.match.Id + '/teams/' + $scope.match.EnemyTeamId + '/goals').then(function (response) {
						$scope.enemyGoals = response.data;
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
						$http.put('/api/matches/' + entityMode, JSON.stringify($scope.match)).then(function (response) {
							submitGoals($scope.localGoals);
							submitGoals($scope.enemyGoals);
							deleteGoals();
						});
					} else {
						$http.post('/api/matches/' + entityMode, JSON.stringify($scope.match)).then(function (response) {
							submitGoals($scope.localGoals);
							submitGoals($scope.enemyGoals);
							deleteGoals();
						});
					}
				}
				$scope.ready = true;
			};

			var submitGoals = function (goals) {
				angular.forEach(goals, function (goal) {
					if (goal.Id == null) {
						$http.post('/api/goals/create', JSON.stringify(goal)).then(function (response) {
						});
					} else {
						$http.put('/api/goals/put', JSON.stringify(goal)).then(function (response) {
						});
					}
				});
				$state.reload();
			};

			var deleteGoals = function () {
				angular.forEach(goalsToDelete, function (goal) {
					if (goal.Id != null) {
						$http.delete('/api/goals/delete/' + goal.Id).then(function (response) {
						});
					}
				});
				$state.reload();
			}

			$scope.updateLocalPlayers = function (teamId) {
				if (teamId) {
					$http.get('/api/teams/' + teamId + '/players').then(function (response) {
						$scope.localPlayers = response.data;
					});
				}
			};

			$scope.updateEnemyPlayers = function (teamId) {
				if (teamId) {
					$http.get('/api/teams/' + teamId + '/players').then(function (response) {
						$scope.enemyPlayers = response.data;
					});
				}
			};

			initialize($stateParams.id);

			$scope.addNew = function (teamId) {
				if (teamId == $scope.match.LocalTeamId) {
					$scope.localGoals.push({ MatchId: $scope.match.Id, TeamId: $scope.match.LocalTeamId });
				} else {
					$scope.enemyGoals.push({ MatchId: $scope.match.Id, TeamId: $scope.match.EnemyTeamId });
				}
			};

			$scope.remove = function (teamId) {
				var newDataList = [];
				var goals = [];
				if (teamId == $scope.match.LocalTeamId) {
					goals = $scope.localGoals;
					$scope.localGoalsSelectedAll = false;
				} else {
					goals = $scope.enemyGoals;
					$scope.enemyGoalsSelectedAll = false;
				}
				angular.forEach(goals, function (goal) {
					if (!goal.selected) {
						newDataList.push(goal);
					} else {
						goalsToDelete.push(goal);
					}
				});
				if (teamId == $scope.match.LocalTeamId) {
					$scope.localGoals = newDataList;
				} else {
					$scope.enemyGoals = newDataList;
				}
			};

			$scope.checkAll = function (goals, teamId) {
				angular.forEach(goals, function (goal) {
					if (teamId == $scope.match.LocalTeamId) {
						goal.selected = $scope.localGoalsSelectedAll;
					} else {
						goal.selected = $scope.enemyGoalsSelectedAll;
					}
				});
			};
		}]);
})();
