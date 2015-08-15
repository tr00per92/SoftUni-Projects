<?php

class UsersController extends BaseController {
    private $usersModel;

    protected function onInit() {
        $this->title = 'Users';
        $this->usersModel = new UsersModel();
    }

    public function index() {
        $this->redirect('users', 'login');
    }

    public function login() {
        if ($this->isPost()) {
            $user = $this->usersModel->login($_POST['username'], $_POST['password']);
            if (!$user) {
                $this->addErrorMessage('Login error.');
                return;
            }

            $_SESSION['username'] = $user['username'];
            $_SESSION['userId'] = $user['id'];
            $this->redirect('todos');
        }
    }

    public function register() {
        if ($this->isPost()) {
            $username = $_POST['username'];
            if (!$this->usersModel->isUsernameValid($username)) {
                $this->addErrorMessage('This username is already taken.');
                return;
            }

            $userId = $this->usersModel->create($username, $_POST['password']);
            if ($userId) {
                $_SESSION['username'] = $username;
                $_SESSION['userId'] = $userId;
                $this->redirect('todos');
            }

            $this->addErrorMessage('Registration error.');
        }
    }

    public function logout() {
        session_unset();
        session_destroy();
        $this->redirect(DEFAULT_CONTROLLER);
    }
}
