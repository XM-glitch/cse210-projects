using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("pink", 2);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle("purple", 3, 4);
        Console.WriteLine(rectangle.GetColor());
        Console.WriteLine(rectangle.GetArea());

        Circle circle = new Circle("green", 5);
        Console.WriteLine(circle.GetColor());
        Console.WriteLine(circle.GetArea());

        List<Shape> shapes = new() {square, rectangle, circle};
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"A {shape.GetColor()} shape with an area of {shape.GetArea()}.");
        }
    }
}