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
        [Test]
        public void CheckNthOcurranceOfChar_inString()
        {
            Assert.AreEqual(CommanOperations.findNthOccurance("aabccdafa", 'a', 2),1);
            Assert.AreEqual(CommanOperations.findNthOccurance("aabccdafa", 'a', 3),6);
            Assert.AreEqual(CommanOperations.findNthOccurance("aabccdafa", 'x', 2),-1);
            
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

        

        //private System.Windows.Controls.ComboBox _comboSelection;
        /*
        public Class1(ComboBox comboSelection)
        {
            _comboSelection = comboSelection;
        }
        */

    }
}
