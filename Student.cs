using System;

namespace programmingCs
{
    class Student : Person
    {
        public Student(string firstName, string secondName, string group, int course) :
            base(firstName, secondName)
        {
            this.group = group;
            this.course = course;
        }
        private string group;
        private int course;
        public override void print()
        {
            base.print();
            Console.WriteLine($"Группа: {group}\n" +
                              $"Курс: {course}");
        }
    }
}
