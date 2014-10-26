<?php

class Apartment extends Room
{
    public function __construct($roomNumber, $price)
    {
        $roomInfo = new RoomInfo("Diamond", true, true, 4, $roomNumber,
            "TV, air-conditioner, refrigerator, kitchen box, mini-bar, bathtub, free Wi-fi", $price);
        parent::__construct($roomInfo);
    }
}
