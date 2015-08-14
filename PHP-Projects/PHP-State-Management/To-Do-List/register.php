<!DOCTYPE html>
<html>
<head>
    <title>To Do List</title>
    <meta charset="UTF-8">
</head>
<body>
<h3>Registration</h3>
<form method="post">
    <label for="username">Username: </label>
    <input type="text" name="username" id="username">
    <label for="password">Password: </label>
    <input type="password" name="password" id="password">
    <button type="submit">Register</button>
</form>
<a href="login.php">Login</a>
<br />
<?php
if (isset($_POST['username']) && isset($_POST['password'])) {
    require 'includes/db.php';
    if (!isUsernameValid($_POST['username'])) {
        echo 'This username is already taken. Please try again.';
        die();
    }

    $password = password_hash($_POST['password'], PASSWORD_DEFAULT);
    createUser($_POST['username'], $password);
    echo 'Registration successful.';
}
?>
</body>