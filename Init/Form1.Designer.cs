namespace Init
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
            this.InitBtn = new System.Windows.Forms.Button();
            this.HostText = new System.Windows.Forms.TextBox();
            this.PortText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UrlText = new System.Windows.Forms.TextBox();
            this.RestBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InitBtn
            // 
            this.InitBtn.BackColor = System.Drawing.SystemColors.Control;
            this.InitBtn.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitBtn.Location = new System.Drawing.Point(93, 123);
            this.InitBtn.Name = "InitBtn";
            this.InitBtn.Size = new System.Drawing.Size(84, 23);
            this.InitBtn.TabIndex = 0;
            this.InitBtn.Text = "初始化";
            this.InitBtn.UseVisualStyleBackColor = false;
            this.InitBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // HostText
            // 
            this.HostText.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostText.Location = new System.Drawing.Point(93, 47);
            this.HostText.Name = "HostText";
            this.HostText.Size = new System.Drawing.Size(507, 24);
            this.HostText.TabIndex = 1;
            this.HostText.Text = "http://localhost";
            this.HostText.TextChanged += new System.EventHandler(this.HostText_TextChanged);
            // 
            // PortText
            // 
            this.PortText.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortText.Location = new System.Drawing.Point(606, 47);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(51, 24);
            this.PortText.TabIndex = 1;
            this.PortText.Text = "80";
            this.PortText.TextChanged += new System.EventHandler(this.HostText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Url";
            // 
            // UrlText
            // 
            this.UrlText.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlText.Location = new System.Drawing.Point(93, 84);
            this.UrlText.Name = "UrlText";
            this.UrlText.Size = new System.Drawing.Size(564, 24);
            this.UrlText.TabIndex = 3;
            this.UrlText.Text = "http://localhost:80/api/services/cloudApi/manager/UpdateLuaScript";
            // 
            // RestBtn
            // 
            this.RestBtn.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestBtn.Location = new System.Drawing.Point(206, 123);
            this.RestBtn.Name = "RestBtn";
            this.RestBtn.Size = new System.Drawing.Size(84, 23);
            this.RestBtn.TabIndex = 0;
            this.RestBtn.Text = "重置";
            this.RestBtn.UseVisualStyleBackColor = true;
            this.RestBtn.Click += new System.EventHandler(this.RestBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 178);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UrlText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.HostText);
            this.Controls.Add(this.RestBtn);
            this.Controls.Add(this.InitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "脚本初始化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InitBtn;
        private System.Windows.Forms.TextBox HostText;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UrlText;
        private System.Windows.Forms.Button RestBtn;
    }
}

