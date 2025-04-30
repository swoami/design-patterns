public static class Program
{
    public static void Main(string[] args)
    {
        var visitor = new ShapeVisitor();

        var shapes = new List<IShape>
        {
            new Circle(10),
            new Square(20)
        };

        // double dispatch
        shapes.ForEach(shape => shape.Accept(visitor));
    }
}