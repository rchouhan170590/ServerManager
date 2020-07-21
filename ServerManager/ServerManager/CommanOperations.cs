using EnvDTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.Xml;
using System.Xml.Linq;

namespace ServerManager
{
    class CommanOperations
    {
     
        public static String Path_of_StoreDB_XML_file()
        {
            //String file_path = "D:\\INTERN\\2020\\SocGen\\MyVSExtension\\ServerManager\\ServerManager\\ServerManager\\Properties\\StoreDB.xml";
            //return file_path;
            //String a = Properties.StoreDB;
            
            String x = Directory.GetCurrentDirectory(); //Application.StartupPath();
            x = x + "\\..\\..\\Properties\\StoreDB.xml";

            return x;
        }



        public static void replace_connectingStrInXmlConfig_file(String file_path, String replaceBy)
        {
            XDocument fullFile = XDocument.Load(file_path);
            foreach (XElement add in fullFile.Descendants("add"))
            {

                add.Attribute("connectionString").Value = replaceBy;

            }
            fullFile.Save(file_path);
            return;
            
        }

        public static string project_path()
        {
            string path = Properties.GeneralSettings.Default.ActiveProject;
            if (path.Equals("-1"))
                return "";
            return path;
        }


        
    }
}
