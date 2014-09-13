<?php
$name = 'Pesho';
$phone = '0884-888-888';
$age = 67;
$address = 'Suhata Reka';
?>

<!DOCTYPE html>
<html>
<head>
    <title>HTML Table</title>
    <style>
        table {
            border: 1px solid black;
            border-collapse: collapse;
        }
        th {
            text-align: left;
            background: orange;
            padding: 0 5px;
        }
        td {
            text-align: right;
        }
    </style>
</head>
<body>
    <table>
        <tr>
            <th>Name</th>
            <td><?=$name?></td>
        </tr>
        <tr>
            <th>Phone number</th>
            <td><?=$phone?></td>
        </tr>
        <tr>
            <th>Age</th>
            <td><?=$age?></td>
        </tr>
        <tr>
            <th>Address</th>
            <td><?=$address?></td>
        </tr>
    </table>
</body>
</html>