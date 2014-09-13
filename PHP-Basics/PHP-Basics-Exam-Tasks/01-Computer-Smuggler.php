<!DOCTYPE html>
<html>
<head>
    <title>Nakov's Affairs</title>
</head>
	<body>
		<form method="get">
			<label for="listParts">Parts:</label>
			<input id="listParts" type="text" name="list"/>
			<input type="submit"/>
		</form>
	</body>
</html>
<?php
$prices = array('CPU' => 85, 'ROM' => 45, 'RAM' => 35, 'VIA' => 45);
$input = explode(', ', $_GET['list']);
foreach ($input as $part) {
    if (!isset($prices[$part])) {
        continue;
    }
    if (!isset($parts[$part])) {
        $parts[$part] = 0;
    }
    $parts[$part]++;
}
$computers = 0;
if (count($parts) >= 4) {
    $computers = min($parts);
}
$spent = 0;
$gained = 0;
$left = 0;
foreach ($parts as $part => $count) {
    $price = $prices[$part];
    if ($count >= 5) {
        $price /= 2;
    }
    $spent += $count * $price;
    $left += $count - $computers;
    $gained += ($count - $computers) * ($prices[$part] / 2);
}
$gained += $computers * 420;
$total = $gained - $spent;
$word = $total > 0 ? 'gained' : 'lost';
echo "<ul><li>$computers computers assembled</li><li>$left parts left</li></ul><p>Nakov $word $total leva</p>";