using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ServerManager;


using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.IO;
namespace ProjectTest
{
    [TestFixture]
    public class Class1
    {
        [TestCase('a',1)]
        [TestCase('b', 1)]
        public void CheckNthOcurranceOfChar_inString(char input2,int expectedOutput)
        {
            //arrange 
            String input1 = "aabccdafa";
            int input3 = 2;
            
            // action 
            var actualOutput = CommanOperations.findNthOccurance(input1, input2, input3);

            //Assert 
            Assert.AreEqual(actualOutput,expectedOutput);

            //mock progra...// framwork  //testing .. 
            // dependency injection...

        }

        [Test]
        public void CheckstringBefore_Nth_equal()
        {
            Assert.AreEqual(CommanOperations.stringBefore_Nth_equal("abcd=123", 1), "abcd=");
            Assert.AreEqual(CommanOperations.stringBefore_Nth_equal("abc=xyz=123", 4), "-1");
             
        }

        [Test]
        public void CheckstringAfter_Nth_equal()
        {
            Assert.AreEqual(CommanOperations.stringAfter_Nth_equal("abcd;123", 1), ";123");
            Assert.AreEqual(CommanOperations.stringAfter_Nth_equal("abc;xyz;123", 4), "-1");

        }

        [Test]
        public void Check_Server_Exist_Or_Not()
        {
            Assert.AreEqual(ServerOperations.Check_Server_Exist_Or_Not("notExistServer1"), false);
            Assert.AreEqual(ServerOperations.Check_Server_Exist_Or_Not("notExistServer2"), false);
           // Assert.AreEqual(ServerOperations.Check_Server_Exist_Or_Not("server1"), true);
            
        }

        [Test]
        public void Check_Database_Exist_Or_Not()
        {
            Assert.AreEqual(DatabaseOperations.Check_Database_Exist_Or_Not("notExistDB1", "notExistServer1"), false);
            Assert.AreEqual(DatabaseOperations.Check_Database_Exist_Or_Not("notExistDB2", "notExistServer1"), false);

        }

        /*
        [Test]
        public void Test_Add_New_Server()
        {
            ManagerMainWindow temp = new ManagerMainWindow();
            var combobox = temp.GetServerComboBox;

            String serverName = "s1";
            String value = "val1";

            if(!ServerOperations.Check_Server_Exist_Or_Not("s1"))
            {
                ServerOperations.Add_New_Server(serverName, value, combobox);
                Assert.AreEqual(ServerOperations.Check_Server_Exist_Or_Not("s1"), true);
            }
            
        }

        
        //private System.Windows.Controls.ComboBox _combobox;
        /*
        public Class1(ComboBox combobox)
        {
            _combobox = combobox;
        }
        */

    }
}
