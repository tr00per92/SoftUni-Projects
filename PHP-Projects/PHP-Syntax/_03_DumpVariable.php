<?php
function Dump($var) {
    if (is_numeric($var)) {
        var_dump($var);
    } else {
        echo gettype($var) . PHP_EOL;
    }
}
Dump('hello');
Dump(15);
Dump(1.234);
Dump(array(1,2,3));
Dump((object)[2,34]);