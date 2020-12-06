using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace programmingCs
{
    [Serializable]
    class VectorDocument
    {
        private static double _scale = 1, _angle = 0, _x = 0, _y = 0, _dx, _dy;
        private static List<VectorDocument> _vectorDocuments = new List<VectorDocument>();
        protected virtual void ScaleEdit() {} //Виртуальная функция изменения масштаба фигуры
        protected virtual void AngleEdit() {} //Виртуальная функция изменения угла фигуры
        protected virtual void CenterEdit() {} //Виртуальная функция изменения центра фигуры
        protected virtual void ChangeFigure() {} //Виртуальная функция изменения свойств фигуры
        protected static double Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                foreach (var element in _vectorDocuments)
                    element.ScaleEdit();
            }
        }
        protected static double Angle
        {
            get => _angle;
            set
            {
                _angle = value;
                foreach (var element in _vectorDocuments)
                    element.AngleEdit();
            }
        }
        public static double Dx => _dx;
        public static double Dy => _dy;
        public static int Size => _vectorDocuments.Count;
        public static void PrintDocument()
        {
            int i = 0;
            foreach (var element in _vectorDocuments)
                Console.Write($"\n{++i}. {element}");
        }
        public static void AddFigure()
        {
            while (true)
            {
                int ans;
                Console.Write("\nВыберите тип фигуры:\n" +
                              "'1' - Круг\n" +
                              "'2' - Прямоугольник\n" +
                              "'0' - Выйти в меню\n" +
                              "ВВОД: ");
                ans = Convert.ToInt32(Console.ReadLine());
                switch (ans)
                {
                    case 1:
                        _vectorDocuments.Add(new Circle());
                        return;
                    case 2:
                        _vectorDocuments.Add(new Rectangle());
                        return;
                    case 0:
                        return;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        public static void SelectFigure()
        {
            while (true)
            {
                int ans1;
                Console.Write("\nВведите порядковый номер фигуры\nВВОД: ");
                ans1 = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Console.WriteLine(_vectorDocuments[ans1 - 1]);
                    Console.Write("\nВведите:\n" +
                                  "'1' - Чтобы изменить параметры фигуры\n" +
                                  "'2' - Чтобы удалить фигуру\n" +
                                  "'0' - Чтобы выйти в меню\n" +
                                  "ВВОД: ");
                    while (true)
                    {
                        int ans2;
                        ans2 = Convert.ToInt32(Console.ReadLine());
                        switch (ans2)
                        {
                            case 1:
                                _vectorDocuments[ans1 - 1].ChangeFigure();
                                return;
                            case 2:
                                _vectorDocuments.Remove(_vectorDocuments[ans1 - 1]);
                                return;
                            case 0:
                                return;
                            default:
                                Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                                break;
                        }
                        break;
                    }
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write("\nВведен неверный порядковый номер. Попробуйте ещё раз\n");
                }
            }
        }
        public static void EditDocument()
        {
            while (true)
            {
                Console.Write("\nВведите:\n" +
                              "'1' - Чтобы изменить масштаб документа\n" +
                              "'2' - Чтобы изменить угол документа\n" +
                              "'3' - Чтобы изменить центр документа\n" +
                              "'4' - Чтобы вывести информацию о документе\n" +
                              "'0' - Чтобы выйти в меню\n" +
                              "ВВОД: ");
                var ans = Convert.ToInt16(Console.ReadLine());
                switch (ans)
                {
                    case 1:
                        Console.Write("Новый масштаб документа: ");
                        Scale = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Новый угол документа: ");
                        Angle = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 3:
                        while (true)
                        {
                            Console.Write("Новые координаты центра в формате 'x y': ");
                            string temp = Console.ReadLine();
                            string[] splitString = temp.Split(' ');
                            try
                            {
                                double x = Convert.ToDouble(splitString[0]);
                                double y = Convert.ToDouble(splitString[1]);
                                _dx = x - VectorDocument._x;
                                _dy = y - VectorDocument._y;
                                VectorDocument._x = x;
                                VectorDocument._y = y;
                                foreach (var element in _vectorDocuments)
                                    element.CenterEdit();
                                break;
                            }
                            catch (Exception)
                            {
                                Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
                            }
                        }
                        break;
                    case 4:
                        Console.Write("Сведения о документе\n" +
                                      $"Центр документа: ({_x}, {_y})\n" +
                                      $"Масштаб документа: x{_scale}\n" +
                                      $"Угол поворота документа: {_angle}°\n" +
                                      $"Количество фигур: {Size}\n");
                        break;
                    case 0:
                        break;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        public static void Serialize()
        {
            FieldInfo[] fields = typeof(VectorDocument).GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            object[,] a = new object[fields.Length, 2];
            int i = 0;
            foreach (FieldInfo field in fields)
            {
                a[i, 0] = field.Name;
                a[i, 1] = field.GetValue(null);
                i++;
            };
            Stream f = File.Open("serialize.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(f, a);
            f.Close();
        }
        public static void Deserialize()
        {
            FieldInfo[] fields = typeof(VectorDocument).GetFields(BindingFlags.Static | BindingFlags.NonPublic);
            object[,] a;
            Stream f = File.Open("serialize.dat", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            a = formatter.Deserialize(f) as object[,];
            f.Close();
            int i = 0;
            foreach (FieldInfo field in fields)
            {
                if (field.Name == (a[i, 0] as string))
                    field.SetValue(null, a[i, 1]);
                i++;
            }
        }
        public static void ClearDocument()
        {
            _vectorDocuments.Clear();
            _scale = 1;
            _angle = 0;
            _x = 0;
            _y = 0;
        }
    }
}
