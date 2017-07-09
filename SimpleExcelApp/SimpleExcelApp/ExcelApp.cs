using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleExcelApp
{
    public partial class ExcelApp : Form
    {
        public ExcelApp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create the amount of rows needed and add the header names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowtextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(RowtextBox.Text))
                {
                    if (Convert.ToInt32(RowtextBox.Text) > 100)
                    {
                        MessageBox.Show ("The Rows cannot exceed the number 100");
                    }
                    else
                    {
                        dataGridView.RowCount = Convert.ToInt32(RowtextBox.Text);
                        for (int num = 1; num <= Convert.ToInt32(RowtextBox.Text); num++)
                        {
                            dataGridView.Rows[num - 1].HeaderCell.Value = num.ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error ocurred on Row adjustment: " + ex);
            }
        }

        /// <summary>
        /// Create the amount of coumns needed and add the header names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumntextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ColumntextBox.Text))
                {
                    if (Convert.ToInt32(ColumntextBox.Text) > 26)
                    {
                        MessageBox.Show("The Columns cannot exceed the number of Alphabetical Characters");
                    }
                    else
                    {
                        dataGridView.ColumnCount = Convert.ToInt32(ColumntextBox.Text);
                        for (int num = 0; num < Convert.ToInt32(ColumntextBox.Text); num++)
                        {
                            Alphabet.AlphabetEnum alphabetEnum = (Alphabet.AlphabetEnum)num;
                            dataGridView.Columns[num].HeaderText = alphabetEnum.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ocurred on Column adjustment: " + ex);
            }
        }

        /// <summary>
        /// Check what values are passed and manupilate as needed by the math expression given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Mathematics math = new Mathematics();
            try
            {
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string text = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    //Define the Mathematical expressions needed and check the value that wi determine the calculation
                    int[] mathSymbol = new int[5];
                    mathSymbol[0] = text.IndexOf('+');
                    mathSymbol[1] = text.IndexOf('-');
                    mathSymbol[2] = text.IndexOf('*');
                    mathSymbol[3] = text.IndexOf('/');
                    string mathCalculationSymbol = null;
                    int mathExpressionSymbol = text.IndexOf('=');

                    //Check which mathematical expression is used 
                    for (int check = 0; check < mathSymbol.Length; check++)
                    {
                        if (mathSymbol[check] != -1)
                        {
                            mathSymbol[4] = mathSymbol[check];
                            mathCalculationSymbol = text.Substring(mathSymbol[check], 1);
                        }
                    }

                    //Check if a calculation needs to happen
                    if (mathExpressionSymbol != -1)
                    {
                        int[] index = new int[dataGridView.ColumnCount];
                        Alphabet.AlphabetEnum rowIndex = (Alphabet.AlphabetEnum)e.RowIndex;
                        string[] names = Enum.GetNames(rowIndex.GetType());

                        //Check if a cell value is used with the enum provided
                        for (int i = 0; i < names.Length; i++)
                        {
                            if (names[i] == text.Substring(mathExpressionSymbol + 1, mathExpressionSymbol + 1))
                            {
                                index[0] = i;
                                break;
                            }
                            else
                            {
                                index[0] = -1;
                            }
                        }

                        //Check if a cell value is used or if it is a fixed numerical value
                        string value1 = null;
                        if (index[0] != -1)
                        {
                            //If a cell value is used use the cell value
                            int num = Convert.ToInt32(text.Substring(mathExpressionSymbol + 2, mathSymbol[4] - (mathExpressionSymbol + 2)));
                            if (dataGridView.Rows[num - 1].Cells[index[0]].Value != null)
                            {
                                value1 = dataGridView.Rows[num - 1].Cells[index[0]].Value.ToString();
                            }
                        }
                        else
                        {
                            int num = Convert.ToInt32(text.Substring(mathExpressionSymbol + 1, mathSymbol[4] - 1));
                            value1 = num.ToString();
                        }

                        string value2 = null;
                        // Check the length of the cell tect to make sure it is cell values or some cell values
                        if (text.Length > 3)
                        {
                            for (int j = 0; j < names.Length; j++)
                            {
                                if (names[j] == text.Substring(mathSymbol[4] + 1, 1))
                                {
                                    index[1] = j;
                                    break;
                                }
                                else
                                {
                                    index[1] = -1;
                                }
                            }

                            //Check if a cell value is used or if it is a fixed numerical value
                            if (index[1] != -1)
                            {
                                //If a cell value is used use the cell value
                                int num2 = Convert.ToInt32(text.Substring(mathSymbol[4] + 2));
                                if (dataGridView.Rows[num2 - 1].Cells[index[1]].Value != null)
                                {
                                    value2 = dataGridView.Rows[num2 - 1].Cells[index[1]].Value.ToString();
                                }
                            }
                            else
                            {
                                int num2 = Convert.ToInt32(text.Substring(mathSymbol[4] + 1));
                                value2 = num2.ToString();
                            }
                        }
                        else
                        {
                            mathCalculationSymbol = "default";
                        }

                        //Switch to call the right Mathermatical Expression
                        switch (mathCalculationSymbol)
                        {
                            case "+":
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Add(value1, value2);
                                break;
                            case "-":
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Subtract(value1, value2);
                                break;
                            case "*":
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Multiply(value1, value2);
                                break;
                            case "/":
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Devide(value1, value2);
                                break;
                            default:
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value1;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // exception written to active cell
                MessageBox.Show("An Error occured on the cell: " + ex);
            }
        }
        
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //object value = dataGridView.Columns[e.ColumnIndex].HeaderCell.Value;
            //object value2 = dataGridView.Rows[e.ColumnIndex].HeaderCell.Value;
            //bool clickFlag = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null;
            //if (clickFlag)
            //{
            //    string text = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //    string text2 = text.Substring(0);
            //    bool flag2 = text.Substring(0) == "=";
            //    if (flag2)
            //    {
            //        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.ColumnIndex + e.RowIndex;
            //    }
            //}
        }
    }
}
