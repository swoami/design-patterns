using DesignPatterns.Graphic;
using System.Xml.Linq;

bool dotneExampleMode = false;

if (dotneExampleMode)
{
    var document = new XDocument(new XElement("Parent", new XElement("Child", new XElement("GrandChild", new XAttribute("Age", "5")))));
    var elements = document.Elements();

    foreach (var element in elements)
    {
        Console.WriteLine(element);
    }
        
    var documentChildren = document.Descendants();

    Console.WriteLine("______________________________");
    int level = 1;

    foreach (var documentChild in documentChildren)
    {
        // helper methods to go through elements in tree
        // var parent = documentChild.Parent; // direct parent
        // documentChild.Ancestors(); // all nested parents        
        // documentChild.Elements(); // only direct childs
        // documentChild.Descendants(); // all nested

        Console.WriteLine("Level {0}", level);
        Console.WriteLine(documentChild); // uses ToString() instead of draw
        level++;
        Console.WriteLine();
    }
    Console.WriteLine("______________________________");
    Console.ReadLine();
}
else
{
    var drawing = new Group();
    drawing.Children.Add(new Square { Color = "Czerwony" });
    drawing.Children.Add(new Circle { Color = "Żółty" });
    var group = new Group();
    group.Children.Add(new Layer { Color = "Czerwony" });
    group.Children.Add(new Triangle { Color = "Żółty" });
    drawing.Children.Add(group);

    Console.WriteLine(drawing.Draw());
}
