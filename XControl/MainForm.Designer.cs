namespace XControl
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblBoardStatus = new System.Windows.Forms.Label();
            this.tbPortNum = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblDigitResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBoardStatus
            // 
            this.lblBoardStatus.AutoSize = true;
            this.lblBoardStatus.Location = new System.Drawing.Point(185, 243);
            this.lblBoardStatus.Name = "lblBoardStatus";
            this.lblBoardStatus.Size = new System.Drawing.Size(35, 13);
            this.lblBoardStatus.TabIndex = 0;
            this.lblBoardStatus.Text = "NULL";
            // 
            // tbPortNum
            // 
            this.tbPortNum.Location = new System.Drawing.Point(33, 62);
            this.tbPortNum.Name = "tbPortNum";
            this.tbPortNum.Size = new System.Drawing.Size(100, 20);
            this.tbPortNum.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(145, 62);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblDigitResult
            // 
            this.lblDigitResult.AutoSize = true;
            this.lblDigitResult.Location = new System.Drawing.Point(238, 67);
            this.lblDigitResult.Name = "lblDigitResult";
            this.lblDigitResult.Size = new System.Drawing.Size(35, 13);
            this.lblDigitResult.TabIndex = 3;
            this.lblDigitResult.Text = "NULL";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 312);
            this.Controls.Add(this.lblDigitResult);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.tbPortNum);
            this.Controls.Add(this.lblBoardStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "XControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBoardStatus;
        private System.Windows.Forms.TextBox tbPortNum;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblDigitResult;
    }
}

