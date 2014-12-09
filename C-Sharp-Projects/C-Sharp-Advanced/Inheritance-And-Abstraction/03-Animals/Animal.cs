using System;

namespace _03_Animals
{
    public abstract class Animal : ISound
    {
        protected Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Sex { get; set; }

        public abstract void ProduceSound();
    }
}
