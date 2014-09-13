<!DOCTYPE html>
<html>
<head>
    <title>Pretty Text</title>
    <meta charset="UTF-8">
</head>
<body>
    <form>
        <input type="text" name="text"/>
        <input type="text" name="hashValue"/>
        <input type="text" name="fontSize"/>
        <input type="text" name="fontStyle"/>
        <input type="submit" value="submit"/>
    </form>
</body>
</html>
<?php
$text = $_GET['text'];
$hash = $_GET['hashValue'];
$textArr = str_split($text);
for ($i = 0; $i < count($textArr); $i++) {
    if ($i % 2 == 0)
        $textArr[$i] = chr(ord($textArr[$i]) + $hash);
    else
        $textArr[$i] = chr(ord($textArr[$i]) - $hash);
}
$text = implode($textArr);
$font = $_GET['fontSize'];
$style = $_GET['fontStyle'];
if ($style == 'bold') {
    $style = "font-weight:$style";
} else {
    $style = "font-style:$style";
}
echo "<p style=\"font-size:$font;$style;\">$text</p>";