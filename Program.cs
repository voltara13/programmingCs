namespace programmingCs
{
    class Program
    {
        static void Main()
        {
            var student = new Student(
                "Константин",
                "Красиков",
                "АП-927",
                2);
            var teacher = new Teacher(
                "Евгений",
                "Крыжовников",
                "Доктор",
                "Физика");
            var lecturer = new Lecturer(
                "Василий", 
                "Петров", 
                "Профессор", 
                "Физика", 
                "АП-926, АП-927");
            student.print();
            teacher.print();
            lecturer.print();
        }
    }
}