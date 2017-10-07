using System.Text.RegularExpressions;
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

            Asserter.MatchingXml(GraphXml.DirectedEmpty, actualDgml);
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

            Asserter.MatchingXml(GraphXml.DirectedValid, actualDgml);
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

            Asserter.MatchingXml(GraphXml.DirectedStyled, actualDgml);
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

            Asserter.MatchingXml(GraphXml.DirectedCategories, actualDgml);
        }



    }
}
