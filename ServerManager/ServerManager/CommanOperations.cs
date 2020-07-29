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
    public class CommanOperations
    {
     
        public static String Path_of_StoreDB_XML_file1()
        {
            //String file_path = "D:\\INTERN\\2020\\SocGen\\MyVSExtension\\ServerManager\\ServerManager\\ServerManager\\Properties\\StoreDB.xml";
            //return file_path;
            //String a = Properties.StoreDB;
            
            String x = Directory.GetCurrentDirectory(); //Application.StartupPath();
            x = x + "\\..\\..\\Properties\\StoreDB.xml";

            return x;
        }

        public static String Path_of_StoreDB_XML_file()
        {
            String file_path = "C:\\VSExtension\\ServerManager\\StoreDB.xml";
            String dirpath = "C:\\VSExtension\\ServerManager";

            //String dirpath2 = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Resources";
            //String file_path2 = dirpath2 + "\\StoreDB.xml";

            if (!Directory.Exists(dirpath))
            {

                Directory.CreateDirectory(dirpath);
                //XmlDocument doc = new XmlDocument();

                String output = "<Servers>";
                output = output + "\n";
                output = output + "</Servers>";
                File.WriteAllText(file_path, output);

                //doc.Save("C:\\VSExtension\\ServerManager\\StoreDB.xml");
                return file_path;
            }

            else
            {
                return file_path;
            }
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


        public static int findNthOccurance(String str, char ch, int N)
        {
            int occur = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    occur += 1;
                }
                if (occur == N)
                    return i;
            }
            return -1;
        }
        //serverDisplaychange
        public static String DisplayValueChange(String connetionString, String Svalue, int position)
        {
            int i = findNthOccurance(connetionString, '=', position);
            int j = findNthOccurance(connetionString, ';', position);
            Console.WriteLine(i);
            Console.WriteLine(j);
            if (j - i - 1 <= 0)
                connetionString = connetionString.Insert(i + 1, Svalue);
            else
            {
                string result = connetionString.Substring(i + 1, j - i - 1);
                connetionString = connetionString.Replace(result, Svalue);
            }
            return connetionString;
        }

        public static string stringBefore_Nth_equal(String connectionString, int n)
        {
            int i = findNthOccurance(connectionString, '=', n);
            if (i == -1)
                return "-1";
            return  connectionString.Substring(0, i + 1);
        }

        public static string stringAfter_Nth_equal(String connectionString, int n)
        {
            int i = findNthOccurance(connectionString, ';', n);
            if (i == -1)
                return "-1";
            return connectionString.Substring(i);  //, connectionString.Length-1
        }

    }
}
