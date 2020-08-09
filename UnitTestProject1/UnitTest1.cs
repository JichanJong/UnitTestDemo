using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using UnitTest.Model;
using UnitTest.Win;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsInt()
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            bool isInt = CheckIsInt(frm.data);
            //bool isInt = CheckIsInt(GetFormData<object>(frm, "textBox1", "Text"));
            Assert.AreEqual(true,isInt);
            Assert.IsNotNull(frm.data);
            //Assert.AreEqual("",frm.data);
        }

        [TestMethod]
        public void TestIsSame()
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            //Assert.IsNotNull(frm.data);
            Assert.AreSame("abcd",frm.data);
        }

        [TestMethod]
        public void TestIsNull()
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            Assert.IsNull(((ComboItem)frm.data2).Id);
        }

        [TestMethod]
        public void TestCompare()
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
            int num = Convert.ToInt32(frm.data);
            Assert.IsTrue(num >= 0 && num <= 100,"必须输入0 — 100之间的整数");
            

        }

        public T GetFormData<T>(Form frm, string controlName, string propertyName)
        {
            Type t = frm.GetType();
            FieldInfo fieldInfo = t.GetField(controlName);
            if (fieldInfo != null)
            {
                var control = fieldInfo.GetValue(t);
                PropertyInfo property = control.GetType().GetProperty(propertyName);
                if (property != null)
                {
                   return (T)property.GetValue(control,BindingFlags.Instance,null,null,null);
                }
            }
            return default(T);
        }



        private bool CheckIsInt(object data)
        {
            try
            {
                Convert.ToInt32(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
