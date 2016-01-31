(function($) {
    $.fn.treeView = function() {
        $(this).click(function(e) {
            $(e.target).children().toggle();
        });

        return $(this);
    };
}(jQuery));
