
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
            this.btnReadFromSchema = new System.Windows.Forms.Button();
            this.btnReadKeyVault = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxKeyVaultName = new System.Windows.Forms.TextBox();
            this.textBoxSecretName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(12, 114);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.Size = new System.Drawing.Size(813, 290);
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
            this.textBoxResult.Location = new System.Drawing.Point(12, 423);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(813, 108);
            this.textBoxResult.TabIndex = 4;
            // 
            // btnReadFromSchema
            // 
            this.btnReadFromSchema.Location = new System.Drawing.Point(284, 38);
            this.btnReadFromSchema.Name = "btnReadFromSchema";
            this.btnReadFromSchema.Size = new System.Drawing.Size(118, 23);
            this.btnReadFromSchema.TabIndex = 5;
            this.btnReadFromSchema.Text = "Read From Schema";
            this.btnReadFromSchema.UseVisualStyleBackColor = true;
            this.btnReadFromSchema.Click += new System.EventHandler(this.btnReadFromSchema_Click);
            // 
            // btnReadKeyVault
            // 
            this.btnReadKeyVault.Location = new System.Drawing.Point(726, 64);
            this.btnReadKeyVault.Name = "btnReadKeyVault";
            this.btnReadKeyVault.Size = new System.Drawing.Size(99, 23);
            this.btnReadKeyVault.TabIndex = 6;
            this.btnReadKeyVault.Text = "Read Key Vault";
            this.btnReadKeyVault.UseVisualStyleBackColor = true;
            this.btnReadKeyVault.Click += new System.EventHandler(this.btnReadKeyVault_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Key Vault Name:";
            // 
            // textBoxKeyVaultName
            // 
            this.textBoxKeyVaultName.Location = new System.Drawing.Point(576, 39);
            this.textBoxKeyVaultName.Name = "textBoxKeyVaultName";
            this.textBoxKeyVaultName.Size = new System.Drawing.Size(144, 20);
            this.textBoxKeyVaultName.TabIndex = 8;
            // 
            // textBoxSecretName
            // 
            this.textBoxSecretName.Location = new System.Drawing.Point(576, 67);
            this.textBoxSecretName.Name = "textBoxSecretName";
            this.textBoxSecretName.Size = new System.Drawing.Size(144, 20);
            this.textBoxSecretName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Secret Name:";
            // 
            // frmMySQLAzure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 543);
            this.Controls.Add(this.textBoxSecretName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxKeyVaultName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReadKeyVault);
            this.Controls.Add(this.btnReadFromSchema);
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
        private System.Windows.Forms.Button btnReadFromSchema;
        private System.Windows.Forms.Button btnReadKeyVault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxKeyVaultName;
        private System.Windows.Forms.TextBox textBoxSecretName;
        private System.Windows.Forms.Label label2;
    }
}

