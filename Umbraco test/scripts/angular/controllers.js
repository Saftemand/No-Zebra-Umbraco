var myApp = angular.module('myApp', []);

var readAllTags = function () {
    var tags = $('#txt_tag_holder').val();
    var tagsCommaDelimited = tags.split(' ').join(',');
    return tagsCommaDelimited;
};

var updateView = function ($scope, $http) {
    this.update = function (firstOrLast) {
        var tagString = readAllTags();
        var sortByDate = $('#chbx_sort').is(':checked');

        if (tagString === '') {
            return;
        };

        var dataObject = { 'tags': tagString, 'sortByDate': sortByDate, 'firstOrLast': firstOrLast };
        
        $http.post('/umbraco/Surface/FeedSurface/HandleFormPost', dataObject)
            .success(function (data) {
                $scope.photoCollection = JSON.parse(data);
                console.log($scope.photoCollection.items);
                $scope.update = updateView;
 
                if(firstOrLast === 'first'){
                    $('#btn-load-more').removeClass('hidden');
                } else if (firstOrLast === 'last') {
                    $('#btn-load-more').addClass('hidden');
                }
                
            }).error(function (errorResponse) {
                console.log(errorResponse);
            });
    }
    
};

updateView.$inject = ['$scope', '$http'];

$().ready(function () {
    $('#btn-load-more').click(updateView);
});

//$scope and $http are put in the strings to keep their identity if the variable-names should be changed during minification
myApp.controller('MyController', updateView);


