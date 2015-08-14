<?php
require 'includes/checkUser.php';
require 'includes/db.php';
if (isset($_POST['item'])) {
    addToDoItem($_POST['item'], $_SESSION['userId']);
}

header('Location: list.php');
