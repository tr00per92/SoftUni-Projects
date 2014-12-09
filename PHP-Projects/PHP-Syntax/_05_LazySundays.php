<?php
for ($i = 1; $i <= date('t'); $i++) {
    $currentDate = strtotime($i . ' ' . date('F') . ' ' . date('Y'));
    if (date('N', $currentDate) == 7) {
        echo date('jS F, Y', $currentDate) . PHP_EOL;
    }
}