<!DOCTYPE html>
<html>

<head>
    <link rel="stylesheet" href="/content/styles.css" />
    <title><?= htmlspecialchars($this->title) ?></title>
</head>

<body>
<div id="wrapper">
<header>
    <ul class="menu">
        <li><a href="/">Home</a></li>
        <?php if ($this->isLoggedIn()): ?>
        <li><a href="/todos/add">Add Item</a></li>
        <li><a href="/users/logout">Logout (<?= htmlspecialchars($_SESSION['username']) ?>)</a></li>
        <?php else: ?>
        <li><a href="/users/register">Register</a></li>
        <li><a href="/users/login">Login</a></li>
        <?php endif; ?>
    </ul>
</header>
<?php include_once('messages.php'); ?>
