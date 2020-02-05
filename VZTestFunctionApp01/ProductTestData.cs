using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VZTestFunctionApp01
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ProductTestData
    {
        /// <summary>
        /// TestProductRecord 对象
        /// </summary>
        public TestProductRecord testProductRecord { get; set; }
        /// <summary>
        /// TestResultItemList 对象
        /// </summary>
        public TestResultItemList testResultItemList { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TestProductRecord
    {
        /// C:\Users\Terry\source\repos\WindowsFormsApp1\WindowsFormsApp1\App.config<summary>
        /// ProductId
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// TestType 站点
        /// </summary>
        public string TestType { get; set; }

        public string TestResult { get; set; }

        public string DataType { get; set; }

        public string DataValue { get; set; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class TestResultItemList
    {
        public ProductTestDetail ProductTestDetail { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class ProductTestDetail
    {

    }
}
