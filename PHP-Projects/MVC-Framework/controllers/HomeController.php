<?php

class HomeController extends BaseController {
    protected function onInit() {
        if ($this->isLoggedIn()) {
            $this->redirect('todos');
        }

        $this->title = 'To Do List';
    }
}
