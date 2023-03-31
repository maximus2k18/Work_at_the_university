
namespace OTKRbITKA
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new OTKRbITKA.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testDBDataSet = new OTKRbITKA.TestDBDataSet();
            this.testDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bydjetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bydjetTableAdapter = new OTKRbITKA.TestDBDataSetTableAdapters.BydjetTableAdapter();
            this.dataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.расходыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.прибыльDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наЧтоПотратилDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.результатDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bydjetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.расходыDataGridViewTextBoxColumn,
            this.прибыльDataGridViewTextBoxColumn,
            this.наЧтоПотратилDataGridViewTextBoxColumn,
            this.результатDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bydjetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1390, 490);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // testDBDataSet
            // 
            this.testDBDataSet.DataSetName = "TestDBDataSet";
            this.testDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testDBDataSetBindingSource
            // 
            this.testDBDataSetBindingSource.DataSource = this.testDBDataSet;
            this.testDBDataSetBindingSource.Position = 0;
            // 
            // bydjetBindingSource
            // 
            this.bydjetBindingSource.DataMember = "Bydjet";
            this.bydjetBindingSource.DataSource = this.testDBDataSetBindingSource;
            // 
            // bydjetTableAdapter
            // 
            this.bydjetTableAdapter.ClearBeforeFill = true;
            // 
            // dataSet1BindingSource1
            // 
            this.dataSet1BindingSource1.DataSource = this.dataSet1;
            this.dataSet1BindingSource1.Position = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.Width = 150;
            // 
            // расходыDataGridViewTextBoxColumn
            // 
            this.расходыDataGridViewTextBoxColumn.DataPropertyName = "Расходы";
            this.расходыDataGridViewTextBoxColumn.HeaderText = "Расходы";
            this.расходыDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.расходыDataGridViewTextBoxColumn.Name = "расходыDataGridViewTextBoxColumn";
            this.расходыDataGridViewTextBoxColumn.Width = 150;
            // 
            // прибыльDataGridViewTextBoxColumn
            // 
            this.прибыльDataGridViewTextBoxColumn.DataPropertyName = "Прибыль";
            this.прибыльDataGridViewTextBoxColumn.HeaderText = "Прибыль";
            this.прибыльDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.прибыльDataGridViewTextBoxColumn.Name = "прибыльDataGridViewTextBoxColumn";
            this.прибыльDataGridViewTextBoxColumn.Width = 150;
            // 
            // наЧтоПотратилDataGridViewTextBoxColumn
            // 
            this.наЧтоПотратилDataGridViewTextBoxColumn.DataPropertyName = "На что потратил?";
            this.наЧтоПотратилDataGridViewTextBoxColumn.HeaderText = "На что потратил?";
            this.наЧтоПотратилDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.наЧтоПотратилDataGridViewTextBoxColumn.Name = "наЧтоПотратилDataGridViewTextBoxColumn";
            this.наЧтоПотратилDataGridViewTextBoxColumn.Width = 150;
            // 
            // результатDataGridViewTextBoxColumn
            // 
            this.результатDataGridViewTextBoxColumn.DataPropertyName = "Результат";
            this.результатDataGridViewTextBoxColumn.HeaderText = "Результат";
            this.результатDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.результатDataGridViewTextBoxColumn.Name = "результатDataGridViewTextBoxColumn";
            this.результатDataGridViewTextBoxColumn.Width = 150;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 516);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bydjetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource testDBDataSetBindingSource;
        private TestDBDataSet testDBDataSet;
        private System.Windows.Forms.BindingSource bydjetBindingSource;
        private TestDBDataSetTableAdapters.BydjetTableAdapter bydjetTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn расходыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn прибыльDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наЧтоПотратилDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn результатDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataSet1BindingSource1;
    }
}