<?php

class Guest
{
    private $firstName;
    private $lastName;
    private $id;

    public function __construct($firstName, $lastName, $id)
    {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setId($id);
    }

    public function setFirstName($firstName)
    {
        if (gettype($firstName) != "string" || !$firstName) {
            throw new InvalidArgumentException("The first name must be a non empty string");
        }

        $this->firstName = $firstName;
    }

    public function getFirstName()
    {
        return $this->firstName;
    }

    public function setLastName($lastName)
    {
        if (gettype($lastName) != "string" || !$lastName) {
            throw new InvalidArgumentException("The last name must be a non empty string");
        }

        $this->lastName = $lastName;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    public function getFullName()
    {
        return $this->firstName . ' ' . $this->lastName;
    }

    public function setId($id)
    {
        if (gettype($id) != "string" || !$id) {
            throw new InvalidArgumentException("The id must be a non empty string");
        }

        $this->id = $id;
    }

    public function getId()
    {
        return $this->id;
    }

    function __toString()
    {
        return "$this->firstName $this->lastName ID: $this->id";
    }
} 