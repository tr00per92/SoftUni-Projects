<?php
$n = 145;
$result = [];
if ($n < 102) {
    echo 'no';
} else {
    $maxNumber = $n < 999 ? $n : 999;
    for ($i = 102; $i <= $maxNumber; $i++) {
        $firstDigit = (int)($i / 100);
        $secondDigit = (int)(($i / 10) % 10);
        $thirdDigit = (int)($i % 10);
        if ($firstDigit != $secondDigit
            && $firstDigit != $thirdDigit
            && $secondDigit != $thirdDigit) {
           array_push($result, $i);
        }
    }
    echo implode(', ' , $result);
}