$(function () {
    if (localStorage['submitted']) {
        showAnswers();
        return;
    }

    var secondsLeft = localStorage['secondsLeft'] || 300;
    $('#submit-btn').click(submitAnswers);
    $('select').change(saveAnswerInStorage).each(getAnswerFromStorage);
    setInterval(timeLoop, 1000);

    function saveAnswerInStorage() {
        localStorage[$(this).attr('id')] = $(this).val();
    }

    function getAnswerFromStorage() {
        $(this).val(localStorage[$(this).attr('id')]);
    }

    function submitAnswers() {
        localStorage['submitted'] = true;
        location.reload();
    }

    function showAnswers() {
        $('#submit-btn, #timer, select').hide();
        $('.answer').show().each(function(key, val) {
            var answer = $(val),
                answerText = answer.text(),
                answerIsCorrect = localStorage['question' + key] == answerText ? 'correct' : 'wrong';

            answer.text('You were ' + answerIsCorrect + '. The answer is: ' + answerText + '.');
        });
        $('<button>').text('Play Again').appendTo('#wrapper').click(function () {
            localStorage.clear();
            location.reload();
        });
    }

    function timeLoop() {
        $('#timer').text('Remaining time - ' + formatTimeLeft());
        localStorage['secondsLeft'] = secondsLeft;
        if (secondsLeft <= 0) {
            submitAnswers();
        }
        secondsLeft--;
    }

    function formatTimeLeft() {
        var minutes = Math.floor(secondsLeft / 60),
            seconds = secondsLeft % 60;
        return (minutes < 10 ? '0'+ minutes : minutes) + ':' + (seconds < 10 ? '0'+ seconds : seconds);
    }
});
