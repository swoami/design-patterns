public class Square : IShape
{    
    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public void Accept(ShapeVisitor visitor)
    {
        visitor.Visit(this);
    }

    public double CalculateArea()
    {
        return SideLength * SideLength;
    }
}
