namespace Estates.Data
{
    using System;

    using Interfaces;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        public bool HasElevator { get; set; }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }

            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Rooms", "The rooms must be between 0 and 20.");
                }

                this.rooms = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}
