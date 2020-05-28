using System;
using System.Xml;

namespace Tests
{
    static class TestDataManager
    {
        static string path = @"..\..\..\TestData.xml";

        public static string GetConfigData(string key)
        {
            XmlDocument testData = new XmlDocument();
            testData.Load(path);
            foreach (XmlNode xnode in testData.DocumentElement)
            {
                if (xnode.Name == key)
                {
                    return xnode.FirstChild.Value;
                }
            }
            throw new Exception("No value exists for given key");
        }
    }
}
