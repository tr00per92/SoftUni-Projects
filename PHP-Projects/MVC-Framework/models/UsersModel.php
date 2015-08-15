<?php

class UsersModel extends BaseModel {
    public function create($username, $password) {
        if (strlen($username) < 2 || strlen($password) < 2) {
            return null;
        }

        $user = R::dispense('users');
        $user['username'] = $username;
        $user['password'] = password_hash($password, PASSWORD_DEFAULT);
        $userId = R::store($user);

        return $userId;
    }

    public function isUsernameValid($username) {
        $user  = R::findOne('users', 'username = ?', [$username]);
        if (!$user) {
            return true;
        }

        return false;
    }

    public function login($username, $password) {
        $user = R::findOne('users', 'username = ?', [$username]);
        if (!$user || !password_verify($password, $user['password'])) {
            return null;
        }

        return $user;
    }
}
