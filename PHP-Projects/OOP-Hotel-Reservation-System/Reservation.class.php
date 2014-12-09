<?php

class Reservation
{
    private $guest;
    private $startDate;
    private $endDate;

    public function __construct( $guest, $startDate, $endDate)
    {
        $this->setGuest($guest);
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
    }

    public function setGuest(Guest $guest)
    {
        if (!$guest) {
            throw new InvalidArgumentException("The guest cannot be empty");
        }

        $this->guest = $guest;
    }

    public function getGuest()
    {
        return $this->guest;
    }

    public function setStartDate($startDate)
    {
        if (gettype($startDate) != "string" || !$startDate) {
            throw new InvalidArgumentException("The start date must be a non empty string");
        }

        if ($this->endDate && strtotime($this->endDate) < strtotime($startDate)) {
            throw new InvalidArgumentException("The start date must be before the end date");
        }

        $this->startDate = $startDate;
    }

    public function getStartDate()
    {
        return $this->startDate;
    }

    public function setEndDate($endDate)
    {
        if (gettype($endDate) != "string" || !$endDate) {
            throw new InvalidArgumentException("The end date must be a non empty string");
        }

        if ($this->startDate && strtotime($this->startDate) > strtotime($endDate)) {
            throw new InvalidArgumentException("The end date must be after the start date");
        }

        $this->endDate = $endDate;
    }

    public function getEndDate()
    {
        return $this->endDate;
    }

    function __toString()
    {
        return "Guest - $this->guest; Start - $this->startDate; End - $this->endDate";
    }
}
