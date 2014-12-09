<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        textarea {
            height: 200px;
        }
    </style>
</head>
<body>
<form method="get">
    <label>Start date:</label>
    <input type="text" name="dateOne" value="17-12-2014"/>
    <label>End date:</label>
    <input type="text" name="dateTwo" value="31-12-2014"/>
    <label>Holidays:</label>
    <textarea name="holidays">31-12-2014
    24-12-2014
    08-12-2014</textarea>
    <input type="submit" />
</form>
</body>
</html>
<?php
date_default_timezone_set('America/Los_Angeles');
$start = DateTime::createFromFormat('d-m-Y', $_GET['dateOne'])->getTimestamp();
$end = DateTime::createFromFormat('d-m-Y', $_GET['dateTwo'])->getTimestamp();
$hol = array_map('trim', explode(PHP_EOL, $_GET['holidays']));
for ($i = $start; $i <= $end; $i = strtotime('+1 day', $i)) {
    if (!in_array(date('d-m-Y', $i), $hol) &&  date('N', $i) < 6) {
        $result[] = date('d-m-Y', $i);
    }
}
if (isset($result)) {
    echo '<ol>';
    foreach ($result as $r) {
        echo "<li>$r</li>";
    }
    echo '</ol>';
} else {
    echo '<h2>No workdays</h2>';
}