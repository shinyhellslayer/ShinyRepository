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
        private void RowtextBox_TextChanged(object sender, EventArgs e)
        {
            bool flag = !string.IsNullOrEmpty(this.RowtextBox.Text);
            if (flag)
            {
                this.dataGridView.RowCount = Convert.ToInt32(this.RowtextBox.Text);
                int num = 1;
                while ((long)num <= (long)((ulong)Convert.ToUInt32(this.RowtextBox.Text)))
                {
                    this.dataGridView.Rows[num - 1].HeaderCell.Value = num.ToString();
                    num++;
                }
            }
        }

        private void ColumntextBox_TextChanged(object sender, EventArgs e)
        {
            bool flag = !string.IsNullOrEmpty(this.ColumntextBox.Text);
            if (flag)
            {
                this.dataGridView.ColumnCount = Convert.ToInt32(this.ColumntextBox.Text);
                int num = 0;
                while ((long)num < (long)((ulong)Convert.ToUInt32(this.ColumntextBox.Text)))
                {
                    DataGridViewColumn arg_5A_0 = this.dataGridView.Columns[num];
                    Alphabet.AlphabetEnum alphabetEnum = (Alphabet.AlphabetEnum)num;
                    arg_5A_0.HeaderText = alphabetEnum.ToString();
                    num++;
                }
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool flag = this.dataGridView.Columns[e.ColumnIndex].Name == "Reference";
            if (flag)
            {
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool flag = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null;
            if (flag)
            {
                string text = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                bool flag2 = text.Substring(0, 1) == "=";
                if (flag2)
                {
                    int index = 0;
                    int index2 = 0;
                    Alphabet.AlphabetEnum rowIndex = (Alphabet.AlphabetEnum)e.RowIndex;
                    string[] names = Enum.GetNames(rowIndex.GetType());
                    for (int i = 0; i < names.Length; i++)
                    {
                        bool flag3 = names[i] == text.Substring(1, 1);
                        if (flag3)
                        {
                            index = i;
                        }
                    }
                    int num = Convert.ToInt32(text.Substring(2, 1));
                    string text2 = this.dataGridView.Rows[num - 1].Cells[index].Value.ToString();
                    string value = null;
                    bool flag4 = text.Length > 3;
                    string text3;
                    if (flag4)
                    {
                        text3 = text.Substring(3, 1);
                        for (int j = 0; j < names.Length; j++)
                        {
                            bool flag5 = names[j] == text.Substring(4, 1);
                            if (flag5)
                            {
                                index2 = j;
                            }
                        }
                        int num2 = Convert.ToInt32(text.Substring(5, 1));
                        value = this.dataGridView.Rows[num2 - 1].Cells[index2].Value.ToString();
                    }
                    else
                    {
                        text3 = "default";
                    }
                    string a = text3;
                    if (!(a == "+"))
                    {
                        if (!(a == "-"))
                        {
                            if (!(a == "/"))
                            {
                                if (!(a == "*"))
                                {
                                    this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = text2;
                                }
                                else
                                {
                                    string value2 = this.Multiply(text2, value);
                                    this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value2;
                                }
                            }
                            else
                            {
                                string value2 = this.Devide(text2, value);
                                this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value2;
                            }
                        }
                        else
                        {
                            string value2 = this.Subtract(text2, value);
                            this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value2;
                        }
                    }
                    else
                    {
                        string value2 = this.Add(text2, value);
                        this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value2;
                    }
                }
            }
        }

        public string Add(string value1, string value2)
        {
            return (Convert.ToInt32(value1) + Convert.ToInt32(value2)).ToString();
        }

        public string Subtract(string value1, string value2)
        {
            return (Convert.ToInt32(value1) - Convert.ToInt32(value2)).ToString();
        }

        public string Devide(string value1, string value2)
        {
            return (Convert.ToInt32(value1) / Convert.ToInt32(value2)).ToString();
        }

        public string Multiply(string value1, string value2)
        {
            return (Convert.ToInt32(value1) * Convert.ToInt32(value2)).ToString();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            object value = this.dataGridView.Columns[e.ColumnIndex].HeaderCell.Value;
            object value2 = this.dataGridView.Rows[e.ColumnIndex].HeaderCell.Value;
            bool flag = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null;
            if (flag)
            {
                string text = this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string text2 = text.Substring(0);
                bool flag2 = text.Substring(0) == "=";
                if (flag2)
                {
                    this.dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = e.ColumnIndex + e.RowIndex;
                }
            }
        }
    }
}
