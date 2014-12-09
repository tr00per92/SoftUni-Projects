using System;

namespace _03_Student
{
    public class Test
    {
        public static void Main()
        {
            Student student = new Student("Peter", 22);
            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };
            student.Name = "Maria";
            student.Age = 19;
            student.Name = "Gosho";
            student.Age = 24;
        }
    }
}
