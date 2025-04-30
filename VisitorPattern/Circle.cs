public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    // Calculate the area of the circle
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // Calculate the circumference of the circle
    public double CalculateCircumference()
    {
        return 2 * Math.PI * Radius;
    }

    // Check if a point is inside the circle
    public bool IsPointInside(double x, double y)
    {
        return (x * x + y * y) <= (Radius * Radius);
    }

    // Implement the Accept method for the visitor pattern
    public void Accept(ShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}
