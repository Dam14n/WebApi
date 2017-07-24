(function () {
	var app = angular.module('app');

	app.controller('MatchesController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listMatches = [];

		//get sample
		var getMatches = function initialize() {
			$http.get('/api/matches').then(function (response) {
				$scope.listMatches = response.data;
			});
		}

		getMatches();

		$scope.deleteMatch = function deleteMatch(match) {
			$http.delete('/api/matches/delete/' + match.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
