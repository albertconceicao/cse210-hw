using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
       Square square = new Square("blue", 4);
       Retangle retangle = new Retangle("red", 4, 16);
       Circle circle = new Circle("red", 8);

       shapes.Add(square);
       shapes.Add(retangle);
       shapes.Add(circle);

       foreach (Shape shape in shapes)
       {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"color: {color}, area: {area}");
       }
    }
}