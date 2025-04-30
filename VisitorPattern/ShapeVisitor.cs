public class ShapeVisitor
{
    public void Visit(Circle circle)
    {
        Console.WriteLine($"Visiting Circle with Radius: {circle.Radius}");
    }

    public void Visit(Square square)
    {
        Console.WriteLine($"Visiting Square with Side Length: {square.SideLength}");
    }
}