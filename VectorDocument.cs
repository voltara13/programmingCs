using System.Collections.Generic;

namespace programmingCs
{
    class VectorDocument
    {
        public const int NUM = 3;
        public List<Circle> ArrayCircles = new List<Circle>();
        public List<Rectangle> ArrayRectangles = new List<Rectangle>();
        public void AddCircle(int i)
        {
            ArrayCircles.Insert(i - 1, new Circle());
        }
        public void DeleteCircle(int i)
        {
            ArrayCircles.RemoveAt(i - 1);
        }
        public void AddRectangle(int i)
        {
            ArrayRectangles.Insert(i - 1, new Rectangle());
        }
        public void DeleteRectangle(int i)
        {

            ArrayRectangles.RemoveAt(i - 1);
        }
        public void SetCircleOpacity(int opacity, int i)
        {
            ArrayCircles[i - 1].SetOpacity(opacity);
        }
        public void PrintCircleOpacity(int i)
        {
            ArrayCircles[i - 1].PrintOpacity();
        }
        public void SetRectangleOpacity(int opacity, int i)
        {
            ArrayRectangles[i - 1].SetOpacity(opacity);
        }
        public void PrintRectangleOpacity(int i)
        {
            ArrayRectangles[i - 1].PrintOpacity();
        }
        public void SetCircleColor(int R, int G, int B, int i)
        {
            ArrayCircles[i - 1].SetColor(R, G, B);
        }
        public void SetRectangleColor(int R, int G, int B, int i)
        {
            ArrayRectangles[i - 1].SetColor(R, G, B);
        }
        public void PrintCircleColor(int i)
        {
            ArrayCircles[i - 1].PrintColor();
        }
        public void PrintRectangleColor(int i)
        {
            ArrayRectangles[i - 1].PrintColor();
        }
        public void PrintCircleArea(int i)
        {
            ArrayCircles[i - 1].PrintArea();
        }
        public void PrintRectangleArea(int i)
        {
            ArrayRectangles[i - 1].PrintArea();
        }
        public void PrintCirclePerimeter(int i)
        {
            ArrayCircles[i - 1].PrintPerimeter();
        }
        public void PrintRectanglePerimeter(int i)
        {
            ArrayRectangles[i - 1].PrintPerimeter();
        }
        public void PrintCircleXYR(int i)
        {
            ArrayCircles[i - 1].PrintXYR();
        }
        public void PrintRectangleXY(int i)
        {
            ArrayRectangles[i - 1].PrintXY();
        }
        public void SetXYRCircle(double x, double y, double r, int i)
        {
            ArrayCircles[i - 1].Setxyr(x, y, r);
            ArrayCircles[i - 1].Area();
            ArrayCircles[i - 1].Perimeter();
        }
        public void SetXYRectangle(double x11, double y11, int x22, double y22, int i)
        {
            ArrayRectangles[i - 1].Setxy(x11, y11, x22, y22);
            ArrayRectangles[i - 1].Area();
            ArrayRectangles[i - 1].Perimeter();
        }
        public void MoveToCircles(int i, int j)
        {
            (ArrayCircles[i - 1], ArrayCircles[j]) = (ArrayCircles[j], ArrayCircles[i - 1]);
        }
        public void MoveToRectangles(int i, int j)
        {
            (ArrayRectangles[i - 1], ArrayRectangles[j]) = (ArrayRectangles[j], ArrayRectangles[i - 1]);
        }
        public void ScalePlus(double procent)
        {
            for (int i = 0; i < NUM; i++)
            {
                ArrayCircles[i].MathtabPlus(procent);
                ArrayRectangles[i].ScalePlus(procent);
            }
        }
        public void ScaleMinus(double procent)
        {
            for (int i = 0; i < NUM; i++)
            {
                ArrayCircles[i].MathtabMinus(procent);
                ArrayRectangles[i].ScaleMinus(procent);
            }
        }
        public void Rotating(double angle)
        {
            for (int i = 0; i < NUM; i++)
            {
                ArrayCircles[i].Rotating(angle);
                ArrayRectangles[i].Rotating(angle);
            }
        }
    }
}