<!DOCTYPE html>
<html>
<head>
    <title>To Do List</title>
    <meta charset="UTF-8">
</head>
<body>
<h3>Login</h3>
<form method="post">
    <label for="username">Username: </label>
    <input type="text" name="username" id="username">
    <label for="password">Password: </label>
    <input type="password" name="password" id="password">
    <button type="submit">Login</button>
</form>
<a href="register.php">Register</a>
<br />
<?php
if (isset($_POST['username']) && isset($_POST['password'])) {
    require 'includes/db.php';
    $user = loginUser($_POST['username'], $_POST['password']);
    if (!$user) {
        echo 'Invalid login. Please try again.';
        die();
    }

    session_start();
    $_SESSION['username'] = $user['username'];
    $_SESSION['userId'] = $user['id'];
    header('Location: list.php');
}
?>
</body>