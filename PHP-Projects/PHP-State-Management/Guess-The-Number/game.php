<?php
session_start();
if (isset($_POST['username'])) {
    $_SESSION['username'] = $_POST['username'];
    $_SESSION['number'] = rand(1, 100);
}

if (!isset($_SESSION['name']) || !isset($_SESSION['number'])) {
    header('Location: index.php');
    die();
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Guess The Number</title>
    <meta charset="UTF-8">
</head>
<body>
    <form method="post">
        <label for="guess">Enter a number:</label>
        <input type="text" name="guess" id="guess" />
        <button type="submit">Guess</button>
    </form>
    <?php
    if (isset($_POST['guess'])) {
        $guess = $_POST['guess'];
        $number = $_SESSION['number'];
        if (!ctype_digit($guess) || $guess > 100 || $guess < 0) {
            echo 'Invalid number. You must enter integer between 0 and 100.';
        }
        else if ($guess > $number) {
            echo 'Down.';
        }
        else if ($guess < $number) {
            echo 'Up.';
        }
        else if ($guess == $number) {
            $username = $_SESSION['username'];
            echo "<br/>Congratulations, <strong>$username</strong>, you won! <a href='index.php'><button type='button'>Play Again</button></a>";
        }
    }
    ?>
</body>