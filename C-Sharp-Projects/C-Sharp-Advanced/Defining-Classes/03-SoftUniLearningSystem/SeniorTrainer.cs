using System;

namespace _03_SoftUniLearningSystem
{
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age) { }

        public void DeleteCource(string courceName)
        {
            Console.WriteLine("Deleted cource: {0}", courceName);
        }
    }
}
