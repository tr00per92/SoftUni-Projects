<?php

class Bedroom extends Room
{
    public function __construct($roomNumber, $price)
    {
        $roomInfo = new RoomInfo("Gold", true, true, 2, $roomNumber,
            "TV, air-conditioner, refrigerator, mini-bar, bathtub", $price);
        parent::__construct($roomInfo);
    }
}
