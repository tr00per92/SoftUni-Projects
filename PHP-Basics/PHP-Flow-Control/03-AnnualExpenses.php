<!DOCTYPE html>
<html>
<head>
    <title>Annual Expenses</title>
    <meta charset="UTF-8">
    <style>
        table, th, td {
            border: 1px solid black;
        }
        th, td {
            padding: 3px;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="years">Enter number of years</label>
    <input type="text" name="years" id="years"/>
    <input type="submit" value="Show costs">
</form>
<?php if (isset($_POST['years'])) : ?>
<table>
    <tr>
        <th>Year</th>
        <?php for ($i = 1; $i <= 12; $i++) :
        $month = date('F', mktime(0, 0, 0, $i, 1, 2014));
        ?>
        <th><?=$month?></th>
        <?php endfor; ?>
        <th>Total</th>
    </tr>
    <?php for ($i = date("Y"); $i > date("Y") - $_POST['years']; $i--) :
    $total = 0;
    ?>
    <tr>
        <td><?=$i?></td>
        <?php for ($j = 1; $j <= 12; $j++) :
        $current = mt_rand(0, 999);
        $total += $current;
        ?>
        <td><?=$current?></td>
        <?php endfor; ?>
        <td><?=$total?></td>
    </tr>
    <?php endfor; ?>
</table>
<?php endif; ?>
</body>
</html>