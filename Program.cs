using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace programmingCs
{
    class Program
    {
        static void Menu(VectorDocument Object)
        {
            int ans;
            BinaryFormatter formatter = new BinaryFormatter();
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
                if ((ans == 2 || ans == 3 || ans == 5 || ans == 7) && Object.Size == 0)
                {
                    Console.Write("\nСписок пуст. Выберите другой вариант вариант\n");
                    continue;
                }
                switch (ans)
                {
                    case 1:
                        Object.AddFigure();
                        break;
                    case 2:
                        Object.PrintDocument();
                        break;
                    case 3:
                        Object.SelectFigure();
                        break;
                    case 4:
                        Object.EditDocument();
                        break;
                    case 5:
                        using (FileStream fs = new FileStream("serialize.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, Object);
                        }
                        break;
                    case 6:
                        using (FileStream fs = new FileStream("serialize.dat", FileMode.OpenOrCreate))
                        {
                            Object = (VectorDocument)formatter.Deserialize(fs);
                        }
                        break;
                    case 7:
                        Object.ClearDocument();
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
            VectorDocument Object = new VectorDocument();
            Menu(Object);
        }
    }
}