(function () {
	var app = angular.module('app');

	app.controller('GoalsController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listGoals = [];

		//get sample
		var getGoals = function initialize() {
			$http.get('webapi/api/goals').then(function (response) {
				$scope.listGoals = response.data;
			});
		}

		getGoals();

		$scope.deleteGoal = function deleteMatch(goal) {
			$http.delete('webapi/api/goals/delete/' + goal.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
