using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.IO;
namespace ServerManager
{
    class ServerOperations
    {
        public static void initializeServerInComboBox(ComboBox combobox)
        {
            foreach (String server in List_of_All_Server())
                combobox.Items.Add(server);

            return; 
        }

        public static void Add_New_Server(String serverName,String value, ComboBox combobox)
        {

            if(!Check_Server_Exist_Or_Not(serverName))
            {
                combobox.Items.Add(serverName);
                String file_path = CommanOperations.Path_of_StoreDB_XML_file();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(file_path);
                XmlNode root = xmlDoc.DocumentElement;
                XmlElement xmlEle = xmlDoc.CreateElement("Server");

                XmlAttribute newAttr1 = xmlDoc.CreateAttribute("displayName");
                XmlAttribute newAttr2 = xmlDoc.CreateAttribute("value");
                newAttr1.Value = serverName;
                newAttr2.Value = value;
                xmlEle.Attributes.Append(newAttr1);
                xmlEle.Attributes.Append(newAttr2);

                root.InsertAfter(xmlEle, root.SelectSingleNode("/Server"));

                xmlDoc.Save(file_path);
                MessageBox.Show("Successfully Added New Server");

                return;
            }

            MessageBox.Show("Already Exist With This Name");
            return ;
        }

        public static List<String> List_of_All_Server()
        {
            List<String> serverList = new List<String>();
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument document = new XmlDocument();
            document.Load(@file_path);
            var nodes1 = document.SelectNodes("//Server");

            foreach (XmlNode node in nodes1)
            {
                serverList.Add(node.Attributes[0].Value);
            }
            return serverList;

        }

        public static bool Check_Server_Exist_Or_Not(String serverName)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument document = new XmlDocument();
            document.Load(@file_path);
            var nodes1 = document.SelectNodes("//Server");

            foreach (XmlNode node in nodes1)
            {
                if (node.Attributes[0].Value.Equals(serverName))
                    return true;
            }
            return false;
        }

        public static void Delete_Server(String serverName)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);

            String x = "/Servers/Server[@displayName = '" + serverName + "']";
            XmlNode node = doc.SelectSingleNode(x);

            if (node != null)
            {
                XmlNode parent = node.ParentNode;
                parent.RemoveChild(node);
                //string newXML = doc.OuterXml;
                doc.Save(@file_path);
            }

            return;
        }

        public static string Get_server_value(String serverName)
        {
            String file_path = CommanOperations.Path_of_StoreDB_XML_file();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);

            String x = "/Servers/Server[@displayName = '" + serverName + "']";
            //x = x + "/databasename[@displayName = '" + databasename + "']";

            XmlNode node = doc.SelectSingleNode(x);
            if (node != null)
            {
                String connectionString = node.Attributes["value"].Value;
                return connectionString;
            }

            return "-1";
        }


    }
}
