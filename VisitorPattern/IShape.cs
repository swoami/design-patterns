public interface IShape
{
    void Accept(ShapeVisitor visitor);
}
