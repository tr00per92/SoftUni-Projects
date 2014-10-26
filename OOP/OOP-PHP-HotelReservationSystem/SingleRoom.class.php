<?php

class SingleRoom extends Room
{
    public function __construct($roomNumber, $price)
    {
        $roomInfo = new RoomInfo("Standart", true, false, 1, $roomNumber,
            "TV, air-conditioner", $price);
        parent::__construct($roomInfo);
    }
}
