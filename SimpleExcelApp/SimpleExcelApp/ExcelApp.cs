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
using System.Text.RegularExpressions;

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
                        //adjust the amount of rows needed for the sheet
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
                        //adjust the amount of columns needed for the sheet
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
            gridProperty.column = new int[dataGridView.ColumnCount];
            gridProperty.row = new int[dataGridView.RowCount];

            try
            {
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    //get info from cell to string for manupilation
                    string cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    //check if the string is null or empty
                    if (!string.IsNullOrEmpty(cell))
                    {
                        //Check if single value needs to be written or calculation needs to follow
                        if (cell.Substring(0, 1) == "=")
                        {
                            var letterNumberLocation = Regex.Matches(cell, @"[a-zA-Z]{0,1}\d{0,3}");

                            //check if a value needs to be copied or if calculation needs to happen
                            if (letterNumberLocation.Count < 4)
                            {
                                cell = cell.Substring(1);
                                Alphabet.AlphabetEnum rowIndex = (Alphabet.AlphabetEnum)e.RowIndex;
                                string[] names = Enum.GetNames(rowIndex.GetType());
                                // Check if a cell value is used with the enum provided
                                for (int i = 0; i < names.Length; i++)
                                {
                                    if (names[i] == cell.Substring(0, 1))
                                    {
                                        //copy the value found to the new column
                                        gridProperty.column[i] = i;
                                        gridProperty.row[i] = Convert.ToInt32(cell.Substring(1));
                                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView.Rows[gridProperty.row[gridProperty.row[i]]].Cells[gridProperty.column[gridProperty.column[i]]].Value.ToString();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                int count = 0;
                                expresionValue.value = new string[dataGridView.ColumnCount];
                                //Define the Mathematical expressions needed and check the value that wi determine the calculation
                                cell = cell.Substring(1);
                                string newCell = null;

                                //Regex ecpressions to get the row and column values for string munipilation
                                bool errorCounter = Regex.IsMatch(cell, @"[a-zA-Z]");
                                var letterLocation = Regex.Matches(cell, @"[a-zA-Z]{0,1}");
                                //var letterNumberLocation = Regex.Matches(cell, @"[a-zA-Z]{0,1}\d{0,3}");
                                var numberLocation = Regex.Matches(cell, @"\d{0,3}");
                                int numberCount = Regex.Matches(cell, @"\d{1,3}").Count;
                                //check if Alpabetical symbols are available
                                if (false != errorCounter)
                                {
                                    for (int g = 0; g < numberLocation.Count; g++)
                                    {
                                        if (!string.IsNullOrEmpty(numberLocation[g].ToString()))
                                        {
                                            Alphabet.AlphabetEnum rowIndex = (Alphabet.AlphabetEnum)e.RowIndex;
                                            string[] names = Enum.GetNames(rowIndex.GetType());
                                            // Check if a cell value is used with the enum provided
                                            for (int i = 0; i < names.Length; i++)
                                            {
                                                if (g == 0)
                                                {
                                                    //Check the first value that comes in 
                                                    if (names[i] == letterLocation[g].ToString())
                                                    {
                                                        //use the alphabet value to determine the numerical value on where to find the value 
                                                        gridProperty.column[count] = i;
                                                        gridProperty.row[count] = Convert.ToInt32(cell.Substring(numberLocation[g].Index, numberLocation[g].Length));
                                                        expresionValue.value[count] = dataGridView.Rows[gridProperty.row[g] - 1].Cells[gridProperty.column[g]].Value.ToString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        //if it does not have a aphabetical value wright it straigt into the array 
                                                        expresionValue.value[count] = numberLocation[g].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    // calculate and manipulate the rest of the values from 1 up
                                                    if (names[i] == letterLocation[g - 1].ToString())
                                                    {
                                                        gridProperty.column[count] = i;
                                                        gridProperty.row[count] = Convert.ToInt32(cell.Substring(numberLocation[g].Index, numberLocation[g].Length));
                                                        expresionValue.value[count] = dataGridView.Rows[gridProperty.row[count] - 1].Cells[gridProperty.column[count]].Value.ToString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        expresionValue.value[count] = numberLocation[g].ToString();
                                                    }
                                                }


                                            }
                                            //create the new string from the values collected from the cell to do the calculations
                                            if (count == 0)
                                            {
                                                newCell = expresionValue.value[count] + cell.Substring(numberLocation[g].Index + numberLocation[g].Length, 1);
                                            }
                                            else
                                            {

                                                if (numberCount - 1 == count)
                                                {
                                                    newCell = newCell + expresionValue.value[count];
                                                }
                                                else
                                                {
                                                    newCell = newCell + expresionValue.value[count] + cell.Substring(numberLocation[g].Index + numberLocation[g].Length, 1);
                                                }
                                            }

                                            count++;
                                        }
                                    }

                                }
                                else
                                {
                                    newCell = cell;
                                }
                                //pass the new string with the values to the calculation method
                                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = math.MathExpression("=" + newCell, 1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // exception Given in pop up box
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
                    //dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.ColumnIndex + e.RowIndex;
                }
            }
        }
    }
}
