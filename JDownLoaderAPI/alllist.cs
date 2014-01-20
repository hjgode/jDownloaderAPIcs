using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

/*
 * created using xsd on result xml
 * change by hjgode
*/
namespace jDownloaderRemoteControlAPI {
    
    /// <summary>
    /// this class encapsulates jDownloader packages
    /// each package inside packages can have multiple files
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    [XmlRoot("jdownloader")]
    public partial class jdownloaderPackage {

        /*
            XmlSerializer s = new XmlSerializer(typeof(jdownloader));
            System.IO.TextWriter w = new System.IO.StreamWriter(@"C:\Request.xml");
            s.Serialize(w, new jdownloader());
            w.Close();
    
            XmlSerializer s = new XmlSerializer(typeof(jdownloader));
            jdownloader _jdownloader;
            System.IO.TextReader r = new System.IO.StreamReader("request.xml");
            _jdownloader = (jdownloader)s.Deserialize(r);
            r.Close();

        */
        /// <summary>
        /// Serialize an object to a XML file
        /// </summary>
        /// <param name="targetInstance">the class type</param>
        /// <returns>xml string with the serialized object</returns>
        public static string SerializeToXmlString(object targetInstance)
        {
            string retVal = string.Empty;
            TextWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(targetInstance.GetType());
            serializer.Serialize(writer, targetInstance);
            retVal = writer.ToString();
            return retVal;
        }
        /// <summary>
        /// convert xml back to object
        /// </summary>
        /// <param name="objectXml">xml with object data</param>
        /// <param name="targetType">type of the object to create</param>
        /// <returns></returns>
        public static object DeserializeFromXmlString(string objectXml, Type targetType)
        {
            object retVal = null;
            XmlSerializer serializer = new XmlSerializer(targetType);
            StringReader stringReader = new StringReader(objectXml);
            XmlTextReader xmlReader = new XmlTextReader(stringReader);
            retVal = serializer.Deserialize(xmlReader);
            return retVal;
        }
        
        private package[] packageField;
        
        public string dump()
        {
            string s = "";
            string sTAB = "\t";
            foreach (package p in this.packages)
            {
                s += sTAB + p.dump()+"\r\n";
            }
            return s;
        }

        /// <summary>
        /// array of packages
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("package")]
        public package[] packages {
            get {
                return this.packageField;
            }
            set {
                this.packageField = value;
            }
        }

        /// <summary>
        /// package object
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
        public partial class package
        {

            private string package_ETAField;

            private string package_linksinprogressField;

            private string package_linkstotalField;

            private string package_loadedField;

            private string package_nameField;

            private decimal package_percentField;

            private string package_sizeField;

            private string package_speedField;

            private string package_todoField;

            private @file[] fileField;

            public string dump()
            {
                string s = "";
                string sTAB = "\t";
                s +=
                    this.package_name + sTAB +
                    this.package_ETA + sTAB +
                    this.package_percent.ToString() + sTAB +
                    this.package_size + sTAB +
                    this.package_speed + sTAB +
                    this.package_todo + sTAB +
                    this.package_loaded + sTAB;
                foreach (file f in this.@files)
                {
                    s += f.dump();
                    s += "\r\n";
                }
                return s;
            }
            /// <summary>
            /// estimated time to finish download of package
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string package_ETA
            {
                get
                {
                    return this.package_ETAField;
                }
                set
                {
                    this.package_ETAField = value;
                }
            }

            /// <summary>
            /// how many links are currently in progress
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string package_linksinprogress
            {
                get
                {
                    return this.package_linksinprogressField;
                }
                set
                {
                    this.package_linksinprogressField = value;
                }
            }

            /// <summary>
            /// number of links inside package
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string package_linkstotal
            {
                get
                {
                    return this.package_linkstotalField;
                }
                set
                {
                    this.package_linkstotalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string package_loaded
            {
                get
                {
                    return this.package_loadedField;
                }
                set
                {
                    this.package_loadedField = value;
                }
            }

            /// <summary>
            /// name of the package
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
            public string package_name
            {
                get
                {
                    return this.package_nameField;
                }
                set
                {
                    this.package_nameField = value;
                }
            }

            /// <summary>
            /// percent of already downloaded data
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal package_percent
            {
                get
                {
                    return this.package_percentField;
                }
                set
                {
                    this.package_percentField = value;
                }
            }

            /// <summary>
            /// total size of package data
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string package_size
            {
                get
                {
                    return this.package_sizeField;
                }
                set
                {
                    this.package_sizeField = value;
                }
            }

            /// <summary>
            /// current speed of package download
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string package_speed
            {
                get
                {
                    return this.package_speedField;
                }
                set
                {
                    this.package_speedField = value;
                }
            }

            /// <summary>
            /// how many data is still to load
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string package_todo
            {
                get
                {
                    return this.package_todoField;
                }
                set
                {
                    this.package_todoField = value;
                }
            }

            /// <summary>
            /// array of files inside the package
            /// </summary>
            [System.Xml.Serialization.XmlElementAttribute("file")]
            public file[] @files
            {
                get
                {
                    return this.fileField;
                }
                set
                {
                    this.fileField = value;
                }
            }
        }

        /// <summary>
        /// jDownloader file description
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
        public class @file
        {

            private string file_hosterField;

            private string file_nameField;

            private string file_packageField;

            private decimal file_percentField;

            private string file_speedField;

            private string file_statusField;

            public string dump()
            {
                string s = "";
                string sTAB = "\t";
                s +=
                    this.file_package + sTAB +
                    this.file_name + sTAB +
                    this.file_hoster + sTAB +
                    this.file_percent.ToString() +
                    this.file_speed + sTAB +
                    this.file_status;
                return s;
            }

            /// <summary>
            /// file hoster attribute
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
            public string file_hoster
            {
                get
                {
                    return this.file_hosterField;
                }
                set
                {
                    this.file_hosterField = value;
                }
            }

            /// <summary>
            /// file name
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
            public string file_name
            {
                get
                {
                    return this.file_nameField;
                }
                set
                {
                    this.file_nameField = value;
                }
            }

            /// <summary>
            /// package name where the file belongs to
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NCName")]
            public string file_package
            {
                get
                {
                    return this.file_packageField;
                }
                set
                {
                    this.file_packageField = value;
                }
            }

            /// <summary>
            /// percent already downloaded
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal file_percent
            {
                get
                {
                    return this.file_percentField;
                }
                set
                {
                    this.file_percentField = value;
                }
            }

            /// <summary>
            /// current download speed for this file
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string file_speed
            {
                get
                {
                    return this.file_speedField;
                }
                set
                {
                    this.file_speedField = value;
                }
            }

            /// <summary>
            /// status of file download
            /// </summary>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string file_status
            {
                get
                {
                    return this.file_statusField;
                }
                set
                {
                    this.file_statusField = value;
                }
            }
        }

    }
    
}
