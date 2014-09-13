<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        input[type="text"] {
            width: 700px;
        }
    </style>
</head>
<body>
<form method="get" >
    <label>Board:</label>
    <input type="text" name="board" value="R-H-B-K-Q-B-H-R/P-P- -P-P- -P-P/ - -P- - - - - / - - - - -P- - / - - - - - - - / -P- - - - - -H/P- -P-P-P-P-P-P/R-H-B-K-Q-B- -R"/>
    <input type="submit"/>
</form>
</body>
</html>
<?php
$rows = explode('/', $_GET['board']);
if (count($rows) != 8) {
    echo '<h1>Invalid chess board</h1>'; die();
}
$result = '<table>';
$fig = [];
foreach ($rows as $row) {
    $result .= '<tr>';
    $cells = explode('-', $row);
    if (count($cells) != 8) {
        echo '<h1>Invalid chess board</h1>'; die();
    }
    foreach ($cells as $cell) {
        switch ($cell) {
            case ' ': break;
            case 'B':
                if (!isset($fig['Bishop'])) $fig['Bishop'] = 0; $fig['Bishop']++; break;
            case 'R':
                if (!isset($fig['Rook'])) $fig['Rook'] = 0; $fig['Rook']++; break;
            case 'H':
                if (!isset($fig['Horseman'])) $fig['Horseman'] = 0; $fig['Horseman']++; break;
            case 'K':
                if (!isset($fig['King'])) $fig['King'] = 0; $fig['King']++; break;
            case 'Q':
                if (!isset($fig['Queen'])) $fig['Queen'] = 0; $fig['Queen']++; break;
            case 'P':
                if (!isset($fig['Pawn'])) $fig['Pawn'] = 0; $fig['Pawn']++; break;
            default: echo '<h1>Invalid chess board</h1>'; die();
        }
        $result .= "<td>$cell</td>";
    }
    $result .= '</tr>';
}
$result .= '</table>';
echo $result;
ksort($fig);
echo json_encode($fig);