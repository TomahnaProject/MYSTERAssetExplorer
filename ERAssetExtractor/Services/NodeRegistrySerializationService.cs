using ERAssetExtractor.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ERAssetExtractor.Services
{
    public class NodeRegistrySerializationService
    {
        public string SerializeScript(NodeRegistry script)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(NodeRegistry), new Type[] { });
                serializer.Serialize(stringwriter, script);
                return stringwriter.ToString();
            }
        }

        public NodeRegistry DeserializeScript(string xmlText)
        {
            if (xmlText == null)
                return null;

            using (var reader = new StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(NodeRegistry), new Type[] { });
                return serializer.Deserialize(reader) as NodeRegistry;
            }
        }
    }
}
