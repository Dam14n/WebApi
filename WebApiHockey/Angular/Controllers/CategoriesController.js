(function () {
	var app = angular.module('app');

	app.controller('CategoriesController', ['$scope', '$http', '$q', '$state', function ($scope, $http, $q, $state) {
		$scope.listCategories = [];

		//get sample
		var getCategories = function initialize() {
			$http.get('webapi/api/categories').then(function (response) {
				$scope.listCategories = response.data;
			});
		}

		getCategories();

		$scope.deleteCategory = function deleteCategory(subdivision) {
			$http.delete('webapi/api/categories/delete/' + subdivision.Id).then(function (response) {
				$state.reload();
			});
		};
	}]);
})();
