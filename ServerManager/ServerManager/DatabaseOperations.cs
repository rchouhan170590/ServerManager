using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using System.Windows;
using System.Xml;
using System.IO;
using Microsoft.VisualStudio.Debugger.Interop;

namespace ServerManager
{
    class DatabaseOperations
    {
        public static void initializeDatabaseInComboBox(String ServerName,ComboBox dbcomboBox)
        {
            foreach (String db in List_All_Database_For_SelectedServer(ServerName))
                dbcomboBox.Items.Add(db);
            return;
        }

        public static void Add_New_Database(String displayName, String connectionString, String serverName,ComboBox combobox)
        {
            if(!Check_Database_Exist_Or_Not(serverName, displayName))
            {


                String file_path = CommanOperations.Path_of_StoreDB_XML_file();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file_path);

                String x = "//Servers//Server[@displayName='" + serverName + "']";
                XmlNode root = xmlDoc.SelectSingleNode(x);

                XmlElement xmlEle = xmlDoc.CreateElement("databasename");

                XmlAttribute newAttr1 = xmlDoc.CreateAttribute("displayName");
                XmlAttribute newAttr2 = xmlDoc.CreateAttribute("connectionString");
                newAttr1.Value = displayName;
                newAttr2.Value = connectionString;
                xmlEle.Attributes.Append(newAttr1);
                xmlEle.Attributes.Append(newAttr2);

                root.InsertAfter(xmlEle, root.SelectSingleNode("/Server"));

                xmlDoc.Save(file_path);

                combobox.IsEnabled = true;
                combobox.Items.Add(displayName);
                MessageBox.Show("Database Added Successfully");
                return;
            }
            MessageBox.Show("Sorry Already Exist Database with this name");
            return;

        }


        public static List<String> List_All_Database_For_SelectedServer(String ServerName)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);

            String x = "/Servers/Server[@displayName = '" + ServerName + "']";
            x = x + "/databasename";

            var node1 = doc.SelectNodes(x);
            List<String> dblist = new List<String>();
            foreach (XmlNode node in node1)
            {
                dblist.Add(node.Attributes[0].Value);
            }
            return dblist;
        }

        public static bool Check_Database_Exist_Or_Not(String serverName,String databasename)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);

            String x = "/Servers/Server[@displayName = '" + serverName + "']";
            x = x + "/databasename";

            var nodes = doc.SelectNodes(x);
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes[0].Value.Equals(databasename))
                    return true;
            }
            return false;
        }


        public static void Delete_Database(String serverName,String databasename)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);

            String x = "/Servers/Server[@displayName = '" + serverName + "']";
            x = x + "/databasename[@displayName = '" + databasename + "']";

            XmlNode node = doc.SelectSingleNode(x);
            
            if (node != null)
            {
                XmlNode parent = node.ParentNode;
                parent.RemoveChild(node);
                doc.Save(@file_path);
            }
        }

        public static string Get_connection_string(String serverName,String databasename)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);

            String x = "/Servers/Server[@displayName = '" + serverName + "']";
            x = x + "/databasename[@displayName = '" + databasename + "']";

            XmlNode node = doc.SelectSingleNode(x);
            if(node != null)
            {
                String connectionString = node.Attributes["connectionString"].Value;
                return connectionString;
            }

            return "-1";
        }

        

    }
}
