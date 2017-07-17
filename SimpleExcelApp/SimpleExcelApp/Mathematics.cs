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

        public string Add2(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }

            // int valuescheck = Convert.ToInt32(values.value[loop-1]) + Convert.ToInt32(values.value[loop - 2]);
            // values.value[loop - 2] = valuescheck.ToString();
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 1]) + Convert.ToDouble(values.value[loop - 2])).ToString();
            return Add2(values, loop - 1);
            //return null;
        }

        public string Subtract(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) - Convert.ToInt32(values.value[1])).ToString();
        }

        public string Subtract2(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            //int check = Math.Sign(Convert.ToInt32("-1"));
            int test = Convert.ToInt32(values.value[loop - 2]) - Convert.ToInt32(values.value[loop - 1]);
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 2]) - Convert.ToDouble(values.value[loop - 1])).ToString();
            return Subtract2(values, loop - 1);
        }

        public string Devide(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) / Convert.ToInt32(values.value[1])).ToString();
        }

        public string Devide2(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 2]) / Convert.ToDouble(values.value[loop - 1])).ToString();
            return Devide2(values, loop - 1);
        }

        public string Multiply(ExpressionValues values)
        {
            return (Convert.ToInt32(values.value[0]) * Convert.ToInt32(values.value[1])).ToString();
        }

        public string Multiply2(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 1]) * Convert.ToDouble(values.value[loop - 2])).ToString();
            return Multiply2(values, loop - 1);
        }

        //public MathExpression MathExpression(string text, int cells)
        public string MathExpression(string text, int cells)
        {
            try
            {
                //Define the Mathematical expressions needed and check the value that wi determine the calculation
                MathExpression mathExpressionLocal = new MathExpression();
                ExpressionValues ExpressionLocal = new ExpressionValues();

                ExpressionLocal.value = new string[5];
                int count = -1;
                string answer = null;

                count = text.Split('*').Length - 1;

                if (count == 0)
                {
                    count = text.Split('/').Length - 1;
                    if (count == 0)
                    {
                        count = text.Split('+').Length - 1;
                        if (count == 0)
                        {
                            count = text.Split('-').Length - 1;
                            //if
                        }
                        else
                        {
                          answer = Calcultation(text.Substring(1), ExpressionLocal,count);
                        }
                    }
                    else
                    {
                        count = text.Split('+').Length - 1;
                        if (count == 0)
                        {
                            count = text.Split('-').Length - 1;
                        }
                        else
                        {
                            answer = Calcultation(text.Substring(1), ExpressionLocal, count);
                        }
                    }

                }
                else
                {
                    count = text.Split('/').Length - 1;
                    if (count == 0)
                    {
                        count = text.Split('+').Length - 1;
                        if (count == 0)
                        {
                            count = text.Split('-').Length - 1;
                        }
                        else
                        {
                           answer = Calcultation(text.Substring(1), ExpressionLocal, count);
                        }
                    }
                    else
                    {
                        answer = Calcultation(text.Substring(1), ExpressionLocal, count);
                    }
                }

                return answer;

                //mathExpressionLocal.mathSymbol = new int[cells];
                //mathExpressionLocal.mathSymbol[0] = text.IndexOf('+');
                //mathExpressionLocal.mathSymbol[1] = text.IndexOf('-');
                //mathExpressionLocal.mathSymbol[2] = text.IndexOf('*');
                //mathExpressionLocal.mathSymbol[3] = text.IndexOf('/');
                //mathExpressionLocal.mathExpressionSymbol = text.IndexOf('=');

                ////Check which mathematical expression is used 
                //for (int check = 0; check < mathExpressionLocal.mathSymbol.Length; check++)
                //{
                //    if (mathExpressionLocal.mathSymbol[check] != -1)
                //    {
                //        mathExpressionLocal.mathSymbol[4] = mathExpressionLocal.mathSymbol[check];
                //        mathExpressionLocal.mathCalculationSymbol = text.Substring(mathExpressionLocal.mathSymbol[check], 1);
                //    }
                //}
                //return mathExpressionLocal;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An Error occured on the Math: " + ex);
                return null;
            }
        }


        public string Calcultation(string text, ExpressionValues ExpressionLocal, int length)
        {
            //int count = text.Split('+').Length - 1;
            string[] test = text.Substring(0).Split('+');
            // mathExpressionLocal.mathPlusSymbol = test;
            // int value = 0;
            string answer = null;
            string value = null;
            //int pos = Array.IndexOf(test, match);
            for (int i = 0; i < test.Length; i++)
            {
                bool matchMinus = test[i].Contains("-");
                bool matchMultiply = test[i].Contains("*");
                bool matchDivide = test[i].Contains("/");
                //string match = Array.Find(test, n => n.Contains("-"));
                //if (!string.IsNullOrEmpty(match))
                if (!string.IsNullOrEmpty(test[i]))
                {
                    if (matchMinus == true)
                    {
                        // if (match.Substring(0, 1) != "-")
                        if (test[i].Substring(0, 1) != "-")
                        {
                            string[] test2 = test[i].Substring(0).Split('-');

                            for (int g = 0; g < test2.Length; g++)
                            {
                                test2[g] = Calcultation(test2[g], ExpressionLocal, 1);
                            }

                            ExpressionLocal.value = test2;
                            // value = Convert.ToInt32(test2[0]) - Convert.ToInt32(test2[1]);

                            value = Subtract2(ExpressionLocal, ExpressionLocal.value.Length);
                            test[i] = value;
                        }
                    }

                    if (matchMultiply == true)
                    {
                        // if (match.Substring(0, 1) != "-")
                        if (test[i].Substring(0, 1) != "-")
                        {
                            string[] test2 = test[i].Substring(0).Split('*');

                            for(int g = 0; g<test2.Length;g++)
                            {
                                test2[g] = Calcultation(test2[g],ExpressionLocal,1);
                            }

                            ExpressionLocal.value = test2;
                            // value = Convert.ToInt32(test2[0]) - Convert.ToInt32(test2[1]);

                            value = Multiply2(ExpressionLocal, ExpressionLocal.value.Length);
                            test[i] = value;
                        }
                    }

                    if (matchDivide == true)
                    {
                        // if (match.Substring(0, 1) != "-")
                        if (test[i].Substring(0, 1) != "-")
                        {
                            string[] test2 = test[i].Substring(0).Split('/');
                            ExpressionLocal.value = test2;
                            // value = Convert.ToInt32(test2[0]) - Convert.ToInt32(test2[1]);

                            value = Devide2(ExpressionLocal, ExpressionLocal.value.Length);
                            test[i] = value;
                        }
                    }
                }
                if (i == (test.Length - 1))
                {
                    ExpressionLocal.value = test;
                    answer = Add2(ExpressionLocal, ExpressionLocal.value.Length);
                }
            }


            if (length == 1)
            {
                return answer;
            }

            // int valuescheck = Convert.ToInt32(values.value[loop-1]) + Convert.ToInt32(values.value[loop - 2]);
            // values.value[loop - 2] = valuescheck.ToString();
            return Calcultation(text, ExpressionLocal, length - 1);

           // return answer;
        }
    }
}
