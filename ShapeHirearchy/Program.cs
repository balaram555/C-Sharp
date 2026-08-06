using System;
 abstract class shape
{
    public string Name { get; set; }
    public shape(string name)
    {
        Name = name;
    }
    public abstract double claculateArea();
    public virtual void display()
    {
        Console.WriteLine($"Shape: {Name}");
    }
}


class circle : shape
{
    public double Radius { get; set; }
    public circle(string name, double radius) : base(name)
    {
        Radius = radius;
    }
    public override double claculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    public override void display()
    {
        base.display();
        Console.WriteLine($"Radius: {Radius}, Area: {claculateArea()}");
    }
}


class rectangle : shape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public rectangle(string name, double length, double width) : base(name)
    {
        Length = length;
        Width = width;
    }
    public override double claculateArea()
    {
        return Length * Width;
    }
    public override void display()
    {
        base.display();
        Console.WriteLine($"Length: {Length}, Width: {Width}, Area: {claculateArea()}");
    }
}

class Triangle : shape
{
    public double Base { get; set; }
    public double Height { get; set; }
    public Triangle(string name, double Base, double Height) : base(name)
    {
        Base = Base;
        Height = Height;
    }
    public override double claculateArea()
    {
        return 0.5 * Base * Height;
    }
    public override void display()
    {
        base.display();
        Console.WriteLine($"Base: {Base}, Height: {Height}, Area: {claculateArea()}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        shape circle = new circle("Circle", 5);
        shape rectangle = new rectangle("Rectangle", 4, 6);
        shape triangle = new Triangle("Triangle", 3, 4);

        circle.display();
        rectangle.display();
        triangle.display();
    }
}