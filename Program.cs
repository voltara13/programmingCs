using System;

namespace programmingCs
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle("Синий", 4);
            var cube = new Cube("Красный", 6.5);

            Console.WriteLine($"Площадь круга: {circle.volume()}");
            Console.WriteLine($"Площадь куба: {cube.volume()}");

            Shape ptr = cube;
            Console.WriteLine($"Площадь куба: {ptr.volume()}");

            //Здесь применяется динамическое связывание,
            //так как мы используем виртуальные функции.
            //Если мы например создадим объект типа Shape,
            //назовем переменную ptr и присвоим ему 
            //объект cube, то при вызове ptr.volume() вызовется именно
            //Cube.volume()
        }
    }
}//