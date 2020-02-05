using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace VZTestFunctionApp01
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    //class XmlSerializeHelper
    //{
    //    /// <summary>
    //    /// 将实体对象转换成XML
    //    /// </summary>
    //    /// <typeparam name="T">实体类型</typeparam>
    //    /// <param name="obj">实体对象</param>
    //    public static string XmlSerialize<T>(T obj)
    //    {
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            Type t = obj.GetType();
    //            XmlSerializer serializer = new XmlSerializer(obj.GetType());
    //            serializer.Serialize(sw, obj);
    //            sw.Close();
    //            return sw.ToString().Replace("utf-16", "utf-8");
    //        }
    //    }

    //    /// <summary>
    //    /// 将XML转换成实体对象
    //    /// </summary>
    //    /// <typeparam name="T">实体类型</typeparam>
    //    /// <param name="strXML">XML</param>
    //    public static T DESerializer<T>(string strXML) where T : class
    //    {
    //        try
    //        {
    //            using (StringReader sr = new StringReader(strXML))
    //            {
    //                XmlSerializer serializer = new XmlSerializer(typeof(T));
    //                return serializer.Deserialize(sr) as T;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return null;
    //        }
    //    }
    //}
}
