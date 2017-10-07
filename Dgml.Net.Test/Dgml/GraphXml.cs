using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dgml.Net.Test
{
    public static class GraphXml
    {
        public const string DirectedEmpty =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<DirectedGraph xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://schemas.microsoft.com/vs/2009/dgml"" />";

        public const string DirectedValid =
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

        public const string DirectedStyled =
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

        public const string DirectedCategories =
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
