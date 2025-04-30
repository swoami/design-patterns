using Xunit;
using DesignPatterns.Graphic;
using FluentAssertions;

namespace DesignPatterns.Tests.Graphic
{
    public class GroupTests
    {
        [Fact]
        public void Group_Name_ShouldReturnGrupa()
        {
            // Arrange
            var group = new Group();

            // Act
            var name = group.Name;

            // Assert
            name.Should().Be("Grupa");
        }

        [Fact]
        public void Group_ShouldInheritFromGraphicObject()
        {
            // Arrange
            var group = new Group();

            // Act & Assert
            group.Should().BeAssignableTo<GraphicObject>();
        }

        [Fact]
        public void Group_ShouldHaveChildrenProperty()
        {
            // Arrange
            var group = new Group();

            // Act
            var children = group.Children;

            // Assert
            children.Should().NotBeNull();
        }

        [Fact]
        public void Group_ShouldHaveColorProperty()
        {
            // Arrange
            var group = new Group();

            // Act
            group.Color = "Red";
            var color = group.Color;

            // Assert
            color.Should().Be("Red");
        }

        [Fact]
        public void Group_Draw_ShouldDrawWithSpecifiedColor()
        {
            // Arrange
            var group = new Group();
            var color = "Blue";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                group.Draw(color);

                // Assert
                var expectedOutput = "Blue Grupa\r\n";
                sw.ToString().Should().Be(expectedOutput);
            }
        }
    }
}
