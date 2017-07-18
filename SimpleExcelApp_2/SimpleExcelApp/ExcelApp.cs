using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleExcelApp.Model;

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
            MathExpression mathExpression = new MathExpression();
            ExpressionValues expresionValue = new ExpressionValues();
            GridProperty gridProperty = new GridProperty();

            try
            {
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    //Define the Mathematical expressions needed and check the value that wi determine the calculation
                    // mathExpression = math.MathExpression(cell, dataGridView.ColumnCount);

                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.MathExpression(cell, dataGridView.ColumnCount);

                    //Check if a calculation needs to happen
                    //if (mathExpression.mathExpressionSymbol != -1)
                    //{
                    //    gridProperty.column = new int[dataGridView.ColumnCount];
                    //    gridProperty.row = new int[dataGridView.RowCount];
                    //    expresionValue.value = new string[dataGridView.ColumnCount];
                    //    Alphabet.AlphabetEnum rowIndex = (Alphabet.AlphabetEnum)e.RowIndex;
                    //    string[] names = Enum.GetNames(rowIndex.GetType());

                    //    //Check if a cell value is used with the enum provided
                    //    for (int i = 0; i < names.Length; i++)
                    //    {
                    //        if (names[i] == cell.Substring(mathExpression.mathExpressionSymbol + 1, mathExpression.mathExpressionSymbol + 1))
                    //        {
                    //            gridProperty.column[0] = i;
                    //            break;
                    //        }
                    //        else
                    //        {
                    //            gridProperty.column[0] = -1;
                    //        }
                    //    }

                    //    // gridProperty.column = Alphabet.AlphabetLetter(mathExpression, cell,e.RowIndex,0);

                    //    //Check if a cell value is used or if it is a fixed numerical value
                    //    if (gridProperty.column[0] != -1)
                    //    {
                    //        //If a cell value is used use the cell value
                    //        if(mathExpression.mathSymbol[4] != 0)
                    //        {
                    //            gridProperty.row[0] = Convert.ToInt32(cell.Substring(mathExpression.mathExpressionSymbol + 2, mathExpression.mathSymbol[4] - (mathExpression.mathExpressionSymbol + 2)));
                    //            if (dataGridView.Rows[gridProperty.row[0] - 1].Cells[gridProperty.column[0]].Value != null)
                    //            {
                    //                expresionValue.value[0] = dataGridView.Rows[gridProperty.row[0] - 1].Cells[gridProperty.column[0]].Value.ToString();
                    //            }
                    //        }
                    //        else
                    //        {
                    //            gridProperty.row[0] = Convert.ToInt32(cell.Substring(mathExpression.mathExpressionSymbol + 2));
                    //            //gridProperty.column[0] = dataGridView.Rows[gridProperty.row[0] - 1].Cells[gridProperty.column[0]].Value.ToString()
                    //            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView.Rows[gridProperty.row[0]-1].Cells[gridProperty.column[0]].Value.ToString();
                    //        }
                           
                    //    }
                    //    else
                    //    {
                    //        gridProperty.row[0] = Convert.ToInt32(cell.Substring(mathExpression.mathExpressionSymbol + 1, mathExpression.mathSymbol[4] - 1));
                    //        expresionValue.value[0] = gridProperty.row[0].ToString();
                    //    }
                        
                    //    // Check the length of the cell text to make sure it is cell values or some cell values
                    //    if (cell.Length > 3)
                    //    {
                    //        for (int j = 0; j < names.Length; j++)
                    //        {
                    //            if (names[j] == cell.Substring(mathExpression.mathSymbol[4] + 1, 1))
                    //            {
                    //                gridProperty.column[1] = j;
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                gridProperty.column[1] = -1;
                    //            }
                    //        }

                    //        //gridProperty.column = Alphabet.AlphabetLetter(mathExpression, cell, e.RowIndex, 1);

                    //        //Check if a cell value is used or if it is a fixed numerical value
                    //        if (gridProperty.column[1] != -1)
                    //        {
                    //            //If a cell value is used use the cell value
                    //            gridProperty.row[1] = Convert.ToInt32(cell.Substring(mathExpression.mathSymbol[4] + 2));
                    //            if (dataGridView.Rows[gridProperty.row[1] - 1].Cells[gridProperty.column[1]].Value != null)
                    //            {
                    //                expresionValue.value[1] = dataGridView.Rows[gridProperty.row[1] - 1].Cells[gridProperty.column[1]].Value.ToString();
                    //            }
                    //        }
                    //        else
                    //        {
                    //            gridProperty.row[1] = Convert.ToInt32(cell.Substring(mathExpression.mathSymbol[4] + 1));
                    //            expresionValue.value[1] = gridProperty.row[1].ToString();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        mathExpression.mathCalculationSymbol = "default";
                    //    }

                    //    //Switch to call the right Mathermatical Expression
                    //    switch (mathExpression.mathCalculationSymbol)
                    //    {
                    //        case "+":
                    //            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Add(expresionValue);
                    //            break;
                    //        case "-":
                    //            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Subtract(expresionValue);
                    //            break;
                    //        case "*":
                    //            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Multiply(expresionValue);
                    //            break;
                    //        case "/":
                    //            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.Devide(expresionValue);
                    //            break;
                    //        default:
                    //           // dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = expresionValue.value[0];
                    //            break;
                    //    }
                    //}
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
            object value = dataGridView.Columns[e.ColumnIndex].HeaderCell.Value;
            object value2 = dataGridView.Rows[e.ColumnIndex].HeaderCell.Value;

            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string text = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string text2 = text.Substring(0);
                if (text.Substring(0) == "=")
                {
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.ColumnIndex + e.RowIndex;
                }
            }
        }
    }
}
