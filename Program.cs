using System;

namespace AreaOfShapes
{
    interface IShape
    {
        public double GetArea();
        public string GetName();
        public double GetPerimeter();

    }


    interface IPolygon : IShape
    {
        public int GetNumberOfSides();
    }
    public abstract class Quadilateral : IPolygon
    {
        public abstract double GetArea();
        public abstract string GetName();
        public abstract double GetPerimeter();
        int IPolygon.GetNumberOfSides() { return 4; }
    }
    public class Circle : IShape
    {
        private double radius;
        public Circle(double _radius)
        {
            this.radius = _radius;
        }
        public double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public string GetName()
        {
            return "Circle";
        }
        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

    }
    public class Rectangle : Quadilateral
    {
        private double length, breadth;
        public Rectangle(double _length, double _breadth)
        {
            this.length = _length;
            this.breadth = _breadth;
        }
        public override double GetArea()
        {
            return length * breadth;
        }
        public override string GetName()
        {
            return "Rectangle";
        }
        public override double GetPerimeter()
        {
            return 2 * (length + breadth);
        }
    }
    public class Square : Quadilateral
    {
        private double length;
        public Square(double _length)
        {
            this.length = _length;
        }
        public override double GetArea()
        {
            return length * length;
        }

        public override string GetName()
        {
            return "Square";
        }
        public override double GetPerimeter()
        {
            return 4 * length;
        }
    }
    public abstract class BaseTriangle : IPolygon
    {      
        public abstract double GetArea();
        
        public abstract string GetName();

        public abstract double GetPerimeter();
        public int GetNumberOfSides()
        {
            return 3;
        }

    }
    public class TwoDimensionTriangle: BaseTriangle
    {
        private double length, height;
        public TwoDimensionTriangle(double length, double height)
        {
            this.length = length;
            this.height = height;

        }
        public override string GetName()
        {
            return "Two Dimensional Triangle";
        }
        public override double GetArea()
        {
            return 0.5D * length * height;
        }
        public override double GetPerimeter()
        {
            throw new Exception("Perimeter can't be found!!!");
        }
    }
    public class ThreeDimensionTriangle: BaseTriangle
    {
        private double a, b, c;
        public ThreeDimensionTriangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override string GetName()
        {
            return "3 Dimension Triangle";
        }
        public override double GetPerimeter()
        {
            return a + b + c;
        }
        public override double GetArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
    public class EquilateralTriangle : ThreeDimensionTriangle
    {
        
        public EquilateralTriangle(double length): base(length,length,length) //x
        {
            
        }
        public override string GetName()
        {
            return "Equilateral triangle";
        }
        

    }



    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapesArray = new IShape[6];

            Circle newCircle = new Circle(5);
            shapesArray[0] = newCircle;

            Rectangle newRectangle = new Rectangle(3, 5);
            shapesArray[1] = newRectangle;

            Square newSquare = new Square(6);
            shapesArray[2] = newSquare;

            TwoDimensionTriangle newTriangle = new TwoDimensionTriangle(5,4);
            shapesArray[3] = newTriangle;

            EquilateralTriangle newEquilateralTriangle = new EquilateralTriangle(5);
            shapesArray[4] = newEquilateralTriangle;

            ThreeDimensionTriangle threeDimensionTriangle = new ThreeDimensionTriangle(3, 4, 5);
            shapesArray[5] = threeDimensionTriangle;

            for (int i = 0; i < shapesArray.Length; i++)
            {
                Console.Write(String.Format("Name of Shape: {0}", shapesArray[i].GetName()));
                if (shapesArray[i] is Quadilateral)
                {
                    Console.Write(" | Quad");
                }
                try
                {
                    Console.WriteLine("\nArea: {0}", shapesArray[i].GetArea());
                    Console.WriteLine("Perimeter: {0}", shapesArray[i].GetPerimeter());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (shapesArray[i] is IPolygon)
                {
                    IPolygon polygon = (IPolygon)shapesArray[i];
                    Console.WriteLine(string.Format("Number of sides for Polygon: {0}", polygon.GetNumberOfSides()));
                }
                Console.WriteLine("");

            }
            Console.ReadLine();
        }
    }
}



