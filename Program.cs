using System;
using static programmingCs.VectorDocument;

namespace programmingCs
{
    class Program
    {
        static void Menu()
        {
            int ans;
            while (true)
            {
                Console.Write("\nВЕКТОРНЫЙ ГРАФИЧЕСКИЙ РЕДАКТОР\n\n" +
                              "Введите:\n" +
                              "'1' - Чтобы добавить фигуру\n" +
                              "'2' - Чтобы вывести список фигур\n" +
                              "'3' - Чтобы выбрать фигуру\n" +
                              "'4' - Чтобы работать с документом\n" +
                              "'5' - Чтобы сделать сериализацию\n" +
                              "'6' - Чтобы сделать десериализацию\n" +
                              "'7' - Чтобы очистить документ\n" +
                              "'0' - Чтобы выйти из программы\n" +
                              "ВВОД: ");
                ans = Convert.ToInt32(Console.ReadLine());
                if ((ans == 2 || ans == 3) && Size == 0)
                {
                    Console.Write("\nСписок пуст. Выберите другой вариант вариант\n");
                    continue;
                }
                switch (ans)
                {
                    case 1:
                        AddFigure();
                        break;
                    case 2:
                        PrintDocument();
                        break;
                    case 3:
                        SelectFigure();
                        break;
                    case 4:
                        EditDocument();
                        break;
                    case 5:
                        Serialize();
                        break;
                    case 6:
                        Serialize();
                        break;
                    case 7:
                        ClearDocument();
                        break;
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        static void Main()
        {
            Menu();
        }
    }
}