using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dgml.Net;

namespace Dgml.Net.Test
{
    [TestClass]
    public class DirectedGraphTest
    {
        [TestMethod]
        public void TestSave_ValidDgml()
        {
            DirectedGraphNode first = new DirectedGraphNode { Id = "1", Label = "first" };
            DirectedGraphNode second = new DirectedGraphNode { Id = "2", Label = "second" };
            DirectedGraphLink link = new DirectedGraphLink { Source = "1", Target = "2", Label = "connects" };

            DirectedGraph graph = new DirectedGraph()
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
            DirectedGraphNode first = new DirectedGraphNode { Id = "1", Label = "first", Category1 = "category", };
            DirectedGraphNode second = new DirectedGraphNode { Id = "2", Label = "second" };
            DirectedGraphLink link = new DirectedGraphLink { Source = "1", Target = "2", Label = "connects" };
            DirectedGraphStyle style = DgmlHelper.CreateCategoryBackgroundStyle("category", "#FF000000");

            DirectedGraph graph = new DirectedGraph
            {
                Nodes = new[] { first, second },
                Links = new[] { link },
                Styles = new[] { style },
            };

            string actualDgml = graph.ToDgml();

            Asserter.MatchingXml(GraphXml.DirectedStyled, actualDgml);
        }

        [TestMethod]
        public void TestLoad_ValidDgml()
        {
            Graph loadedGraph = Graph.FromString(GraphXml.DirectedValid);
            Asserter.MatchingXml(GraphXml.DirectedValid, loadedGraph.ToDgml());
        }
    }
}