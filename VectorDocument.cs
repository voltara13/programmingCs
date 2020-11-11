using System;
using System.Collections.Generic;

namespace programmingCs
{
    [Serializable]
    class VectorDocument
    {
        private double scale = 1, angle = 0, x = 0, y = 0;
        private List<VectorDocument> VectorDocuments = new List<VectorDocument>();
        private void AddCircle()
        {
            while (true)
            {
                Console.Write("Введите координаты центра, радиус и цвет в формате 'x y r RED GREEN BLUE ALPHA'\nВВОД: ");
                string temp = Console.ReadLine();
                string[] splitString = temp.Split(' ');
                if (splitString.Length == 7 &&
                    double.TryParse(splitString[0], out double x) &&
                    double.TryParse(splitString[1], out double y) &&
                    double.TryParse(splitString[2], out double r) &&
                    double.TryParse(splitString[3], out double red) &&
                    double.TryParse(splitString[4], out double green) &&
                    double.TryParse(splitString[5], out double blue) &&
                    double.TryParse(splitString[6], out double alpha))
                {
                    VectorDocuments.Add(new Circle(x, y, r, red, green, blue, alpha));
                    break;
                }
                Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
            }
        }
        private void AddRectangle()
        {
            while (true)
            {
                Console.Write("Введите координаты крайних точек диагонали,и цвет в формате 'x1 y1 x2 y2 RED GREEN BLUE ALPHA'\nВВОД: ");
                string temp = Console.ReadLine();
                string[] splitString = temp.Split(' ');
                if (splitString.Length == 8 &&
                    double.TryParse(splitString[0], out double x1) &&
                    double.TryParse(splitString[1], out double y1) &&
                    double.TryParse(splitString[2], out double x2) &&
                    double.TryParse(splitString[3], out double y2) &&
                    double.TryParse(splitString[5], out double red) &&
                    double.TryParse(splitString[4], out double green) &&
                    double.TryParse(splitString[5], out double blue) &&
                    double.TryParse(splitString[6], out double alpha))
                {
                    VectorDocuments.Add(new Rectangle(x1, y1, x2, y2, red, green, blue, alpha));
                    break;
                }
                Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
            }
        }
        protected virtual void PrintDescription() {}
        protected virtual void ScaleEdit() {}
        protected virtual void AngleEdit() {}
        protected virtual void CenterEdit() {}
        protected virtual void ChangeFigure() {}
        protected double Scale
        {
            get => scale;
            set
            {
                scale = value;
                foreach (var element in VectorDocuments)
                    element.ScaleEdit();
            }
        }
        protected double Angle
        {
            get => angle;
            set
            {
                angle = value;
                foreach (var element in VectorDocuments)
                    element.AngleEdit();
            }
        }
        protected double X
        {
            get => x;
            set
            {
                x = value;
                foreach (var element in VectorDocuments)
                    element.CenterEdit();
            }
        }
        protected double Y
        {
            get => y;
            set
            {
                y = value;
                foreach (var element in VectorDocuments)
                    element.CenterEdit();
            }
        }
        public void PrintDocument()
        {
            int i = 0;
            foreach (var element in VectorDocuments)
            {
                Console.Write($"{++i}. ");
                element.PrintDescription();
            }
        }
        public void AddFigure()
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
                        AddCircle();
                        return;
                    case 2:
                        AddRectangle();
                        return;
                    case 0:
                        return;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        public void SelectFigure()
        {
            while (true)
            {
                int ans1;
                Console.Write("\nВведите порядковый номер фигуры\nВВОД: ");
                ans1 = Convert.ToInt32(Console.ReadLine());
                try
                {
                    VectorDocuments[ans1 - 1].PrintDescription();
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
                                VectorDocuments[ans1 - 1].ChangeFigure();
                                return;
                            case 2:
                                VectorDocuments.Remove(VectorDocuments[ans1 - 1]);
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
        public void EditDocument()
        {
            while (true)
            {
                int ans;
                Console.Write("\nВведите:\n" +
                              "'1' - Чтобы изменить масштаб документа\n" +
                              "'2' - Чтобы изменить угол документа\n" +
                              "'3' - Чтобы изменить центр документа\n" +
                              "'4' - Чтобы вывести информацию о документе\n" +
                              "'0' - Чтобы выйти в меню\n" +
                              "ВВОД: ");
                ans = Convert.ToInt32(Console.ReadLine());
                switch (ans)
                {
                    case 1:
                        Console.Write("Новый масштаб документа: ");
                        scale = Convert.ToDouble(Console.ReadLine());
                        return;
                    case 2:
                        Console.Write("Новый угол документа: ");
                        angle = Convert.ToDouble(Console.ReadLine());
                        return;
                    case 3:
                        while (true)
                        {
                            Console.Write("Новые координаты центра в формате 'x y': ");
                            string temp = Console.ReadLine();
                            string[] splitString = temp.Split(' ');
                            if (splitString.Length == 2 &&
                                double.TryParse(splitString[0], out double _x) &&
                                double.TryParse(splitString[1], out double _y))
                            {
                                x = _x;
                                y = _y;
                                break;
                            }
                            Console.Write("\nНеверный ввод. Попробуйте ещё раз\n");
                        }
                        return;
                    case 4:
                        Console.Write("Сведения о документе\n" +
                                      $"Центр документа: ({x}, {y})\n" +
                                      $"Масштаб документа: x{scale}\n" +
                                      $"Угол поворота документа: {angle}°\n" +
                                      $"Количество фигур: {Size}\n");
                        return;
                    case 0:
                        return;
                    default:
                        Console.Write("\nВыбран неверный вариант. Попробуйте ещё раз\n");
                        break;
                }
            }
        }
        public void ClearDocument()
        {
            VectorDocuments.Clear();
            scale = 1;
            angle = 0;
            x = 0;
            y = 0;
        }
        public int Size => VectorDocuments.Count;
    }
}
