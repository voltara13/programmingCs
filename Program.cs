﻿using System;
using System.Collections;
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
                        AddFigure(); //Функция добавления фигуры
                        break;
                    case 2:
                        PrintDocument(); //Функция вывода всего документа
                        break;
                    case 3:
                        SelectFigure(); //Функция выбора отдельной фигуры
                        break;
                    case 4:
                        EditDocument(); //Функция изменения свойств документа
                        break;
                    case 5:
                        Serialize(); //Функция сериализации
                        break;
                    case 6:
                        Deserialize(); //Функция десериализации
                        break;
                    case 7:
                        ClearDocument(); //Функция очистки документа
                        break;
                    case 0:
                        System.Environment.Exit(0); //Функция выхода из программы
                        break;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        static void Main()
        {
            //Menu();
            ArrayList myAL = new ArrayList();
            var rand = new Random();
            for (int i = 0; i < 5; i++)
                myAL.Add(rand.Next(1, 10));
            myAL.Add("Hello");
            myAL.Remove("Hello");
            Console.WriteLine(myAL.Count);
            foreach (var elm in myAL)
                Console.Write($"{elm} ");
            myAL.Fin

        }
    }
}