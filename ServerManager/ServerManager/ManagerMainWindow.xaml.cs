using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


using Microsoft.Win32;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using EnvDTE;

using System.Xml;

namespace ServerManager
{
    /// <summary>
    /// Interaction logic for ManagerMainWindow.xaml
    /// </summary>
    public partial class ManagerMainWindow : System.Windows.Window
    {
        public ManagerMainWindow()
        {
            InitializeComponent();

           // DatabaseComboBox.SelectedIndex = 0;

            const int snugContentWidth = 380;
            const int snugContentHeight = 550;

            var horizontalBorderHeight = SystemParameters.ResizeFrameHorizontalBorderHeight;
            var verticalBorderWidth = SystemParameters.ResizeFrameVerticalBorderWidth;
            var captionHeight = SystemParameters.CaptionHeight;

            Width = snugContentWidth + 2 * verticalBorderWidth;
            Height = snugContentHeight + captionHeight + 2 * horizontalBorderHeight;

            ServerOperations.initializeServerInComboBox(ServerComboBox);
        }

        private void Select_Project_btn_Click(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Show_Project_Path.Content = folderDialog.SelectedPath;
            }
            return;
            
        }

        private void DatabaseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int selectedIndex = DatabaseComboBox.SelectedIndex;
            ComboBox cbx = (ComboBox)sender;
            string dbname = String.Empty;
            if (cbx.SelectedValue == null)
                dbname = cbx.SelectionBoxItem.ToString();
            else
                dbname = cboParser(cbx.SelectedValue.ToString());
            Show_Database_Path.Content = dbname;

            return;
        }
        private void ServerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int selectedIndex = DatabaseComboBox.SelectedIndex;
            ComboBox cbx = (ComboBox)sender;
            string serverName = String.Empty;
            if (cbx.SelectedValue == null)
                serverName = cbx.SelectionBoxItem.ToString();
            else
                serverName = cboParser(cbx.SelectedValue.ToString());
            Show_Server_Path.Content = serverName;

            DatabaseComboBox.Items.Clear();
            Show_Database_Path.Content = "";
            DatabaseOperations.initializeDatabaseInComboBox(serverName, DatabaseComboBox);
            return;
        }

        private static string cboParser(string controlString)
        {
            if (controlString.Contains(':'))
            {
                controlString = controlString.Split(':')[1].TrimStart(' ');
            }
            return controlString;
        }

        public List<string> File_Names_To_replace_connectionString(String dirPath)
        {
            List<String> file_extension_list = Find_All_file_extensions();
            List<string> serverFiles = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories)
                .Where(file => file_extension_list
                .Contains(System.IO.Path.GetExtension(file))).ToList();

            return serverFiles;

        }
        public List<string> Find_All_file_extensions()
        {
            List<String> extension_list = new List<String>();
            if (XML_CheckBox.IsChecked == true)
                extension_list.Add(".xml");
            if (Config_CheckBox.IsChecked == true)
                extension_list.Add(".config");

            return extension_list;
        }

        private void Add_New_Database_btn_Click(object sender, RoutedEventArgs e)
        {
            String dbName = Database_Name_TextBox.Text;
            String value = Database_Value_TextBox.Text;
            dbName = dbName.Trim();
            value = value.Trim();
            String serverName = Show_Server_Path.Content.ToString();

            if ((dbName.Equals("")) || (value.Equals("") ))
            {
                MessageBox.Show("Please enter both Name name and Value ");
                return;
            }
            if(serverName.Equals(""))
            {
                MessageBox.Show("Please First Select The Server");
                return;
            }

            DatabaseOperations.Add_New_Database(dbName, value, serverName, DatabaseComboBox);
            Database_Name_TextBox.Text = Database_Value_TextBox.Text = "";
            return;
        }

        private void Add_New_Server_btn_Click(object sender, RoutedEventArgs e)
        {
            String serverName = Server_Name_TextBox.Text;
            String value = Server_Value_TextBox.Text;

            serverName = serverName.Trim();
            value = value.Trim();

            if( (serverName.Equals("")) || (value.Equals("")) )
            {
                MessageBox.Show("Please enter both Server name and Value ");
                return;
            }

            ServerOperations.Add_New_Server(serverName, value, ServerComboBox);
            Server_Value_TextBox.Text = "";
            Server_Name_TextBox.Text = "";
            return;
        }

        private void Delete_Server_btn_Click(object sender, RoutedEventArgs e)
        {
            String serverName = Show_Server_Path.Content.ToString();
            if(serverName.Equals(""))
            {
                MessageBox.Show("Please Select Server From Drop Down to Delete");
                return;
            }

            int selectedIndex = ServerComboBox.SelectedIndex;
            ServerComboBox.Items.RemoveAt(selectedIndex);
            ServerOperations.Delete_Server(serverName);

            Show_Server_Path.Content = Show_Database_Path.Content = "";

            MessageBox.Show("Delete Server Successfully");
            return;
        }

        private void Delete_database_btn_Click(object sender, RoutedEventArgs e)
        {
            String dbName = Show_Database_Path.Content.ToString();
            String serverName = Show_Server_Path.Content.ToString();
            if (serverName.Equals(""))
            {
                MessageBox.Show("Please Select Server From Drop Down to Delete");
                return;
            }
            if (dbName.Equals(""))
            {
                MessageBox.Show("Please Select Database From Drop Down to Delete");
                return;
            }

            int selectedIndex = DatabaseComboBox.SelectedIndex;
            DatabaseComboBox.Items.RemoveAt(selectedIndex);
            DatabaseOperations.Delete_Database(serverName, dbName);
            Show_Database_Path.Content = "";
            MessageBox.Show("Delete Database Successfully");
            return;
        }

        private void Replace_btn_Click(object sender, RoutedEventArgs e)
        {
            String folderPath = Show_Project_Path.Content.ToString();
            if(folderPath.Equals(""))
            {
                MessageBox.Show("Please Select The Project");
                return;
            }
            List<String> file_list = File_Names_To_replace_connectionString(folderPath);

            String serverName = Show_Server_Path.Content.ToString();
            String databasename = Show_Database_Path.Content.ToString();
            if((serverName.Equals("")) ||(databasename.Equals("")))
            {
                MessageBox.Show("Please Select Both Server And Database");
                return;
            }
            String replaceBy = DatabaseOperations.Get_connection_string(serverName,databasename);
            foreach (String file_path in file_list)
            {
                CommanOperations.replace_connectingStrInXmlConfig_file(file_path, replaceBy);
            }

            MessageBox.Show("Replace Successfully");
            return;
        }

        private void server_database_value_btn_Click(object sender, RoutedEventArgs e)
        {
            String connectionString = "";
            String serverValue = "";
            if(!Show_Server_Path.Content.ToString().Equals(""))
            {
                serverValue = ServerOperations.Get_server_value(Show_Server_Path.Content.ToString());
                if (!Show_Database_Path.Content.ToString().Equals(""))
                    connectionString = DatabaseOperations.Get_connection_string(Show_Server_Path.Content.ToString(),Show_Database_Path.Content.ToString());
            }

            String message = "Server Value :\n";
            message = message + serverValue + "\n";
            message = message + "Connection String :\n";
            message = message + connectionString;

            MessageBox.Show(message);
            return;

        }
    }
}
