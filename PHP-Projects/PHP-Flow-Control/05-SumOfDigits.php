<!DOCTYPE html>
<html>
<head>
    <title>Sum of digits</title>
    <meta charset="UTF-8">
    <style>
        table, td {
            border: 1px solid black;
        }
    </style>
</head>
<body>
<form method="post">
    <label for="input">Input string</label>
    <input type="text" name="input" id="input"/>
    <input type="submit" value="Submit"/>
</form>
<?php
if (isset($_POST['input'])) :
    function sumOfDigits($value) {
        if (!is_numeric($value) || $value != (int)$value) {
            return 'I cannot sum that';
        }
        return array_sum(str_split(abs($value)));
    }
    $input = explode(', ', $_POST['input']);
?>
<table>
    <?php foreach ($input as $value) : ?>
    <tr>
        <td><?=$value?></td>
        <td><?=sumOfDigits($value)?></td>
    </tr>
    <?php endforeach; ?>
</table>
<?php endif; ?>
</body>
</html>