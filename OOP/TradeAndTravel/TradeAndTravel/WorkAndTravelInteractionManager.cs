using System;
using System.Linq;

namespace TradeAndTravel
{
    public class WorkAndTravelInteractionManager : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            if (actor.ListInventory().Any(item => item is Iron))
            {
                if (commandWords[2] == "weapon" && actor.ListInventory().Any(item => item is Wood))
                {
                    this.AddToPerson(actor, new Weapon(commandWords[3]));
                }
                else if (commandWords[2] == "armor")
                {
                    this.AddToPerson(actor, new Armor(commandWords[3]));
                }
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor.Location is Forest && actor.ListInventory().Any(item => item is Weapon))
            {
               this.AddToPerson(actor, new Wood(commandWords[2]));
            }
            else if (actor.Location is Mine && actor.ListInventory().Any(item => item is Armor))
            {
                this.AddToPerson(actor, new Iron(commandWords[2]));
            }
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }

            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }

            return person;
        }
    }
}
