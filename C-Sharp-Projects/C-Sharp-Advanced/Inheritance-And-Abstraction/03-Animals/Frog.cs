using System;

namespace _03_Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, Gender sex)
            : base(name, age, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Croak croak!");
        }
    }
}
