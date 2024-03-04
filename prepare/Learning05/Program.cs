using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning05 World!");

        Square sq = new Square("blue", 2);
        //Console.WriteLine(sq.GetColor());
        //Console.WriteLine(sq.GetArea());

        Rectangle rect = new Rectangle("yellow", 3, 4);
        //Console.WriteLine(rect.GetColor());
        //Console.WriteLine(rect.GetArea());

        Circle ccl = new Circle("red", 4);
        //Console.WriteLine(ccl.GetColor());
        //Console.WriteLine(ccl.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(sq);
        shapes.Add(rect);
        shapes.Add(ccl);
        foreach (Shape shape in shapes)
        {
            Console.WriteLine();
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());

        }
    }
}