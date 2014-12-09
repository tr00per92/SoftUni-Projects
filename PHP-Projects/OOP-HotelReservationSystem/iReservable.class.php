<?php

interface iReservable
{
    function addReservation(Reservation $reservation);
    function removeReservation(Reservation $reservation);
}
