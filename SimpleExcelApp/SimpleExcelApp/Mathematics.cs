using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleExcelApp.Model;

namespace SimpleExcelApp
{
    public class Mathematics
    {
        public string Add(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) + Convert.ToInt32(values.value[1])).ToString();
        }

        public string Subtract(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) - Convert.ToInt32(values.value[1])).ToString();
        }

        public string Devide(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) / Convert.ToInt32(values.value[1])).ToString();
        }

        public string Multiply(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) * Convert.ToInt32(values.value[1])).ToString();
        }

        public MathExpression MathExpression(string text)
        {
            try
            {
                //Define the Mathematical expressions needed and check the value that wi determine the calculation
                MathExpression mathExpressionLocal = new MathExpression();

                mathExpressionLocal.mathSymbol = new int[5];
                mathExpressionLocal.mathSymbol[0] = text.IndexOf('+');
                mathExpressionLocal.mathSymbol[1] = text.IndexOf('-');
                mathExpressionLocal.mathSymbol[2] = text.IndexOf('*');
                mathExpressionLocal.mathSymbol[3] = text.IndexOf('/');
                mathExpressionLocal.mathExpressionSymbol = text.IndexOf('=');

                //Check which mathematical expression is used 
                for (int check = 0; check < mathExpressionLocal.mathSymbol.Length; check++)
                {
                    if (mathExpressionLocal.mathSymbol[check] != -1)
                    {
                        mathExpressionLocal.mathSymbol[4] = mathExpressionLocal.mathSymbol[check];
                        mathExpressionLocal.mathCalculationSymbol = text.Substring(mathExpressionLocal.mathSymbol[check], 1);
                    }
                }
                return mathExpressionLocal;
            }
            catch(Exception ex)
            {
                //MessageBox.Show("An Error occured on the Math: " + ex);
                return null;
            }
        }

    }
}
