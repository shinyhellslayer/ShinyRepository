using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleExcelApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExcelApp.Model;

namespace SimpleExcelApp.Tests
{
    [TestClass()]
    public class MathematicsTests
    {

        ExpressionValues expresionValue = new ExpressionValues();
        Mathematics math = new Mathematics();

        [TestMethod()]
        public void AddTest()
        {
            expresionValue.value = new string[2];
            expresionValue.value[0] = "6";
            expresionValue.value[1] = "5";
            string plus = math.Add(expresionValue, 1);
            //Assert.Fail();
        }

        [TestMethod()]
        public void SubtractTest()
        {
            expresionValue.value = new string[2];
            expresionValue.value[0] = "6";
            expresionValue.value[1] = "5";
            string subtract = math.Subtract(expresionValue, 1);
            // Assert.Fail();
        }

        [TestMethod()]
        public void DevideTest()
        {
            expresionValue.value = new string[2];
            expresionValue.value[0] = "6";
            expresionValue.value[1] = "5";
            string devide = math.Devide(expresionValue, 1);
            // Assert.Fail();
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            expresionValue.value = new string[2];
            expresionValue.value[0] = "6";
            expresionValue.value[1] = "5";
            string multiply = math.Multiply(expresionValue, 1);
            // Assert.Fail();
        }

        [TestMethod()]
        public void mathExpressionTest()
        {
            string text = "=1+2-1";
            string result = math.MathExpression(text,1);
        }

        [TestMethod()]
        public void CalcultationTest()
        {

            ExpressionValues ExpressionLocal = new ExpressionValues();
            ExpressionLocal.value = new string[100];
            string text = "1+2";
            string result = math.Calcultation(text, ExpressionLocal, 1);
        }
    }
}