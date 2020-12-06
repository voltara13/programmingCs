/*
EX1 - необобщенная коллекция ArrayList
EX2 - обобщенная коллекция
EX3 - обобщенная коллекция пользовательского типа данных
EX4 - наблюдаемая коллекция пользовательского типа данных
*/
#define EX4

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace programmingCs
{
    class Program
    {
        static void Main()
        {
#if EX1
            var myAl = new ArrayList();
            var rand = new Random();
            for (int i = 0; i < 5; i++)
                myAl.Add(rand.Next(1, 10));
            myAl.Add("Hello");
            myAl.Remove("Hello");
            myAl.Add("Hello");
            Console.WriteLine(myAl.Count);
            foreach (var elm in myAl)
                Console.Write($"{elm} ");
            Console.Write($"\n{myAl.IndexOf("Hello")}");
#endif
#if EX2
            int N;
            var myLinkedList = new LinkedList<bool>();
            var rand = new Random();
            for (int i = 0; i < 5; i++)
                myLinkedList.AddLast(rand.Next(0, 2) == 1);
            Console.WriteLine("\nLinkedList\n");
            foreach (var elm in myLinkedList)
                Console.Write($"{elm} ");
            Console.WriteLine();

            Console.Write("\nВведите N для удаления N последних элементов: ");
            while (true)
            {
                N = Convert.ToInt32(Console.ReadLine());
                if (N > myLinkedList.Count)
                    Console.Write("Введено неверное N, попробуйте ещё раз: ");
                else break;
            }
            for (int i = 0; i < N; i++)
                myLinkedList.RemoveLast();
            Console.WriteLine("\nLinkedList после удаления\n");
            foreach (var elm in myLinkedList)
                Console.Write($"{elm} ");
            Console.WriteLine();

            myLinkedList.AddFirst(true); //Добавление в начало
            myLinkedList.AddLast(true); //Добавление в конец
            var current = myLinkedList.First;
            myLinkedList.AddBefore(current, true); //Добавление до указываемого элемента
            myLinkedList.AddAfter(current, true); //Добавление после указываемого элемента
            Console.WriteLine("\nLinkedList после добавления\n");
            foreach (var elm in myLinkedList)
                Console.Write($"{elm} ");
            Console.WriteLine();

            var myDictionaryList = new Dictionary<int, bool>();
            current = myLinkedList.First;
            for (int i = 0; i < myLinkedList.Count; i++, current = current.Next)
                myDictionaryList.Add(i, current.Value);
            Console.WriteLine("\nDictionary\n");
            foreach (var elm in myDictionaryList)
                Console.WriteLine($"{elm.Key}: {elm.Value}");
            Console.WriteLine();

            Console.Write("\nВведите индекс заданного значения: ");
            while (true)
            {
                N = Convert.ToInt16(Console.ReadLine());
                try
                {
                    Console.WriteLine($"Значение под индексом {N}: myDictionaryList[N]}");
                    break;
                }
                catch (Exception)
                {
                    Console.Write("Введен неверный индекс, попробуйте ещё раз: ");
                }
            }
#endif
#if EX3
            int n;
            var myLinkedList = new LinkedList<Circle>();
            for (int i = 0; i < 5; i++)
                myLinkedList.AddLast(new Circle());
            Console.WriteLine("LinkedList");
            foreach (var elm in myLinkedList)
                Console.WriteLine($"{elm}");
            Console.WriteLine();

            Console.Write("\nВведите N для удаления N последних элементов: ");
            while (true)
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n > myLinkedList.Count)
                    Console.Write("Введено неверное N, попробуйте ещё раз: ");
                else break;
            }
            for (int i = 0; i < n; i++)
                myLinkedList.RemoveLast();
            Console.WriteLine("\nLinkedList после удаления");
            foreach (var elm in myLinkedList)
                Console.WriteLine($"{elm}");
            Console.WriteLine();

            myLinkedList.AddFirst(new Circle()); //Добавление в начало
            myLinkedList.AddLast(new Circle()); //Добавление в конец
            var current = myLinkedList.First;
            myLinkedList.AddBefore(current, new Circle()); //Добавление до указываемого элемента
            myLinkedList.AddAfter(current, new Circle()); //Добавление после указываемого элемента

            Console.WriteLine("\n\nLinkedList после добавления");
            foreach (var elm in myLinkedList)
                Console.WriteLine($"{elm}");
            Console.WriteLine();

            var myDictionaryList = new Dictionary<int, Circle>();
            current = myLinkedList.First;
            for (int i = 0; i < myLinkedList.Count; i++, current = current.Next)
                myDictionaryList.Add(i, current.Value);
            Console.WriteLine("\nDictionary\n");
            foreach (var elm in myDictionaryList)
                Console.WriteLine($"{elm.Key}: {elm.Value}\n");
            Console.WriteLine();

            Console.Write("Введите индекс заданного значения: ");
            while (true)
            {
                n = Convert.ToInt16(Console.ReadLine());
                try
                {
                    Console.WriteLine($"\nЗначение под индексом {n}: {myDictionaryList[n]}");
                    break;
                }
                catch (Exception)
                {
                    Console.Write("Введен неверный индекс, попробуйте ещё раз: ");
                }
            }

            List<Circle> myDictionaryValue = new List<Circle>();
            for (int i = 0; i < myDictionaryList.Count; i++)
                myDictionaryValue.Add((Circle)myDictionaryList[i].Clone()); //Использование ICloneable

            myDictionaryValue.Sort();
            var mySortedDictionary1 = new Dictionary<int, Circle>(); //Сортировка по возрастанию через IComparable
            for (int i = 0; i < myDictionaryList.Count; i++)
                mySortedDictionary1.Add(i, (Circle)myDictionaryValue[i].Clone()); //Использование ICloneable
            Console.WriteLine("\n\nОтсортированный Dictionary через IComparable\n");
            foreach (var elm in mySortedDictionary1)
                Console.WriteLine($"{elm.Key}: {elm.Value}\n");

            myDictionaryValue.Sort(Circle.SortAreaAscending()); //Сортировка по возрастанию через IComparer
            var mySortedDictionary2 = new Dictionary<int, Circle>();
            for (int i = 0; i < myDictionaryList.Count; i++)
                mySortedDictionary2.Add(i, (Circle)myDictionaryValue[i].Clone()); //Использование ICloneable
            Console.WriteLine("\n\nОтсортированный Dictionary по возрастанию через IComparer\n");
            foreach (var elm in mySortedDictionary2)
                Console.WriteLine($"{elm.Key}: {elm.Value}\n");

            myDictionaryValue.Sort(Circle.SortAreaDescending()); //Сортировка по убыванию через IComparer
            var mySortedDictionary3 = new Dictionary<int, Circle>();
            for (int i = 0; i < myDictionaryList.Count; i++)
                mySortedDictionary3.Add(i, (Circle)myDictionaryValue[i].Clone()); //Использование ICloneable
            Console.WriteLine("\n\nОтсортированный Dictionary по убыванию через IComparer\n");
            foreach (var elm in mySortedDictionary3)
                Console.WriteLine($"{elm.Key}: {elm.Value}\n");
#endif
#if EX4
            ObservableCollection<Circle> myObsCollection = new ObservableCollection<Circle>();
            myObsCollection.CollectionChanged += Circle.Circle_CollectionChanged;
            for (int i = 0; i < 5; i++)
                myObsCollection.Add(new Circle());
            Console.WriteLine("\n\nНаблюдаемая коллекция после добавления элементов");
            foreach (var elm in myObsCollection)
                Console.WriteLine($"{elm}");
            myObsCollection.RemoveAt(0);
            Console.WriteLine("\n\nНаблюдаемая коллекция после удаления первого элемента");
            foreach (var elm in myObsCollection)
                Console.WriteLine($"{elm}");

#endif
        }
    }

}