<!DOCTYPE html>
<html>
<head>
    <title>3. PIN Validation</title>
</head>
<body>
<form method="get">
    <label>
        Name:
        <input type="text" name="name" value="Ana Ivanova"/>
    </label>
    <br />
    <label>
        male:
        <input type="radio" name="gender" value="male" />
    </label>
    <label>
        female:
        <input type="radio" name="gender" value="female" checked="checked"/>
    </label>
    <br />
    <label>
        PIN:
        <input type="text" name="pin" value="9912164756"/>
    </label>
    <br />
    <input type="submit" value="Submit"/>
</form>
</body>
</html>
<?php
$name = preg_split ('/\s+/', trim($_GET['name']));
$sex = $_GET['gender'] == 'male' ? 0 : 1;
$egn = trim($_GET['pin']);
if (strlen($egn) != 10 || count($name) != 2 || (int)$egn[8] % 2 != $sex) {
    die('<h2>Incorrect data</h2>');
}
$name = "$name[0] $name[1]";
$day = (int)($egn[4] . $egn[5]);
$year = (int)('19' . $egn[0] . $egn[1]);
$month = $egn[2] . $egn[3];
if ($month[0] == 4 || $month[0] == 5) {
    $year += 100;
    $month = (int)$month - 40;
} else if ($month[0] == 2 || $month[0] == 3) {
    $year -= 100;
    $month = (int)$month - 20;
} else {
    $month = (int)$month;
}
if (!checkdate($month, $day, $year)) {
    die('<h2>Incorrect data</h2>');
}
$digits = array_map('intval', str_split($egn));
$nums = [2,4,8,5,10,9,7,3,6,0];
$sum = 0;
for ($i = 0; $i < 9; $i++) {
    $sum += $digits[$i] * $nums[$i];
}
var_dump($nums);
var_dump($digits);
var_dump($sum);
var_dump($sum % 11% 10);
if ($sum % 11 % 10 != $digits[9]) {
    die('<h2>Incorrect data</h2>');
}
echo json_encode(array('name'=>$name,'gender'=>$_GET['gender'],'pin'=>$egn));
