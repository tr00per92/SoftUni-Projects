$(function() {
    $('#tree-container').treeView();

    var messageBox = $('#message-box').messageBox();
    $('#success-btn').click(function() {
        messageBox.success('Success message.')
    });

    $('#error-btn').click(function() {
        messageBox.error('Error message.');
    });
});
