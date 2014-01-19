using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JDownLoaderAPI
{
    public class jdownloader_data:DataSet
    {
        public DataSet _ds;
        DataTable _dtPackages;
        DataTable _dtFiles;
        public jdownloader_data(string sXML)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(sXML),false);
                _ds = new DataSet();
                _ds.ReadXml(ms);
                _dtPackages = _ds.Tables[0];
                _dtFiles = _ds.Tables[1];
                _dtPackages.ChildRelations.Add(new DataRelation("package_files", _dtPackages.Columns["package_name"], _dtFiles.Columns["file_package"]));

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
