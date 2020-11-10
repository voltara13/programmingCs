using System;

namespace programmingCs
{
    class Program
    {
        static VectorDocument print_menu(VectorDocument Document)
        {

            for (int k = 0; k < 3; k++)
            {
                Document.AddCircle(k + 1);
                Document.AddRectangle(k + 1);
            }
            int vibor;
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать: ");
                Console.WriteLine("Чтобы добавить фигуру - 1");
                Console.WriteLine("Чтобы удалить фигуру - 2");
                Console.WriteLine("Чтобы работать с кругом - 3");
                Console.WriteLine("Чтобы работать с прямоугольником - 4");
                Console.WriteLine("Чтобы работать со всем документом - 5");
                Console.WriteLine("Чтобы выйти - 0");
                vibor = Convert.ToInt32(Console.ReadLine());
                switch (vibor)
                {
                    case 1:
                        int icase1;
                        Console.WriteLine("Какую фигуру вы хотите добавить?");
                        Console.WriteLine("Круг - 1");
                        Console.WriteLine("Прямоугольник - 2");
                        icase1 = Convert.ToInt32(Console.ReadLine());
                        switch (icase1)
                        {
                            case 1:
                                int icase11;
                                Console.WriteLine("На какое место вы хотите его поставить?");
                                icase11 = Convert.ToInt32(Console.ReadLine());
                                Document.AddCircle(icase11);
                                break;
                            case 2:
                                int icase12;
                                Console.WriteLine("На какое место вы хотите его поставить?");
                                icase12 = Convert.ToInt32(Console.ReadLine());
                                Document.AddRectangle(icase12);
                                break;
                            default:
                                Console.WriteLine("Вы выбрали неверный вариант");
                                break;
                        }
                        break;
                    case 2:
                        int icase2;
                        Console.WriteLine("Какую фигуру вы хотите удалить?");
                        Console.WriteLine("Круг - 1");
                        Console.WriteLine("Прямоугольник - 2");
                        icase2 = Convert.ToInt32(Console.ReadLine());
                        switch (icase2)
                        {
                            case 1:
                                int icase21;
                                Console.WriteLine("С какого места вы хотите его удалить?");
                                icase21 = Convert.ToInt32(Console.ReadLine());
                                Document.DeleteCircle(icase21);
                                break;
                            case 2:
                                int icase22;
                                Console.WriteLine("С какого места вы хотите его удалить?");
                                icase22 = Convert.ToInt32(Console.ReadLine());
                                Document.DeleteRectangle(icase22);
                                break;

                            default:
                                Console.WriteLine("Вы выбрали неверный вариант");
                                break;
                        }
                        break;
                    case 3:
                        int xc, yc, rc, CR, CG, CB, COpacity;
                        int icase3;
                        Console.WriteLine("С каким кругом вы хотите работать?");
                        icase3 = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i != 1;)
                        {
                            Console.WriteLine("Что вы хотите сделать с кругом?");
                            Console.WriteLine("Задать координаты и радиус - 1");
                            Console.WriteLine("Задать цвет - 2");
                            Console.WriteLine("Задать прозрачность - 3");
                            Console.WriteLine("Вывести информацию - 4");
                            Console.WriteLine("Выход - 0");
                            int icase31;
                            icase31 = Convert.ToInt32(Console.ReadLine());
                            switch (icase31)
                            {
                                case 1:
                                    Console.WriteLine("x: ");
                                    xc = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("y: ");
                                    yc = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("r: ");
                                    rc = Convert.ToInt32(Console.ReadLine());
                                    Document.SetXYRCircle(xc, yc, rc, icase3);
                                    break;

                                case 2:
                                    Console.WriteLine("R: ");
                                    CR = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("G: ");
                                    CG = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("B: ");
                                    CB = Convert.ToInt32(Console.ReadLine());
                                    Document.SetCircleColor(CR, CG, CB, icase3);
                                    break;

                                case 3:
                                    Console.WriteLine("Прозрачность %: ");
                                    COpacity = Convert.ToInt32(Console.ReadLine());
                                    Document.SetCircleOpacity(COpacity, icase3);
                                    break;

                                case 4:
                                    Document.PrintCircleXYR(icase3);
                                    Document.PrintCircleArea(icase3);
                                    Document.PrintCircleColor(icase3);
                                    Document.PrintCircleOpacity(icase3);
                                    Document.PrintCirclePerimeter(icase3);
                                    break;

                                case 0:
                                    i = 1;
                                    break;

                                default:
                                    Console.WriteLine("Вы выбрали неверный вариант");
                                    break;
                            }

                        }
                        break;

                    case 4:
                        int x1, y1, x2, y2, RR, RG, RB, ROpacity;
                        int icase4;
                        Console.WriteLine("С каким прямоугольником вы хотите работать?");
                        icase4 = Convert.ToInt32(Console.ReadLine()); ;
                        for (int i = 0; i != 1;)
                        {
                            Console.WriteLine("Что вы хотите сделать с прямоугольником?");
                            Console.WriteLine("Задать координаты точек - 1");
                            Console.WriteLine("Задать цвет - 2");
                            Console.WriteLine("Задать прозрачность - 3");
                            Console.WriteLine("Вывести информацию - 4");
                            Console.WriteLine();
                            int icase41;
                            icase41 = Convert.ToInt32(Console.ReadLine()); ;
                            switch (icase41)
                            {
                                case 1:
                                    Console.WriteLine("x1: ");
                                    x1 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("y1: ");
                                    y1 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("x2: ");
                                    x2 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("y2: ");
                                    y2 = Convert.ToInt32(Console.ReadLine());
                                    Document.SetXYRectangle(x1, y1, x2, y2, icase4);
                                    break;

                                case 2:
                                    Console.WriteLine("R: ");
                                    RR = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("G: ");
                                    RG = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("B: ");
                                    RB = Convert.ToInt32(Console.ReadLine());
                                    Document.SetRectangleColor(RR, RG, RB, icase4);
                                    break;

                                case 3:
                                    Console.WriteLine("Прозрачность %: ");
                                    ROpacity = Convert.ToInt32(Console.ReadLine());
                                    Document.SetRectangleOpacity(ROpacity, icase4);
                                    break;

                                case 4:
                                    Document.PrintRectangleXY(icase4);
                                    Document.PrintRectangleArea(icase4);
                                    Document.PrintRectangleColor(icase4);
                                    Document.PrintRectanglePerimeter(icase4);
                                    Document.PrintRectangleOpacity(icase4);
                                    break;

                                case 0:
                                    i = 1;
                                    break;

                                default:
                                    Console.WriteLine("Вы выбрали неверный вариант");
                                    break;
                            }

                        }
                        break;

                    case 5:
                        int pr;
                        int icase5, icase51, icase53, circle1, circle2, rectangle1, rectangle2;
                        double angle;

                        Console.WriteLine("Что вы хотите сделать?");
                        for (int i = 0; i != 1;)
                        {
                            Console.WriteLine("Масштабирование - 1");
                            Console.WriteLine("Вращение - 2");
                            Console.WriteLine("Поменять местами - 3");
                            Console.WriteLine("Выход - 0");
                            icase5 = Convert.ToInt32(Console.ReadLine());
                            switch (icase5)
                            {
                                case 1:
                                    Console.WriteLine("Масштабирование всех фигур");
                                    Console.WriteLine("Увеличить на % - 1");
                                    Console.WriteLine("Уменьшить на % - 2");
                                    icase51 = Convert.ToInt32(Console.ReadLine());
                                    switch (icase51)
                                    {
                                        case 1:
                                            Console.WriteLine("На сколько процентов хотите увеличить?");
                                            pr = Convert.ToInt32(Console.ReadLine());
                                            Document.ScalePlus(pr);
                                            break;
                                        case 2:
                                            Console.WriteLine("На сколько процентов хотите уменьшить?");
                                            pr = Convert.ToInt32(Console.ReadLine());
                                            Document.ScaleMinus(pr);
                                            break;
                                        default:
                                            Console.WriteLine("Вы ввели неверный вариант");
                                            break;
                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("На какой угол вы хотите вращать весь документ?");
                                    angle = Convert.ToInt32(Console.ReadLine()); ;
                                    Document.Rotating(angle);
                                    break;

                                case 3:
                                    Console.WriteLine("Поменять местами круги - 1");
                                    Console.WriteLine("Поменять местами прямоугольники - 2");
                                    icase53 = Convert.ToInt32(Console.ReadLine());
                                    switch (icase53)
                                    {
                                        case 1:
                                            Console.WriteLine("Какие круги вы хотите поменять местами: ");
                                            Console.WriteLine("Место первого: ");
                                            circle1 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Место Второго: ");
                                            circle2 = Convert.ToInt32(Console.ReadLine());
                                            Document.MoveToCircles(circle1, circle2);
                                            break;
                                        case 2:
                                            Console.WriteLine("Какие прямоугольники вы хотите поменять местами: ");
                                            Console.WriteLine("Место первого: ");
                                            rectangle1 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Место Второго: ");
                                            rectangle2 = Convert.ToInt32(Console.ReadLine());
                                            Document.MoveToRectangles(rectangle1, rectangle2);
                                            break;
                                        default:
                                            Console.WriteLine("Вы ввели неверный вариант");
                                            break;
                                    }
                                    break;

                                case 0:
                                    i = 1;
                                    break;

                                default:
                                    Console.WriteLine("Вы ввели неверный вариант");
                                    break;
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("Вы выбрали неверный вариант");
                        break;
                    case 0:
                        return (Document);
                }

            }
        }

        static void Main(string[] args)
        {
            VectorDocument Document = new VectorDocument();
            print_menu(Document);
        }
    }
}