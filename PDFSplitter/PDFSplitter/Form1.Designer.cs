namespace PDFSplitter
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSelectPDF = new System.Windows.Forms.Label();
            this.textBoxSelectPDF = new System.Windows.Forms.TextBox();
            this.btnSelectPDF = new System.Windows.Forms.Button();
            this.lblSelectSplittingMethod = new System.Windows.Forms.Label();
            this.radioButtonSequential = new System.Windows.Forms.RadioButton();
            this.radioButtonParallel = new System.Windows.Forms.RadioButton();
            this.radioButtonOptimal = new System.Windows.Forms.RadioButton();
            this.lblSelectDestFolder = new System.Windows.Forms.Label();
            this.btnSelectDestFolder = new System.Windows.Forms.Button();
            this.textBoxSelectDestFolder = new System.Windows.Forms.TextBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.richTextBoxSplitResult = new System.Windows.Forms.RichTextBox();
            this.btnResetFields = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanelMain.Controls.Add(this.lblTitle, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.lblSelectPDF, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxSelectPDF, 1, 2);
            this.tableLayoutPanelMain.Controls.Add(this.btnSelectPDF, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.lblSelectSplittingMethod, 1, 3);
            this.tableLayoutPanelMain.Controls.Add(this.radioButtonSequential, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.radioButtonParallel, 1, 5);
            this.tableLayoutPanelMain.Controls.Add(this.radioButtonOptimal, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.lblSelectDestFolder, 1, 7);
            this.tableLayoutPanelMain.Controls.Add(this.btnSelectDestFolder, 2, 8);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxSelectDestFolder, 1, 8);
            this.tableLayoutPanelMain.Controls.Add(this.btnSplit, 1, 9);
            this.tableLayoutPanelMain.Controls.Add(this.richTextBoxSplitResult, 1, 10);
            this.tableLayoutPanelMain.Controls.Add(this.btnResetFields, 1, 11);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 12;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 38.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(243, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(295, 59);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "PDFSplitter";
            // 
            // lblSelectPDF
            // 
            this.lblSelectPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectPDF.AutoSize = true;
            this.lblSelectPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPDF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectPDF.Location = new System.Drawing.Point(112, 95);
            this.lblSelectPDF.Name = "lblSelectPDF";
            this.lblSelectPDF.Size = new System.Drawing.Size(120, 16);
            this.lblSelectPDF.TabIndex = 3;
            this.lblSelectPDF.Text = "Select PDF File:";
            // 
            // textBoxSelectPDF
            // 
            this.textBoxSelectPDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectPDF.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxSelectPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSelectPDF.Location = new System.Drawing.Point(112, 114);
            this.textBoxSelectPDF.Name = "textBoxSelectPDF";
            this.textBoxSelectPDF.ShortcutsEnabled = false;
            this.textBoxSelectPDF.Size = new System.Drawing.Size(495, 24);
            this.textBoxSelectPDF.TabIndex = 4;
            // 
            // btnSelectPDF
            // 
            this.btnSelectPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectPDF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectPDF.Location = new System.Drawing.Point(613, 114);
            this.btnSelectPDF.Name = "btnSelectPDF";
            this.btnSelectPDF.Size = new System.Drawing.Size(56, 24);
            this.btnSelectPDF.TabIndex = 0;
            this.btnSelectPDF.Text = "Browse";
            this.btnSelectPDF.UseVisualStyleBackColor = true;
            this.btnSelectPDF.Click += new System.EventHandler(this.btnSelectPDF_Click);
            // 
            // lblSelectSplittingMethod
            // 
            this.lblSelectSplittingMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectSplittingMethod.AutoSize = true;
            this.lblSelectSplittingMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSplittingMethod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectSplittingMethod.Location = new System.Drawing.Point(112, 161);
            this.lblSelectSplittingMethod.Name = "lblSelectSplittingMethod";
            this.lblSelectSplittingMethod.Size = new System.Drawing.Size(169, 16);
            this.lblSelectSplittingMethod.TabIndex = 1;
            this.lblSelectSplittingMethod.Text = "Select splitting method:";
            // 
            // radioButtonSequential
            // 
            this.radioButtonSequential.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonSequential.AutoSize = true;
            this.radioButtonSequential.Checked = true;
            this.radioButtonSequential.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSequential.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonSequential.Location = new System.Drawing.Point(112, 184);
            this.radioButtonSequential.Name = "radioButtonSequential";
            this.radioButtonSequential.Size = new System.Drawing.Size(129, 19);
            this.radioButtonSequential.TabIndex = 7;
            this.radioButtonSequential.TabStop = true;
            this.radioButtonSequential.Text = "Sequential method";
            this.radioButtonSequential.UseVisualStyleBackColor = true;
            // 
            // radioButtonParallel
            // 
            this.radioButtonParallel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonParallel.AutoSize = true;
            this.radioButtonParallel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonParallel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonParallel.Location = new System.Drawing.Point(112, 217);
            this.radioButtonParallel.Name = "radioButtonParallel";
            this.radioButtonParallel.Size = new System.Drawing.Size(112, 19);
            this.radioButtonParallel.TabIndex = 8;
            this.radioButtonParallel.Text = "Parallel method";
            this.radioButtonParallel.UseVisualStyleBackColor = true;
            // 
            // radioButtonOptimal
            // 
            this.radioButtonOptimal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButtonOptimal.AutoSize = true;
            this.radioButtonOptimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOptimal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonOptimal.Location = new System.Drawing.Point(112, 250);
            this.radioButtonOptimal.Name = "radioButtonOptimal";
            this.radioButtonOptimal.Size = new System.Drawing.Size(113, 19);
            this.radioButtonOptimal.TabIndex = 9;
            this.radioButtonOptimal.Text = "Optimal method";
            this.radioButtonOptimal.UseVisualStyleBackColor = true;
            // 
            // lblSelectDestFolder
            // 
            this.lblSelectDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelectDestFolder.AutoSize = true;
            this.lblSelectDestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDestFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectDestFolder.Location = new System.Drawing.Point(112, 293);
            this.lblSelectDestFolder.Name = "lblSelectDestFolder";
            this.lblSelectDestFolder.Size = new System.Drawing.Size(176, 16);
            this.lblSelectDestFolder.TabIndex = 10;
            this.lblSelectDestFolder.Text = "Select destinaton folder:";
            // 
            // btnSelectDestFolder
            // 
            this.btnSelectDestFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectDestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDestFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectDestFolder.Location = new System.Drawing.Point(613, 312);
            this.btnSelectDestFolder.Name = "btnSelectDestFolder";
            this.btnSelectDestFolder.Size = new System.Drawing.Size(56, 24);
            this.btnSelectDestFolder.TabIndex = 2;
            this.btnSelectDestFolder.Text = "Browse";
            this.btnSelectDestFolder.UseVisualStyleBackColor = true;
            this.btnSelectDestFolder.Click += new System.EventHandler(this.btnSelectDestFolder_Click);
            // 
            // textBoxSelectDestFolder
            // 
            this.textBoxSelectDestFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectDestFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSelectDestFolder.Location = new System.Drawing.Point(112, 312);
            this.textBoxSelectDestFolder.Name = "textBoxSelectDestFolder";
            this.textBoxSelectDestFolder.Size = new System.Drawing.Size(495, 24);
            this.textBoxSelectDestFolder.TabIndex = 12;
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMain.SetColumnSpan(this.btnSplit, 2);
            this.btnSplit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSplit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSplit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSplit.Location = new System.Drawing.Point(330, 352);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(120, 36);
            this.btnSplit.TabIndex = 3;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // richTextBoxSplitResult
            // 
            this.richTextBoxSplitResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.richTextBoxSplitResult, 2);
            this.richTextBoxSplitResult.Location = new System.Drawing.Point(112, 401);
            this.richTextBoxSplitResult.Name = "richTextBoxSplitResult";
            this.richTextBoxSplitResult.ReadOnly = true;
            this.richTextBoxSplitResult.Size = new System.Drawing.Size(557, 64);
            this.richTextBoxSplitResult.TabIndex = 14;
            this.richTextBoxSplitResult.Text = "Split Result:";
            // 
            // btnResetFields
            // 
            this.btnResetFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.btnResetFields, 2);
            this.btnResetFields.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFields.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnResetFields.Location = new System.Drawing.Point(586, 479);
            this.btnResetFields.Name = "btnResetFields";
            this.btnResetFields.Size = new System.Drawing.Size(83, 28);
            this.btnResetFields.TabIndex = 4;
            this.btnResetFields.Text = "Reset fields";
            this.btnResetFields.UseVisualStyleBackColor = true;
            this.btnResetFields.Click += new System.EventHandler(this.btnResetFields_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1280, 960);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDFSplitter";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectPDF;
        private System.Windows.Forms.TextBox textBoxSelectPDF;
        private System.Windows.Forms.Button btnSelectPDF;
        private System.Windows.Forms.Label lblSelectSplittingMethod;
        private System.Windows.Forms.RadioButton radioButtonSequential;
        private System.Windows.Forms.RadioButton radioButtonParallel;
        private System.Windows.Forms.RadioButton radioButtonOptimal;
        private System.Windows.Forms.Label lblSelectDestFolder;
        private System.Windows.Forms.Button btnSelectDestFolder;
        private System.Windows.Forms.TextBox textBoxSelectDestFolder;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.RichTextBox richTextBoxSplitResult;
        private System.Windows.Forms.Button btnResetFields;
    }
}

