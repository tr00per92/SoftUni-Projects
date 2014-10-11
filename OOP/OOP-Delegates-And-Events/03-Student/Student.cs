using System;

namespace _03_Student
{
    public class Student
    {
        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs args);
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                OnPropertyChange("Name", this.name, value);
                this.name = value;
            } 
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                OnPropertyChange("Age", this.age, value);
                this.age = value;                
            }
        }

        private void OnPropertyChange(string propertyName, dynamic oldValue, dynamic newValue)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName, oldValue, newValue);
                handler(this, args);
            }
        }
    }
}
