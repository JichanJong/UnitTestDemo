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
            //frm.ShowDialog();
            //frm.data = "123";
            frm.textBox1.Text = "123";

            //#region
            //frm.validator1.SetRegularExpression(frm.textBox1, "^\\d+$");
            //frm.validator1.SetRegularExpressionMessage(frm.textBox1, "输入的不是正整数");
            //frm.validator1.SetType(frm.textBox1, AICNET.Valitator.Components.ValidationType.RegularExpression);

            //#endregion




            bool result = frm.validator1.Validate();
            bool isInt = CheckIsInt(frm.data);
            //bool isInt = CheckIsInt(GetFormData<object>(frm, "textBox1", "Text"));
            Assert.AreEqual(true, result, "输入的文本不是整数");
            //Assert.IsNotNull(frm.data);
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
