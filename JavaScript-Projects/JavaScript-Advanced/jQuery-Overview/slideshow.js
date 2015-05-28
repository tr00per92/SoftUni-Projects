(function() {
    $(function() {
        var sliderItems = $('.sliderItem'),
            index = 0,
            interval;
        sliderItems.hide();
        showNext();
        $('#next-btn').click(showNext);
        $('#prev-btn').click(showPrev);

        function showNext() {
            if (index >= sliderItems.length){
                index = 0;
            }

            showItem(index);
            index++;
        }

        function showPrev() {
            if (index <= 0) {
                index = sliderItems.length - 1;
            }

            showItem();
            index--;
        }

        function showItem() {
            sliderItems.hide();
            $(sliderItems[index]).fadeIn(500);
            clearInterval(interval);
            interval = setInterval(showNext, 5000);
        }
    });
})();
