<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, input {
            display: block;
        }
        input[type=text] {
            width: 300px;
        }
        table, td {
            border: 1px solid blue;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
<form method="get">
    <label>First string:</label>
    <input type="text" name="mainWord" value='{"row4":"operator"}'>
    <label>Second string:</label>
    <input type="text" name="words" value='["generally","objects","system","like","need"]'>
    <input type="submit" />
</form>
</body>
</html>
<?php
$input = json_decode($_GET['mainWord'], true);
$curPos = key($input);
$main = str_split($input[$curPos]);
$rowNum = (int)substr($curPos, -1);
$rowCount = count($main);
$rowsBeyond = $rowCount - $rowNum;
$words = json_decode($_GET['words'], true);
//$words = array_map('htmlspecialchars' , $words);
//var_dump($words);
// finding the longest word that can cross the main word
$longest = '';
foreach ($words as $word) {

    $len = strlen($word);

    foreach ($main as $char) {

        $curPos = strpos($word, $char);

        if ($curPos !== false && $len > strlen($longest)) {

//            var_dump($curPos);

            if (strlen(substr($word, $curPos + 1)) <= $rowsBeyond
                && strlen(substr($word, 0, $curPos)) <= $rowNum - 1)  {

//                var_dump(substr($word, $curPos + 1));
//                var_dump(strlen(substr($word, $curPos + 1)));
//                var_dump($curPos);
                $longest = $word;
                $col = array_search($char, $main);
                $startRow = $rowNum - 1 - $curPos;
                break;
            }
        }
    }
}
// removing the longest word from the array
if ($longest !== '') unset($words[array_search($longest, $words)]);

// generating the board table
$table = '<table>';
for ($i = 0; $i < $rowCount; $i++) {
    $table .= '<tr>';
    for ($j = 0; $j < $rowCount; $j++) {
        $table .= '<td>';
        if ($i == $rowNum - 1) {
            $table .= $main[$j];
        } else if ($j == $col && $i >= $startRow) {
            $table .= $longest[$i - $startRow];
        }
        $table .= '</td>';
    }
    $table .= '</tr>';
}
$table .= '</table>';

// getting the sum from ASCII codes for the output array;
foreach ($words as $word) {
    if (!isset($result[$word])) {
        $result[$word] = 0;
    }
    for ($i = 0; $i < strlen($word); $i++) {
        $result[$word] += ord($word[$i]);
    }
//    var_dump($result);
}

//var_dump($rowNum);
//var_dump($main);
//var_dump($words);
//var_dump($rowCount);
//var_dump($longest);
//var_dump($startColumn);
//var_dump($startRow);
//var_dump($rowsBeyond);

//echo htmlentities($table);
echo $table;

if (isset($result)) {
    ksort($result);
    echo htmlspecialchars(json_encode($result));
} else {
    echo '[]';
}