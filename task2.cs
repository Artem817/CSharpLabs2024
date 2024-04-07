using System;

class Point
{
    private int x;
    private int y;
    private string name;

    public Point(int x, int y, string name)
    {
        this.x = x;
        this.y = y;
        this.name = name;
    }

    public int X => x;
    public int Y => y;
    public string Name => name;
}

class Figure
{
    private Point[] points;

    public Figure(params Point[] points)
    {
        if (points.Length < 3 || points.Length > 5)
        {
            throw new ArgumentException("Фігура повинна мати від 3 до 5");
        }
        this.points = points;
    }

    public double LengthSide(Point A, Point B)
    {
        return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
    }

    public void PerimeterCalculator()
    {
        double permtr = 0;
        for (int i = 0; i < points.Length; i++)
        {
            permtr += LengthSide(points[i], points[(i + 1) % points.Length]);
        }
        Console.WriteLine($"Периметр {points.Length}-сторонього многокутник: {permtr}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point p1 = new Point(0, 0, "A");
        Point p2 = new Point(2, 6, "B");
        Point p3 = new Point(3, 0, "C");
        Point p4 = new Point(4, 4, "D");
        Point p5 = new Point(6, 2, "E");

        Figure figure = new Figure(p1, p2, p3, p4, p5);
        figure.PerimeterCalculator();
    }
}
