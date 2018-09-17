namespace ServiceHost
{
    partial class HostController
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
            this.btnOpenHost = new System.Windows.Forms.Button();
            this.btnTestWriteIn = new System.Windows.Forms.Button();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenHost
            // 
            this.btnOpenHost.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenHost.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnOpenHost.Location = new System.Drawing.Point(12, 26);
            this.btnOpenHost.Name = "btnOpenHost";
            this.btnOpenHost.Size = new System.Drawing.Size(369, 60);
            this.btnOpenHost.TabIndex = 0;
            this.btnOpenHost.Text = "启动服务";
            this.btnOpenHost.UseVisualStyleBackColor = true;
            this.btnOpenHost.Click += new System.EventHandler(this.btnOpenHost_Click);
            // 
            // btnTestWriteIn
            // 
            this.btnTestWriteIn.Location = new System.Drawing.Point(12, 92);
            this.btnTestWriteIn.Name = "btnTestWriteIn";
            this.btnTestWriteIn.Size = new System.Drawing.Size(369, 30);
            this.btnTestWriteIn.TabIndex = 1;
            this.btnTestWriteIn.Text = "测试";
            this.btnTestWriteIn.UseVisualStyleBackColor = true;
            this.btnTestWriteIn.Click += new System.EventHandler(this.btnTestWriteIn_Click);
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(12, 128);
            this.txtOrder.Multiline = true;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(369, 123);
            this.txtOrder.TabIndex = 2;
            this.txtOrder.Text = "写入测试";
            this.txtOrder.TextChanged += new System.EventHandler(this.txtOrder_TextChanged);
            // 
            // HostController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 263);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.btnTestWriteIn);
            this.Controls.Add(this.btnOpenHost);
            this.Name = "HostController";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenHost;
        private System.Windows.Forms.Button btnTestWriteIn;
        private System.Windows.Forms.TextBox txtOrder;
    }
}

