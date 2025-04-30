using DesignPatterns.Graphic;
using FluentAssertions;
using Xunit;

namespace Graphic;

public class GraphicObjectTests
{
    [Fact]
    public void GraphicObject_Initialization()
    {
        // Arrange
        var graphicObject = new GraphicObject { Color = "Red" };

        // Act & Assert
        graphicObject.Name.Should().Be("Grupa");
        graphicObject.Color.Should().Be("Red");
        graphicObject.Children.Should().BeEmpty();
    }

    [Fact]
    public void GraphicObject_Draw()
    {
        // Arrange
        var parent = new GraphicObject { Color = "Red" };
        var child = new GraphicObject { Color = "Blue" };
        parent.Children.Add(child);

        // Act
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            parent.Draw("Green");

            // Assert
            var expectedOutput = "Green Grupa\r\nGreen Grupa\r\n";
            sw.ToString().Should().Be(expectedOutput);
        }
    }
}
