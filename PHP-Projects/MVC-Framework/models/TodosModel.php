<?php

class TodosModel extends BaseModel {
    public function getAll() {
        $items = R::find('todos', 'user_id = ?', [$_SESSION['userId']]);
        return $items;
    }

    public function create($text) {
        if (strlen($text) < 2) {
            return null;
        }

        $item = R::dispense('todos');
        $item['text'] = $text;
        $item['userId'] = $_SESSION['userId'];
        $itemId = R::store($item);

        return $itemId;
    }

    public function delete($id) {
        $item = R::load('todos', $id);
        if (!$item || $item['userId'] != $_SESSION['userId']) {
            return false;
        }

        R::trash($item);
        $isDeleted = $item['id'] == 0;

        return $isDeleted;
    }
}
