using System;

namespace programmingCs
{
    class Teacher : Person
    {
        public Teacher(string firstName, string secondName, string academicDegree, string subjects) : 
            base(firstName, secondName)
        {
            this.academicDegree = academicDegree;
            this.subjects = subjects;
        }
        private string academicDegree;
        private string subjects;

        public override void print()
        {
            base.print();
            Console.WriteLine($"Ученая степень: {academicDegree}\n" +
                              $"Предмет: {subjects}");
        }
    }
}
