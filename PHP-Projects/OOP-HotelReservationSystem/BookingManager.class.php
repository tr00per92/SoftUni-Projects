<?php

class BookingManager
{
    static function bookRoom(Room $room, Reservation $reservation)
    {
        $room->addReservation($reservation);
        $roomNumber = $room->getRoomInfo()->getRoomNumber();
        $guest = $reservation->getGuest()->getFullName();
        $start = $reservation->getStartDate();
        $end = $reservation->getEndDate();
        echo "Room <strong>$roomNumber</strong> successfully booked for <strong>$guest</strong> from <time>$start</time> to <time>$end</time>!";
    }
}
