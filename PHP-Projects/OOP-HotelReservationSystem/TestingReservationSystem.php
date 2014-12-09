<?php

function __autoload($className) {
    require_once($className . '.class.php');
}

$pesho = new Guest("Pesho", "Petrov", "85564");
$booking = new Reservation($pesho, "2014-08-15", "2014-08-20");
echo $booking;
echo PHP_EOL . PHP_EOL;

$apartment = new Apartment(1402, 300);
echo $apartment;
echo PHP_EOL . PHP_EOL;

$room = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", "8003224277");
$startDate = "24.10.2014";
$endDate = "26.10.2014";
$reservation = new Reservation($guest, $startDate, $endDate);
BookingManager::bookRoom($room, $reservation);
echo PHP_EOL;

$gosho = new Guest("Gosho", "Goshev", "3224277");
$reservation1 = new Reservation($gosho, "25.10.2014", "28.10.2014");
try {
    // throws EReservationException
    BookingManager::bookRoom($room, $reservation1);
} catch (EReservationException $ex) {
    echo $ex->getMessage() . PHP_EOL;
}
BookingManager::bookRoom($apartment, $reservation1);
echo PHP_EOL . PHP_EOL;

$roomsArray = [$apartment, $room, new Bedroom(155, 60), new Apartment(102, 120), new SingleRoom(666, 400), new Bedroom(9999, 350)];
$cheapBedroomAndApartments = array_filter($roomsArray, function($room) {
    return (get_class($room) == "Bedroom" || get_class($room) == "Apartment") &&
        $room->getRoomInfo()->getPrice() <= 250;
});
//print_r($cheapBedroomAndApartments);

$roomsWithBalcony = array_filter($roomsArray, function($room) {
    return $room->getRoomInfo()->getHasBalcony();
});
//print_r($roomsWithBalcony);

$roomsWithBathtub = array_filter($roomsArray, function($room) {
    return strpos($room->getRoomInfo()->getExtras(), 'bathtub') !== false;
});
//print_r($roomsWithBathtub);

$freeApartments = array_filter($roomsArray, function($room) {
    return get_class($room) == "Apartment" && $room->roomIsFree("20.10.2014", "30.10.2014");
});
//print_r($freeApartments);
