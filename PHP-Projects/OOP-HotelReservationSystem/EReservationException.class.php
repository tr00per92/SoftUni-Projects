<?php

class EReservationException extends Exception
{
    public function __construct()
    {
        parent::__construct("The room is reserved for that period!", 101);
    }
} 