using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Diff;
using Org.XmlUnit.Input;
using Org.XmlUnit.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dgml.Net.Test
{
    [TestClass]
    public class Asserter
    {
        public static void MatchCollectionGraph(IDictionary<string, ICollection<string>> expectedGraph, Graph actualGraph)
        {
            Assert.AreEqual(expectedGraph.Keys.Count, actualGraph.Nodes.Length);
            Assert.AreEqual(expectedGraph.Values.SelectMany(v => v).Count(), actualGraph.Links.Length);

            foreach (string nodeName in expectedGraph.Keys)
            {
                Assert.IsNotNull(actualGraph.Nodes.Single(n => n.Id == nodeName));
                foreach (string link in expectedGraph[nodeName])
                {
                    Assert.IsNotNull(actualGraph.Links.Single(node => node.Source == nodeName && node.Target == link));
                }
            }
        }

        [TestMethod]
        public void TestMatchingXml()
        {
            try
            {
                MatchingXml(GraphXml.DirectedStyled, GraphXml.DirectedCategories);
                Assert.Fail("Asserter failed to notice the difference.");
            }
            catch
            {
                // pass
            }

            try
            {
                MatchingXml(GraphXml.DirectedStyled, GraphXml.DirectedStyled);
            }
            catch
            {
                Assert.Fail("Asserter failed to confirm equality.");
            }
        }

        public static void MatchingXml(string expected, string actual)
        {
            var a = new StringSource(expected);
            var b = new StringSource(actual);
            Diff d = DiffBuilder.Compare(a).WithTest(b).Build();
            Assert.IsFalse(d.HasDifferences());
        }
    }
}
