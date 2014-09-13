<!DOCTYPE html>
<html>
<head>
    <title>Primes Finder</title>
    <meta charset="UTF-8">
    <style>
        .bold {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form>
        <label for="start">Starting Index</label>
        <input type="text" name="start" id="start"/>
        <label for="end">End</label>
        <input type="text" name="end" id="end"/>
        <input type="submit" value="Submit"/>
    </form>
    <?php
    if (isset($_GET['start']) && isset($_GET['end']) && $_GET['start'] <= $_GET['end']) {
        function isPrime($num) {
            if ($num < 2) return false;
            if ($num == 2) return true;
            if ($num % 2 == 0) return false;
            for ($i = 3; $i < sqrt($num); $i += 2) {
                if ($num % $i == 0) return false;
            }
            return true;
        }
        for ($i = $_GET['start']; $i <= $_GET['end']; $i++) {
            if (isPrime($i)) {
                echo "<span class='bold'>$i</span>";
            }
            else {
                echo $i;
            }
            if ($i != $_GET['end']) {
                echo ', ';
            }
        }
    }
    ?>
</body>
</html>