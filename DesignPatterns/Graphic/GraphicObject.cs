using System.Text;

namespace DesignPatterns.Graphic;

/// <summary>
/// Represents a graphic object that can have children and be drawn with a specified color.
/// </summary>
abstract class GraphicObject
{        
    private Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>();

    /// <summary>
    /// Gets the name of the graphic object.
    /// </summary>
    public virtual string Name { get; }

    /// <summary>
    /// Gets or sets the color of the graphic object.
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of child graphic objects.
    /// </summary>
    public List<GraphicObject> Children => _children.Value;

    /// <summary>
    /// Draws the graphic object and its children with the specified color.
    /// </summary>
    /// <param name="color">The color to draw the graphic object with.</param>
    public void Draw(string color)
    {
        Console.WriteLine($"{color} {Name}");
        foreach (var child in Children)
        {
            child.Draw(color);
        }
    }

    /// <summary>
    /// Returns a string representation of the graphic object and its children.
    /// </summary>
    /// <returns></returns>
    public string Draw()
    {
        var sb = new StringBuilder();
        BuildString(sb, 0);
        return sb.ToString();
    }

    /// <summary>
    /// Recursively builds a string representation of the graphic object and its children.
    /// </summary>
    /// <param name="sb"></param>
    /// <param name="depth"></param>
    private void BuildString(StringBuilder sb, int depth)
    {
        sb
          .Append(new string('*', depth))
          .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
          .AppendLine(Name);

        foreach (var child in Children)
        {
            child.BuildString(sb, depth + 1);
        }
    }
}
