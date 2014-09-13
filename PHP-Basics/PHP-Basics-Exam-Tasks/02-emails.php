<!DOCTYPE html>
<html>
<head>
    <title></title>
    <style>
        label, textarea, input {
            display: block;
        }
        textarea {
            width: 300px;
            height: 200px;
        }
    </style>
</head>
<body>
<form>
    <label>Text:</label>
    <textarea name="text">Hi, I'm an air-conditioner technician, so if you need any assistance you can contact me at air-conditioners@gmail.com . Secondary email: kinky_technician@yahoo.in or at naked-screwdriver@abv.bg OR pesho@dir.tk</textarea>
    <label>Blacklist:</label>
    <textarea name="blacklist">*.bg
        pesho@dir.tk
        *.com</textarea>
    <input type="submit" />
</form>
</body>
</html>
<?php
$text = $_GET['text'];
$blacklist = array_map('trim', explode(PHP_EOL, $_GET['blacklist']));
$pattern = '/[\w+-]+@[0-9A-Za-z-]+\.[0-9A-Za-z.-]+/';
preg_match_all($pattern, $text, $emails);
$emails = $emails[0];

foreach ($blacklist as $entry) {
    if (empty($entry)) {
        continue;
    }
    $entry = str_replace('.', '\.', $entry);
    $entry = str_replace('*', '[\w+-]+@[0-9A-Za-z-]+', $entry);
    $entry = "/\b$entry\b/";
    foreach ($emails as $email) {
        if (preg_match($entry, $email)) {
            $text = str_replace($email, str_repeat('*', strlen($email)), $text);
            unset($emails[array_search($email, $emails)]);
        }
    }
}

foreach ($emails as $email) {
    $text = str_replace($email, "<a href=\"mailto:$email\">$email</a>", $text);
}

echo "<p>$text</p>";