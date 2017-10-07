﻿using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dgml.Net;

namespace Dgml.Net.Test
{
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void TestSave_EmptyDgml()
        {
            Graph graph = new Graph();
            string actualDgml = graph.ToDgml();

            MatchDgml(EmptyDgml, actualDgml);
        }

        [TestMethod]
        public void TestSave_ValidDgml()
        {
            Node first = new Node("1", "first");
            Node second = new Node("2", "second");
            Link link = new Link("1", "2", "connects");

            Graph graph = new Graph()
            {
                Nodes = new[] { first, second },
                Links = new[] { link },
            };

            string actualDgml = graph.ToDgml();

            MatchDgml(ValidDgml, actualDgml);
        }

        [TestMethod]
        public void TestSave_StyledDgml()
        {
            Node first = new Node("1", "first", "category");
            Node second = new Node("2", "second");
            Link link = new Link("1", "2", "connects");
            Style style = new Style("category", "#FF000000");

            Graph graph = new Graph()
            {
                Nodes = new[] { first, second },
                Links = new[] { link },
                Styles = new[] { style },
            };

            string actualDgml = graph.ToDgml();

            MatchDgml(StyledDgml, actualDgml);
        }

        [TestMethod]
        public void TestSave_CategoriesDgml()
        {
            Node first = new Node("1", "first", "number");
            Node second = new Node("2", "second");
            Link link = new Link("1", "2", "connects", "link");
            Category[] categories =
            {
                new Category("number", "Green"),
                new Category("link", stroke: "Black", basedOn: "number"),
            };

            Graph graph = new Graph()
            {
                Nodes = new[] { first, second },
                Links = new[] { link },
                Categories = categories,
            };

            string actualDgml = graph.ToDgml();

            MatchDgml(CategoriesDgml, actualDgml);
        }

        private void MatchDgml(string expected, string actual)
        {
            Assert.AreEqual(
                Regex.Replace(expected, @"\r|\n", ""),
                Regex.Replace(actual, @"\r|\n", "")
            );
        }

        private const string EmptyDgml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<DirectedGraph xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://schemas.microsoft.com/vs/2009/dgml"" />";

        private const string ValidDgml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<DirectedGraph xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://schemas.microsoft.com/vs/2009/dgml"">
  <Nodes>
    <Node Id=""1"" Label=""first"" />
    <Node Id=""2"" Label=""second"" />
  </Nodes>
  <Links>
    <Link Source=""1"" Target=""2"" Label=""connects"" />
  </Links>
</DirectedGraph>";

        private const string StyledDgml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<DirectedGraph xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://schemas.microsoft.com/vs/2009/dgml"">
  <Nodes>
    <Node Id=""1"" Label=""first"" Category=""category"" />
    <Node Id=""2"" Label=""second"" />
  </Nodes>
  <Links>
    <Link Source=""1"" Target=""2"" Label=""connects"" />
  </Links>
  <Styles>
    <Style TargetType=""Node"">
      <Condition Expression=""HasCategory('category')"" />
      <Setter Property=""Background"" Value=""#FF000000"" />
    </Style>
  </Styles>
</DirectedGraph>";

        private const string CategoriesDgml =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<DirectedGraph xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://schemas.microsoft.com/vs/2009/dgml"">
  <Nodes>
    <Node Id=""1"" Label=""first"" Category=""number"" />
    <Node Id=""2"" Label=""second"" />
  </Nodes>
  <Links>
    <Link Source=""1"" Target=""2"" Label=""connects"" Category=""link"" />
  </Links>
  <Categories>
    <Category Id=""number"" Background=""Green"" />
    <Category Id=""link"" Stroke=""Black"" BasedOn=""number"" />
  </Categories>
</DirectedGraph>";

    }
}
