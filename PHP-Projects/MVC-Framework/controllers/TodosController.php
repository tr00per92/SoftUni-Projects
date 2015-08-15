<?php

class TodosController extends BaseController {
    private $todosModel;

    protected function onInit() {
        $this->authorize();
        $this->title = 'To Do List';
        $this->todosModel = new TodosModel();
    }

    public function index() {
        $this->items = $this->todosModel->getAll();
    }

    public function add() {
        if ($this->isPost()) {
            if ($this->todosModel->create($_POST['item'])) {
                $this->redirect('todos');
            }

            $this->addErrorMessage('Could not create item.');
        }
    }

    public function delete($id) {
        if (!$this->todosModel->delete($id)) {
            $this->addErrorMessage('Could not delete item.');
        }

        $this->redirect('todos');
    }
}
