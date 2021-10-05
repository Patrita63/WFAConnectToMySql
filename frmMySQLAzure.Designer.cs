
namespace WFAConnectToMySql
{
    partial class frmMySQLAzure
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
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.labelDGVResult = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.btnReadGuest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(12, 114);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.Size = new System.Drawing.Size(776, 246);
            this.dataGridViewResult.TabIndex = 0;
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(13, 39);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTable.TabIndex = 1;
            this.btnCreateTable.Text = "Create Table";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(151, 38);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(75, 23);
            this.btnReadData.TabIndex = 2;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // labelDGVResult
            // 
            this.labelDGVResult.AutoSize = true;
            this.labelDGVResult.Location = new System.Drawing.Point(13, 98);
            this.labelDGVResult.Name = "labelDGVResult";
            this.labelDGVResult.Size = new System.Drawing.Size(35, 13);
            this.labelDGVResult.TabIndex = 3;
            this.labelDGVResult.Text = "label1";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(16, 376);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(772, 108);
            this.textBoxResult.TabIndex = 4;
            // 
            // btnReadGuest
            // 
            this.btnReadGuest.Location = new System.Drawing.Point(284, 38);
            this.btnReadGuest.Name = "btnReadGuest";
            this.btnReadGuest.Size = new System.Drawing.Size(118, 23);
            this.btnReadGuest.TabIndex = 5;
            this.btnReadGuest.Text = "Read From Guest";
            this.btnReadGuest.UseVisualStyleBackColor = true;
            this.btnReadGuest.Click += new System.EventHandler(this.btnReadGuest_Click);
            // 
            // frmMySQLAzure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.btnReadGuest);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.labelDGVResult);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.dataGridViewResult);
            this.Name = "frmMySQLAzure";
            this.Text = "MYSQL AZURE";
            this.Load += new System.EventHandler(this.frmMySQLAzure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Label labelDGVResult;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button btnReadGuest;
    }
}

