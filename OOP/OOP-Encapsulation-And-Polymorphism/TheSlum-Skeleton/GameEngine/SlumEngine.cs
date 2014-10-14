using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSlum.GameEngine
{
    public class SlumEngine : Engine
    {
        public SlumEngine()
        {
            this.timeoutItems = new List<Bonus>();
        }

        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = (Team)Enum.Parse(typeof(Team), inputParams[5]);
            Character currentCharacter;

            switch (inputParams[1])
            {
                case "mage":
                    currentCharacter = new Mage(id, x, y, team);
                    break;
                case "warrior":
                    currentCharacter = new Warrior(id, x, y, team);
                    break;
                case "healer":
                    currentCharacter = new Healer(id, x, y, team);
                    break;
                default:
                    throw new InvalidOperationException();
                    break;
            }

            this.characterList.Add(currentCharacter);
        }
            
        protected override void AddItem(string[] inputParams)
        {
            Item currentItem;
            switch (inputParams[2])
            {
                case "axe":
                    currentItem = new Axe(inputParams[3]);
                    break;
                case "shield":
                    currentItem = new Shield(inputParams[3]);
                    break;
                case "pill":
                    currentItem = new Pill(inputParams[3]);
                    this.timeoutItems.Add((Bonus)currentItem);
                    break;
                case "injection":
                    currentItem = new Injection(inputParams[3]);
                    this.timeoutItems.Add((Bonus)currentItem);
                    break;
                default:
                    throw new InvalidOperationException();
                    break;
            }

            Character currentCharacter = this.characterList.First(x => x.Id == inputParams[1]);
            currentCharacter.AddToInventory(currentItem);
        }
    }
}
