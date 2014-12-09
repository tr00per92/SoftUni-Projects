<!DOCTYPE html>
<html>
<head>
    <title>Form Data</title>
</head>
<body>
    <form>
        <input type="text" name="name" placeholder="Name.."/><br>
        <input type="text" name="age" placeholder="Age.."/><br>
        <input type="radio" name="sex" value="male"/>Male<br>
        <input type="radio" name="sex" value="female"/>Female<br>
        <input type="submit" value="Submit"/><br>
        <?php
        if (isset($_GET['name']) && isset($_GET['age']) && isset($_GET['sex'])) {
            $name = htmlentities($_GET['name']);
            $age = htmlentities($_GET['age']);
            $sex = htmlentities($_GET['sex']);
            echo "My name is $name. I am $age years old. I am $sex.";
        }
        ?>
    </form>
</body>
</html>