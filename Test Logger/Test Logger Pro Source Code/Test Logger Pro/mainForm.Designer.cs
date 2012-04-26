namespace Test_Logger_Pro
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
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.windowDumpButton = new System.Windows.Forms.Button();
            this.fileDumpButton = new System.Windows.Forms.Button();
            this.inputLabel = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.outputBox = new System.Windows.Forms.ListBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.chooseOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveFile
            // 
            this.saveFile.FileName = "output.txt";
            this.saveFile.Filter = "Text Files | *.txt";
            // 
            // windowDumpButton
            // 
            this.windowDumpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.windowDumpButton.Location = new System.Drawing.Point(9, 280);
            this.windowDumpButton.Name = "windowDumpButton";
            this.windowDumpButton.Size = new System.Drawing.Size(264, 23);
            this.windowDumpButton.TabIndex = 0;
            this.windowDumpButton.Text = "Dump to Window";
            this.windowDumpButton.UseVisualStyleBackColor = true;
            this.windowDumpButton.Click += new System.EventHandler(this.windowDumpButton_Click);
            // 
            // fileDumpButton
            // 
            this.fileDumpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileDumpButton.Location = new System.Drawing.Point(147, 312);
            this.fileDumpButton.Name = "fileDumpButton";
            this.fileDumpButton.Size = new System.Drawing.Size(128, 23);
            this.fileDumpButton.TabIndex = 1;
            this.fileDumpButton.Text = "Dump to File";
            this.fileDumpButton.UseVisualStyleBackColor = true;
            this.fileDumpButton.Click += new System.EventHandler(this.fileDumpButton_Click);
            // 
            // inputLabel
            // 
            this.inputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(8, 8);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(34, 13);
            this.inputLabel.TabIndex = 2;
            this.inputLabel.Text = "Input:";
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBox.Location = new System.Drawing.Point(10, 24);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(264, 20);
            this.inputBox.TabIndex = 3;
            // 
            // outputBox
            // 
            this.outputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBox.FormattingEnabled = true;
            this.outputBox.HorizontalScrollbar = true;
            this.outputBox.Location = new System.Drawing.Point(10, 64);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(264, 212);
            this.outputBox.TabIndex = 4;
            // 
            // outputLabel
            // 
            this.outputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(8, 48);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(42, 13);
            this.outputLabel.TabIndex = 5;
            this.outputLabel.Text = "Output:";
            // 
            // chooseOutput
            // 
            this.chooseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseOutput.Location = new System.Drawing.Point(9, 312);
            this.chooseOutput.Name = "chooseOutput";
            this.chooseOutput.Size = new System.Drawing.Size(128, 23);
            this.chooseOutput.TabIndex = 7;
            this.chooseOutput.Text = "Choose Output File";
            this.chooseOutput.UseVisualStyleBackColor = true;
            this.chooseOutput.Click += new System.EventHandler(this.chooseOutput_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.chooseOutput);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.fileDumpButton);
            this.Controls.Add(this.windowDumpButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 380);
            this.Name = "mainForm";
            this.Text = "Test Logger Pro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button windowDumpButton;
        private System.Windows.Forms.Button fileDumpButton;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.ListBox outputBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button chooseOutput;
    }
}

