<?php
$year = date('Y');
$months = ['Януари', 'Февруари', 'Март', 'Април', 'Май', 'Юни',
    'Юли', 'Август', 'Септември', 'Октомври', 'Ноември', 'Декември'];
$daysOfWeek = ['По', 'Вт', 'Ср', 'Чт', 'Пе', 'Сб', 'Не'];
?>
<!DOCTYPE html>
<html>
<head>
    <title>Awesome Calendar</title>
    <meta charset="UTF-8">
    <style>
        div {
            display: inline-block;
            width: 19%;
            margin: 30px;
        }
        table {
            width: 100%;
        }
        h1, h4, td {
            margin-bottom: 0;
            text-align: center;
        }
    </style>
</head>
<body>
    <header><h1><?=$year?></h1></header>
    <?php
    foreach ($months as $index => $month) {
        echo "<div><h4>$month</h4><br><table><tr>";
        foreach ($daysOfWeek as $day) {
            echo "<th>$day</th>";
        }
        echo "</tr>";
        $totalDays = date('t', mktime(0, 0, 0, $index + 1, 1, $year));
        $firstDayOfWeek = date('N', mktime(0, 0, 0, $index + 1, 1, $year));
        $currentDay = 1;
        for ($j = 1; $j <= 5; $j++) {
            echo "<tr>";
            for ($i = 1; $i <= 7; $i++) {
                echo "<td>";
                if ($j != 1 || $i >= $firstDayOfWeek) {
                    if ($currentDay <= $totalDays) {
                        echo $currentDay;
                        $currentDay++;
                    }
                }
                echo "</td>";
            }
            echo "</tr>";
        }
        echo "</table></div>";
    }
    ?>
</body>
</html>