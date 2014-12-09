<?php

abstract class Room implements iReservable
{
    private $roomInfo;
    private $reservations;

    protected function __construct($roomInfo)
    {
        $this->setRoomInfo($roomInfo);
        $this->reservations = [];
    }

    public function setRoomInfo(RoomInfo $roomInfo)
    {
        $this->roomInfo = $roomInfo;
    }

    public function getRoomInfo()
    {
        return $this->roomInfo;
    }

    public function getReservations()
    {
        return $this->reservations;
    }

    public function addReservation(Reservation $reservation)
    {
        if (! $this->roomIsFree($reservation->getStartDate(), $reservation->getEndDate())) {
            throw new EReservationException();
        }

        $this->reservations[] = $reservation;
    }

    public function removeReservation(Reservation $reservation)
    {
        if (($key = array_search($reservation, $this->reservations)) !== false) {
            unset($this->reservations[$key]);
        }
    }

    public function roomIsFree($startDate, $endDate) {
        foreach ($this->reservations as $res) {
            if ((strtotime($startDate) <= strtotime($res->getEndDate()) &&
                    strtotime($startDate) >= strtotime($res->getStartDate())) ||
                ((strtotime($startDate) <= strtotime($res->getStartDate()) &&
                    strtotime($endDate) >= strtotime($res->getStartDate())))) {

                return false;
            }
        }

        return true;
    }

    public function __toString()
    {
        $reservations = implode(", ", $this->reservations);
        if (!$reservations) {
            $reservations = "None";
        }

        return "Room Info - $this->roomInfo\r\nReservations: $reservations";
    }
}
