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
        /// <summary>
        /// Add function
        /// </summary>
        /// <param name="values"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public string Add(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            //recursive process to do the add function 
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 1]) + Convert.ToDouble(values.value[loop - 2])).ToString();
            return Add(values, loop - 1);
        }
        
        /// <summary>
        /// Subtract function
        /// </summary>
        /// <param name="values"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public string Subtract(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            //recursive process to do the subtract function 
            int test = Convert.ToInt32(values.value[loop - 2]) - Convert.ToInt32(values.value[loop - 1]);
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 2]) - Convert.ToDouble(values.value[loop - 1])).ToString();
            return Subtract(values, loop - 1);
        }
        
        /// <summary>
        /// Devide function
        /// </summary>
        /// <param name="values"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public string Devide(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            //recursive process to do the devide function 
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 2]) / Convert.ToDouble(values.value[loop - 1])).ToString();
            return Devide(values, loop - 1);
        }

        /// <summary>
        /// Multiply function
        /// </summary>
        /// <param name="values"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public string Multiply(ExpressionValues values, int loop)
        {
            if (loop == 1)
            {
                return values.value[0];
            }
            //recursive process to do the multiply function 
            values.value[loop - 2] = (Convert.ToDouble(values.value[loop - 1]) * Convert.ToDouble(values.value[loop - 2])).ToString();
            return Multiply(values, loop - 1);
        }
        /// <summary>
        /// Initial mathematical call and manupilation of string value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cells"></param>
        /// <returns></returns>
        public string MathExpression(string text, int cells)
        {
            try
            {
                //Define the Mathematical expressions needed and check the value that wi determine the calculation
                MathExpression mathExpressionLocal = new MathExpression();
                ExpressionValues ExpressionLocal = new ExpressionValues();

                ExpressionLocal.value = new string[100];
                int count = -1;
                string answer = null;
                //split the string given to validate what mathematical functions to call and calculations to do
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
                            answer = Calcultation(text.Substring(1), ExpressionLocal, count);
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
                            if (count == 0)
                            {
                                answer = Calcultation(text.Substring(1), ExpressionLocal, cells);
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
                            if (count == 0)
                            {
                                answer = Calcultation(text.Substring(1), ExpressionLocal, cells);
                            }
                            else
                            {
                                answer = Calcultation(text.Substring(1), ExpressionLocal, cells);
                            }
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
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An Error occured on the Math: " + ex);
                return null;
            }
        }

        /// <summary>
        /// Recursive calculation method for all calculations needed
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ExpressionLocal"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Calcultation(string text, ExpressionValues ExpressionLocal, int length)
        {
            //do the calculations with 2 values at a time for the whole string
            string[] expression = text.Substring(0).Split('+');
            string answer = null;
            string value = null;
            for (int i = 0; i < expression.Length; i++)
            {
                // check which mathematical expressions where passed
                bool matchMinus = expression[i].Contains("-");
                bool matchMultiply = expression[i].Contains("*");
                bool matchDivide = expression[i].Contains("/");
                bool matchPlus = expression[i].Contains("+");
                if (!string.IsNullOrEmpty(expression[i]))
                {
                    if (matchMinus == true)
                    {
                        if (expression[i].Substring(0, 1) != "-")
                        {
                            string[] subExpression = expression[i].Substring(0).Split('-');
                            //do the calculations for each expression
                            for (int g = 0; g < subExpression.Length; g++)
                            {
                                if (matchPlus == true || matchDivide == true || matchMultiply == true)
                                {
                                    subExpression[g] = Calcultation(subExpression[g], ExpressionLocal, 1);
                                }
                            }

                            ExpressionLocal.value = subExpression;

                            value = Subtract(ExpressionLocal, ExpressionLocal.value.Length);
                            expression[i] = value;
                        }
                    }

                    if (matchMultiply == true)
                    {
                        if (expression[i].Substring(0, 1) != "-")
                        {
                            string[] subExpression = expression[i].Substring(0).Split('*');
                            //do the calculations for each expression
                            for (int g = 0; g < subExpression.Length; g++)
                            {
                                if (matchMinus == true || matchDivide == true || matchPlus == true)
                                {
                                    subExpression[g] = Calcultation(subExpression[g], ExpressionLocal, 1);
                                }
                            }

                            ExpressionLocal.value = subExpression;
                            value = Multiply(ExpressionLocal, ExpressionLocal.value.Length);
                            expression[i] = value;
                        }
                    }

                    if (matchDivide == true)
                    {
                        if (expression[i].Substring(0, 1) != "-")
                        {
                            string[] subExpression = expression[i].Substring(0).Split('/');
                            //do the calculations for each expression
                            for (int g = 0; g < subExpression.Length; g++)
                            {
                                if (matchMinus == true || matchMultiply == true || matchPlus == true)
                                {
                                    subExpression[g] = Calcultation(subExpression[g], ExpressionLocal, 1);
                                }
                            }

                            ExpressionLocal.value = subExpression;
                            value = Devide(ExpressionLocal, ExpressionLocal.value.Length);
                            expression[i] = value;
                        }
                    }
                    if (matchPlus == true)
                    {
                        if (expression[i].Substring(0, 1) != "-")
                        {
                            string[] subExpression = expression[i].Substring(0).Split('+');
                            //do the calculations for each expression
                            for (int g = 0; g < subExpression.Length; g++)
                            {
                                if (matchMinus == true || matchDivide == true || matchMultiply == true)
                                {
                                    subExpression[g] = Calcultation(subExpression[g], ExpressionLocal, 1);
                                }
                            }

                            ExpressionLocal.value = subExpression;
                            value = Add(ExpressionLocal, ExpressionLocal.value.Length);
                            expression[i] = value;
                        }
                    }
                }
                if (i == (expression.Length - 1))
                {
                    ExpressionLocal.value = expression;
                    answer = Add(ExpressionLocal, ExpressionLocal.value.Length);
                }
            }
            
            if (length == 1)
            {
                return answer;
            }
            return Calcultation(text, ExpressionLocal, length - 1);
        }
    }
}
