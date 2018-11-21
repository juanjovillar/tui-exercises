using System;
using System.Xml;

namespace FileReader.Cryptography.Decrypters
{
    public class XMLReverseDecrypter : IDecrypter
    {
        //NOTE: Dull implementation, only for demonstration purposes

        public string Decrypt(string content)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);

            var root = xmlDoc.DocumentElement;
            var nodes = root.SelectNodes("/root/user");
            foreach (XmlNode node in nodes)
            {
                var nodeContent = node.InnerText;
                var charArray = nodeContent.ToCharArray();
                Array.Reverse(charArray);
                node.InnerText = new string(charArray);
            }

            return xmlDoc.OuterXml;
        }
    }
}
