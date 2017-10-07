# Dgml.Net

This library was forked from Nayan Shash's Utils.Net, taking only the DGML implementations. It was ported to __.NET Standard 1.4.__

## Types for creating DGML graphs

__DirectedGraph*__ classes
+ [x] Generated from original dgml.xsd
+ [x] Full flexibility

__Graph, Node, Link, Style__
 + [x] Older manually maintained object model
 + [x] Simpler to use but restrictive


## Example


```csharp
// Object representing any custom graph node
public class CustomNode
{
    public string Name {get; set; }

    public ICollection<CustomNode> InputNodes {get; set; }
}
```

```csharp
IList<CustomNode> nodes = new List<CustomNode>
{
    new CustomNode { Name = "First", },
    new CustomNode { Name = "Second" },
    new CustomNode { Name = "Third" },
};

nodes[0].InputNodes = new[] { nodes[1], nodes[2] };


// Define node creator and link resolver
DirectedGraphNodeCreator<CustomNode> creator = node => new DirectedGraphNode { Id = node.Name };
NodeLinksResolver<CustomNode> resolver = node => node.InputNodes;

// Create and save graph as .dgml
nodes
    .ToGraph(creator, resolver, incomingLinks: true)
    .Save(@"C:\graph.dgml");
```

```xml
<?xml version="1.0" encoding="utf-8"?>
<DirectedGraph xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://schemas.microsoft.com/vs/2009/dgml">
    <Nodes>
    <Node Id="First" />
    <Node Id="Second" />
    <Node Id="Third" />
    </Nodes>
    <Links>
    <Link Source="Second" Target="First" />
    <Link Source="Third" Target="First" />
    </Links>
</DirectedGraph>
```
