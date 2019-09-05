namespace ImageCompress
{
    partial class Form1
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
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartCompress = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnStopCompress = new System.Windows.Forms.Button();
            this.txtNewPath = new System.Windows.Forms.TextBox();
            this.btnSelectNewPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbOutText = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMemory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(196, 10);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 0;
            this.btnSelectPath.Text = "浏览";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(54, 11);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(136, 21);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "F:\\images";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "路径：";
            // 
            // btnStartCompress
            // 
            this.btnStartCompress.Location = new System.Drawing.Point(662, 10);
            this.btnStartCompress.Name = "btnStartCompress";
            this.btnStartCompress.Size = new System.Drawing.Size(75, 23);
            this.btnStartCompress.TabIndex = 3;
            this.btnStartCompress.Text = "开始压缩";
            this.btnStartCompress.UseVisualStyleBackColor = true;
            this.btnStartCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "清晰度：";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(634, 11);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(22, 21);
            this.txtLevel.TabIndex = 6;
            this.txtLevel.Text = "3";
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.Control;
            this.lblResult.Location = new System.Drawing.Point(13, 599);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(977, 77);
            this.lblResult.TabIndex = 8;
            // 
            // btnStopCompress
            // 
            this.btnStopCompress.Location = new System.Drawing.Point(743, 10);
            this.btnStopCompress.Name = "btnStopCompress";
            this.btnStopCompress.Size = new System.Drawing.Size(75, 23);
            this.btnStopCompress.TabIndex = 9;
            this.btnStopCompress.Text = "停止压缩";
            this.btnStopCompress.UseVisualStyleBackColor = true;
            this.btnStopCompress.Click += new System.EventHandler(this.btnStopCompress_Click);
            // 
            // txtNewPath
            // 
            this.txtNewPath.Location = new System.Drawing.Point(364, 11);
            this.txtNewPath.Name = "txtNewPath";
            this.txtNewPath.Size = new System.Drawing.Size(136, 21);
            this.txtNewPath.TabIndex = 11;
            this.txtNewPath.Text = "F:\\images\\压缩后";
            // 
            // btnSelectNewPath
            // 
            this.btnSelectNewPath.Location = new System.Drawing.Point(506, 10);
            this.btnSelectNewPath.Name = "btnSelectNewPath";
            this.btnSelectNewPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNewPath.TabIndex = 10;
            this.btnSelectNewPath.Text = "浏览";
            this.btnSelectNewPath.UseVisualStyleBackColor = true;
            this.btnSelectNewPath.Click += new System.EventHandler(this.btnSelectNewPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "压缩临时路径：";
            // 
            // lbOutText
            // 
            this.lbOutText.FormattingEnabled = true;
            this.lbOutText.ItemHeight = 12;
            this.lbOutText.Location = new System.Drawing.Point(12, 39);
            this.lbOutText.Name = "lbOutText";
            this.lbOutText.Size = new System.Drawing.Size(1048, 544);
            this.lbOutText.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(824, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "一波张数：";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(885, 11);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(56, 21);
            this.txtCount.TabIndex = 15;
            this.txtCount.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(946, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "筛选内存：";
            // 
            // txtMemory
            // 
            this.txtMemory.Location = new System.Drawing.Point(1005, 10);
            this.txtMemory.Name = "txtMemory";
            this.txtMemory.Size = new System.Drawing.Size(27, 21);
            this.txtMemory.TabIndex = 17;
            this.txtMemory.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1039, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "M";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 685);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMemory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbOutText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewPath);
            this.Controls.Add(this.btnSelectNewPath);
            this.Controls.Add(this.btnStopCompress);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStartCompress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSelectPath);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片压缩";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartCompress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnStopCompress;
        private System.Windows.Forms.TextBox txtNewPath;
        private System.Windows.Forms.Button btnSelectNewPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbOutText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMemory;
        private System.Windows.Forms.Label label6;
    }
}

