<?php
require 'includes/checkUser.php';
require 'includes/db.php';
if (isset($_GET['toDoId'])) {
    deleteToDoItem($_GET['toDoId'], $_SESSION['userId']);
}

header('Location: list.php');