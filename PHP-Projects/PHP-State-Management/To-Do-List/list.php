<?php require 'includes/checkUser.php' ?>
<!DOCTYPE html>
<html>
<head>
    <title>To Do List</title>
    <meta charset="UTF-8">
</head>
<body>
<h3>Your To Do Items</h3>
<ul>
<?php
require 'includes/db.php';
$toDoItems = getToDoItems($_SESSION['userId']);
foreach ($toDoItems as $item) {
    $itemText = $item['text'];
    $itemId = $item['id'];
    echo "<li>$itemText <a href='delete.php?toDoId=$itemId'>[delete]</a></li>";
}
?>
</ul>
<form method="post" action="add.php">
    <label for="item">New Item: </label>
    <input type="text" name="item" id="item">
    <button type="submit">Add</button>
</form>
<a href="index.php">Logout</a>
</body>