<?php
$newYear = strtotime('1 January ' . (date('Y') + 1));
$timeLeft = $newYear - time();
echo 'Hours until new year : ' . (int)($timeLeft / 60 / 60) . PHP_EOL;
echo 'Minutes until new year : ' . (int)($timeLeft / 60) . PHP_EOL;
echo 'Seconds until new year : ' . $timeLeft . PHP_EOL;
echo 'Days:Hours:Minutes:Seconds ' . (int)($timeLeft / 60 / 60 / 24) . ':'
                                   . (int)($timeLeft / 60 / 60 % 24) . ':'
                                   . (int)($timeLeft / 60 % 60) . ':'
                                   . $timeLeft % 60 . PHP_EOL;