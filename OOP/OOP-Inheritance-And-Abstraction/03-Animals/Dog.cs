using System;

namespace _03_Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Bark bark!");
        }
    }
}
