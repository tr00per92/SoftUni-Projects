<!DOCTYPE html>
<html>
<head>
    <title>Rich People's Problems</title>
    <meta charset="UTF-8">
    <style>
        table, th, td {
            border: 1px solid black;
        }
        th, td {
            padding: 4px;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="cars">Enter cars</label>
    <input type="text" name="cars" id="cars"/>
    <input type="submit" value="Show result">
</form>
<?php if (isset($_POST['cars'])) :
$cars = explode(', ', $_POST['cars']);
$colors = ['red', 'green', 'blue', 'pink', 'orange', 'yellow', 'black'];
?>
<table>
    <tr>
        <th>Car</th>
        <th>Colour</th>
        <th>Count</th>
    </tr>
    <?php foreach ($cars as $car) :
        $quantity = mt_rand(1, 5);
        $color = $colors[array_rand($colors)];
    ?>
    <tr>
        <td><?=$car?></td>
        <td><?=$color?></td>
        <td><?=$quantity?></td>
    </tr>
    <?php endforeach; ?>
</table>
<?php endif; ?>
</body>
</html>