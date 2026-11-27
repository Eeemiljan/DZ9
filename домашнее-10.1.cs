using System;

interface IFigure
{
    void MoveHorizontal(int distance);
    void MoveVertical(int distance);
    void ChangeColor(string newColor);
    bool IsVisible();
}

abstract class Figure : IFigure
{
    private string color;
    private bool visible;

    protected Figure(string color, bool visible)
    {
        this.color = color;
        this.visible = visible;
    }

    public abstract void MoveHorizontal(int distance);
    public abstract void MoveVertical(int distance);

    public void ChangeColor(string newColor)
    {
        color = newColor;
    }

    public bool IsVisible()
    {
        return visible;
    }

    public void SetVisibility(bool visible)
    {
        this.visible = visible;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Цвет: {color}");

        if (visible)
        {
            Console.WriteLine("Состояние: видимая");
        }
        else
        {
            Console.WriteLine("Состояние: невидимая");
        }
    }
}

class Point : Figure
{
    private int x;
    private int y;

    public Point(int x, int y, string color, bool visible)
        : base(color, visible)
    {
        this.x = x;
        this.y = y;
    }

    public override void MoveHorizontal(int distance)
    {
        x = x + distance;
    }

    public override void MoveVertical(int distance)
    {
        y = y + distance;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Координаты: ({x}, {y})");
    }
}

class Circle : Point
{
    private double radius;

    public Circle(int x, int y, double radius, string color, bool visible)
        : base(x, y, color, visible)
    {
        this.radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Радиус: {radius}");
        Console.WriteLine($"Площадь круга: {GetArea():F2}");
    }
}

class Rectangle : Point
{
    private double width;
    private double height;

    public Rectangle(int x, int y, double width, double height, string color, bool visible)
        : base(x, y, color, visible)
    {
        this.width = width;
        this.height = height;
    }

    public double GetArea()
    {
        return width * height;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Ширина: {width}");
        Console.WriteLine($"Высота: {height}");
        Console.WriteLine($"Площадь прямоугольника: {GetArea():F2}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Домашнее задание 10.1. Геометрические фигуры.");
        Console.WriteLine("Данные заданы в коде. Ввод не требуется.");
        Console.WriteLine();

        Point point = new Point(1, 2, "красный", true);
        Circle circle = new Circle(0, 0, 3, "синий", true);
        Rectangle rectangle = new Rectangle(4, 5, 6, 2, "зелёный", true);

        point.MoveHorizontal(2);

        IFigure movable = circle;
        movable.MoveHorizontal(2);
        movable.MoveVertical(-1);
        movable.ChangeColor("жёлтый");

        rectangle.MoveVertical(3);
        rectangle.SetVisibility(false);

        Console.WriteLine("Точка:");
        point.Print();

        Console.WriteLine();
        Console.WriteLine("Окружность:");
        circle.Print();

        Console.WriteLine();
        Console.WriteLine("Прямоугольник:");
        rectangle.Print();
        Console.WriteLine($"Виден по результату IsVisible(): {rectangle.IsVisible()}");
    }
}