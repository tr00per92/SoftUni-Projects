<?php

class RoomInfo
{
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;

    public function __construct($roomType, $hasRestroom, $hasBalcony,
                         $bedCount, $roomNumber, $extras, $price)
    {
        $this->setRoomType($roomType);
        $this->setExtras($extras);
        $this->setHasBalcony($hasBalcony);
        $this->setHasRestroom($hasRestroom);
        $this->setPrice($price);
        $this->setRoomNumber($roomNumber);
        $this->setBedCount($bedCount);
    }

    public function setBedCount($bedCount)
    {
        if (gettype($bedCount) != "integer" || $bedCount <= 0) {
            throw new InvalidArgumentException("The bed count must be a positive integer");
        }

        $this->bedCount = $bedCount;
    }

    public function getBedCount()
    {
        return $this->bedCount;
    }

    public function setExtras($extras)
    {
        if (gettype($extras) != "string" || !$extras) {
            throw new InvalidArgumentException("The extras must be a non empty string");
        }

        $this->extras = $extras;
    }

    public function getExtras()
    {
        return $this->extras;
    }

    public function setHasBalcony($hasBalcony)
    {
        if (gettype($hasBalcony) != "boolean") {
            throw new InvalidArgumentException("The has balcony must be true or false");
        }

        $this->hasBalcony = $hasBalcony;
    }

    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    public function setHasRestroom($hasRestroom)
    {
        if (gettype($hasRestroom) != "boolean") {
            throw new InvalidArgumentException("The restroom must be true or false");
        }

        $this->hasRestroom = $hasRestroom;
    }

    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    public function setPrice($price)
    {
        if ((gettype($price) != "double" && gettype($price) != "integer") || $price <= 0) {
            throw new InvalidArgumentException("The price must be a positive number");
        }

        $this->price = $price;
    }

    public function getPrice()
    {
        return $this->price;
    }

    public function setRoomNumber($roomNumber)
    {
        if (gettype($roomNumber) != "integer" || $roomNumber <= 0) {
            throw new InvalidArgumentException("The room number must be a positive integer");
        }

        $this->roomNumber = $roomNumber;
    }

    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    public function setRoomType($roomType)
    {
        if ($roomType != "Standart" && $roomType != "Gold" && $roomType != "Diamond") {
            throw new InvalidArgumentException("The room type can only be Standart, Gold or Diamond");
        }

        $this->roomType = $roomType;
    }

    public function getRoomType()
    {
        return $this->roomType;
    }

    function __toString()
    {
        $restroom = $this->hasRestroom ? "Yes" : "No";
        $balcony = $this->hasBalcony ? "Yes" : "No";
        return "Type: $this->roomType; Number of beds: $this->bedCount; Restroom: $restroom; " .
            "Balcony: $balcony; Price: $this->price; Extras: $this->extras; Number: $this->roomNumber";
    }
}
