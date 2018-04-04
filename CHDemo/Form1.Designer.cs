namespace CHDemo
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
            this.Btn1 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Web1 = new System.Windows.Forms.WebBrowser();
            this.Web2 = new System.Windows.Forms.WebBrowser();
            this.Btn1_Back = new System.Windows.Forms.Button();
            this.BtnSentCookie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(0, 0);
            this.Btn1.Margin = new System.Windows.Forms.Padding(4);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(278, 52);
            this.Btn1.TabIndex = 1;
            this.Btn1.Text = "button1";
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // Btn2
            // 
            this.Btn2.Location = new System.Drawing.Point(0, 60);
            this.Btn2.Margin = new System.Windows.Forms.Padding(4);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(278, 50);
            this.Btn2.TabIndex = 2;
            this.Btn2.Text = "button2";
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // Web1
            // 
            this.Web1.Location = new System.Drawing.Point(0, 195);
            this.Web1.Margin = new System.Windows.Forms.Padding(4);
            this.Web1.MinimumSize = new System.Drawing.Size(24, 26);
            this.Web1.Name = "Web1";
            this.Web1.Size = new System.Drawing.Size(978, 668);
            this.Web1.TabIndex = 5;
            this.Web1.Url = new System.Uri("http://www.hzchgz.cn:8082/", System.UriKind.Absolute);
            this.Web1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Web1_DocumentCompleted);
            // 
            // Web2
            // 
            this.Web2.Location = new System.Drawing.Point(1133, 195);
            this.Web2.Margin = new System.Windows.Forms.Padding(4);
            this.Web2.MinimumSize = new System.Drawing.Size(24, 26);
            this.Web2.Name = "Web2";
            this.Web2.Size = new System.Drawing.Size(910, 668);
            this.Web2.TabIndex = 6;
            this.Web2.Url = new System.Uri("http://www.hzchgz.cn:8082/", System.UriKind.Absolute);
            this.Web2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Web2_DocumentCompleted);
            // 
            // Btn1_Back
            // 
            this.Btn1_Back.Location = new System.Drawing.Point(326, 83);
            this.Btn1_Back.Margin = new System.Windows.Forms.Padding(4);
            this.Btn1_Back.Name = "Btn1_Back";
            this.Btn1_Back.Size = new System.Drawing.Size(278, 50);
            this.Btn1_Back.TabIndex = 7;
            this.Btn1_Back.Text = "Web1_Back";
            this.Btn1_Back.UseVisualStyleBackColor = true;
            this.Btn1_Back.Click += new System.EventHandler(this.Btn1_Back_Click);
            // 
            // BtnSentCookie
            // 
            this.BtnSentCookie.Location = new System.Drawing.Point(635, 83);
            this.BtnSentCookie.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSentCookie.Name = "BtnSentCookie";
            this.BtnSentCookie.Size = new System.Drawing.Size(278, 50);
            this.BtnSentCookie.TabIndex = 8;
            this.BtnSentCookie.Text = "SentCookie";
            this.BtnSentCookie.UseVisualStyleBackColor = true;
            this.BtnSentCookie.Click += new System.EventHandler(this.BtnSentCookie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2081, 1214);
            this.Controls.Add(this.BtnSentCookie);
            this.Controls.Add(this.Btn1_Back);
            this.Controls.Add(this.Web2);
            this.Controls.Add(this.Web1);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.WebBrowser Web1;
        private System.Windows.Forms.WebBrowser Web2;
        private System.Windows.Forms.Button Btn1_Back;
        private System.Windows.Forms.Button BtnSentCookie;
    }
}

