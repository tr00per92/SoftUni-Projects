<h1><?= htmlspecialchars($_SESSION['username']) ?>'s To Do List</h1>
<ul>
    <?php foreach ($this->items as $item): ?>
    <li><?= htmlspecialchars($item['text']) ?> <a href="/todos/delete/<?= $item['id'] ?>">[Delete]</a></li>
    <?php endforeach; ?>
</ul>
