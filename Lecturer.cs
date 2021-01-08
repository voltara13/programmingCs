using System;

namespace programmingCs
{
    class Lecturer : Teacher
    {
        public Lecturer(string firstName, string secondName, string academicDegree, string subjects, string groups) : 
            base(firstName, secondName, academicDegree, subjects)
        {
            this.groups = groups;
        }
        private string groups;
        public override void print()
        {
            base.print();
            Console.WriteLine($"Список групп: {groups}");
        }
        public new void print2()
        {
            base.print();
            Console.WriteLine($"Список групп: {groups}");
        }
    }
}
