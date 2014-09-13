<!DOCTYPE html>
<html>
<head>
    <title>1. Meeting Days</title>
</head>
<body>
<form method="get">
    <label>
        First date:
        <input type="text" name="dateOne" />
    </label>
    <br />
    <label>
        Second date:
        <input type="text" name="dateTwo" />
    </label>
    <br />
    <input type="submit" value="Submit"/>
</form>
</body>
</html>
<?php
date_default_timezone_set("Europe/Sofia");
$first = DateTime::createFromFormat('d-m-Y', $_GET['dateOne'])->getTimestamp();
$sec = DateTime::createFromFormat('d-m-Y', $_GET['dateTwo'])->getTimestamp();
if ($first > $sec) {
    list($first, $sec) = array($sec, $first);
}
$result = '<ol>';
for ($i = $first; $i <= $sec; $i = strtotime('+1 day', $i)) {
    if (date('N', $i) == 4) {
        $result .= "<li>" . date('d-m-Y', $i) . "</li>";
        $i = strtotime('+6 days', $i);
    }
}
$result .= '</ol>';
if ($result == '<ol></ol>') {
    echo '<h2>No Thursdays</h2>';
} else {
    echo $result;
}