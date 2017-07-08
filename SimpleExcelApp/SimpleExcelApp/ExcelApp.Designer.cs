namespace SimpleExcelApp
{
    partial class ExcelApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ColumntextBox = new System.Windows.Forms.TextBox();
            this.RowtextBox = new System.Windows.Forms.TextBox();
            this.Columnlabel = new System.Windows.Forms.Label();
            this.Rowlabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ColumntextBox
            // 
            this.ColumntextBox.Location = new System.Drawing.Point(135, 13);
            this.ColumntextBox.Name = "ColumntextBox";
            this.ColumntextBox.Size = new System.Drawing.Size(100, 20);
            this.ColumntextBox.TabIndex = 0;
            this.ColumntextBox.TextChanged += new System.EventHandler(this.ColumntextBox_TextChanged);
            // 
            // RowtextBox
            // 
            this.RowtextBox.Location = new System.Drawing.Point(135, 39);
            this.RowtextBox.Name = "RowtextBox";
            this.RowtextBox.Size = new System.Drawing.Size(100, 20);
            this.RowtextBox.TabIndex = 1;
            this.RowtextBox.TextChanged += new System.EventHandler(this.RowtextBox_TextChanged);
            // 
            // Columnlabel
            // 
            this.Columnlabel.AutoSize = true;
            this.Columnlabel.Location = new System.Drawing.Point(12, 20);
            this.Columnlabel.Name = "Columnlabel";
            this.Columnlabel.Size = new System.Drawing.Size(98, 13);
            this.Columnlabel.TabIndex = 2;
            this.Columnlabel.Text = "Amount of Columns";
            // 
            // Rowlabel
            // 
            this.Rowlabel.AutoSize = true;
            this.Rowlabel.Location = new System.Drawing.Point(12, 47);
            this.Rowlabel.Name = "Rowlabel";
            this.Rowlabel.Size = new System.Drawing.Size(85, 13);
            this.Rowlabel.TabIndex = 3;
            this.Rowlabel.Text = "Amount of Rows";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 84);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1306, 517);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // ExcelApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 613);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Rowlabel);
            this.Controls.Add(this.Columnlabel);
            this.Controls.Add(this.RowtextBox);
            this.Controls.Add(this.ColumntextBox);
            this.Name = "ExcelApp";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ColumntextBox;
        private System.Windows.Forms.TextBox RowtextBox;
        private System.Windows.Forms.Label Columnlabel;
        private System.Windows.Forms.Label Rowlabel;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

