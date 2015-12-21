var fetchAllObjectsWithTags = function () {

    $.ajax({
        url: '/umbraco/Surface/FeedSurface/HandleFormPost',
        type: 'POST',
        dataType: 'JSON',
        data: dataObject,
        success: function (data) {
            alert(data);
        }, error: function (err) {
            console.log(err);
        }
    })
};

