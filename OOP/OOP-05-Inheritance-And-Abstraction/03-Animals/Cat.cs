using System;

namespace _03_Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow!");
        }
    }
}
