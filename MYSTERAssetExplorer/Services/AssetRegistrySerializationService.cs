using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MYSTERAssetExplorer.Services
{
    //https://mlichtenberg.wordpress.com/2011/12/30/encoding-xml-in-utf-8-with-net/
    public class StringWriterUtf8 : System.IO.StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }

    public class AssetRegistrySerializationService
    {
        public string SerializeRegistry(AssetRegistry registry)
        {
            using (var stringwriter = new StringWriterUtf8())
            {
                var serializer = new XmlSerializer(typeof(AssetRegistry), new Type[] { });
                serializer.Serialize(stringwriter, registry);
                return stringwriter.ToString();
            }
        }

        public AssetRegistry DeserializeRegistry(string xmlText)
        {
            try
            {
                if (xmlText == null)
                    return null;

                using (var reader = new StringReader(xmlText))
                {
                    var serializer = new XmlSerializer(typeof(AssetRegistry), new Type[] { });
                    return serializer.Deserialize(reader) as AssetRegistry;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Could not deserialize the registry, may be poorly formed xml");
            }
        }
    }
}
