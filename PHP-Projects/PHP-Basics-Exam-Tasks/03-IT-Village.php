<?php
$board = $_GET['board'];
$pos = $_GET['beginning'];
$moves = $_GET['moves'];
//$board = "P I F S | P 0 0 F | N 0 0 V | I F F I";
//$pos = "2 1";
//$moves = "5 11 9 8 6 8 4";

$totalIns = substr_count($board, 'I');
$board = explode('|', str_replace(' ', '', $board));
$row = $pos[0];
$col = $pos[2];
$moves = array_reverse(explode(' ', $moves));

$dice = array_pop($moves);
$coins = 50;
$ins = 0;
while (true) {
    // checking the direction
    if ($row == 1 && $col != 4) {
        $direction = 'right';
    } else if ($col == 4 && $row != 4) {
        $direction = 'down';
    } else if ($row == 4 && $col != 1) {
        $direction = 'left';
    } else if ($col == 1 && $row != 1){
        $direction = 'up';
    }

    // end of current roll
    if ($dice === 0) {
        $coins += $ins * 20;

        $field = $board[$row - 1][$col - 1];
        switch($field) {
            case 'F': $coins += 20; break;
            case 'P': $coins -= 5; break;
            case 'V': $coins *= 10; break;
            case 'N': die("<p>You won! Nakov's force was with you!<p>"); break;
            case 'S': array_pop($moves); array_pop($moves); break;
            case 'I':
                if ($coins >= 100) {
                    $ins++;
                    $totalIns--;
                    $coins -= 100;
                    $board[$row - 1][$col - 1] = ' ';
                } else {
                    $coins -= 10;
                }
                if ($totalIns <= 0) {
                    die("<p>You won! You own the village now! You have $coins coins!<p>");
                }
                break;
        }

        // getting the next dice
        $dice = array_pop($moves);
        if ($dice === null) {
            die("<p>You lost! No more moves! You have $coins coins!<p>");
        }

        // checking coins
        if ($coins <= 0){
            die("<p>You lost! You ran out of money!<p>");
        }
    }

    // moving one field
    $dice--;
    switch ($direction) {
        case 'right': $col++; break;
        case 'down': $row++; break;
        case 'left': $col--; break;
        case 'up': $row--; break;
        default: die('direction error');
    }
}
