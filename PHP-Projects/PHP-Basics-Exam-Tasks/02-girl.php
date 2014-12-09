<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        textarea {
            width: 300px;
            height: 200px;
        }
    </style>
</head>
<body>
<form method="get">
    <label>Text:</label>
    <textarea name="text"></textarea>
    <label>Key:</label>
    <textarea name="key"></textarea>
    <input type="submit" />
</form>
</body>
</html>
<?php
$text = $_GET['text'];
$key = str_split($_GET['key']);
$regex = '';
for ($i = 0; $i < count($key); $i++) {
    if ($i == 0 || $i == count($key) - 1) {
        if (preg_match('/[^0-9A-Za-z]/', $key[$i]) == 1) {
            $regex .= '\\' . $key[$i];
        } else {
            $regex .= $key[$i];
        }
    } else if (preg_match('/[a-z]/', $key[$i]) == 1) {
        $regex .= '[a-z]*';
    } else if (preg_match('/[A-Z]/', $key[$i]) == 1) {
        $regex .= '[A-Z]*';
    } else if (preg_match('/[0-9]/', $key[$i]) == 1) {
        $regex .= '\d*';
    } else if (preg_match('/[^0-9A-Za-z]/', $key[$i]) == 1) {
        $regex .= '\\' . $key[$i];
    } else {
        $regex .= $key[$i];
    }
}
$regex = "/$regex(.{2,6})$regex/";;

preg_match_all($regex, $text, $words);

//var_dump($_GET['key']);
//var_dump($regex);
//var_dump($text);
//var_dump($words);

echo implode('', $words[1]);
