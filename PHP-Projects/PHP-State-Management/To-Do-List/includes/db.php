<?php
require 'libs/rb.php';
// the database must be created
R::setup('mysql:host=localhost;dbname=todolist', 'root', '');

function createUser($username, $password) {
    $user = R::dispense('users');
    $user['username'] = $username;
    $user['password'] = $password;
    R::store($user);
}

function isUsernameValid($username) {
    $user  = R::findOne('users', 'username = ?', [$username]);
    if (!$user) {
        return true;
    }

    return false;
}

function loginUser($username, $password) {
    $user  = R::findOne('users', 'username = ?', [$username]);
    if (!$user || !password_verify($password, $user['password'])) {
        return null;
    }

    return $user;
}

function getToDoItems($usedId) {
    $items = R::find('todos', 'user_id = ?', [$usedId]);
    return $items;
}

function addToDoItem($text, $userId) {
    $item = R::dispense('todos');
    $item['text'] = $text;
    $item['userId'] = $userId;
    R::store($item);
}

function deleteToDoItem($id, $userId) {
    $item = R::load('todos', $id);
    if ($item['userId'] == $userId) {
        R::trash($item);
    }
}