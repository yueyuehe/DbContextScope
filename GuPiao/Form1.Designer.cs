namespace GuPiao
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
            this.fileInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_FileUpload = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.txt_DateStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DateEnd = new System.Windows.Forms.TextBox();
            this.txt_itemAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SY = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.Label();
            this.Txt_SYL = new System.Windows.Forms.Label();
            this.txt_CB = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btn_compute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileInput
            // 
            this.fileInput.Location = new System.Drawing.Point(60, 12);
            this.fileInput.Name = "fileInput";
            this.fileInput.Size = new System.Drawing.Size(100, 21);
            this.fileInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件";
            // 
            // btn_FileUpload
            // 
            this.btn_FileUpload.Location = new System.Drawing.Point(166, 39);
            this.btn_FileUpload.Name = "btn_FileUpload";
            this.btn_FileUpload.Size = new System.Drawing.Size(75, 23);
            this.btn_FileUpload.TabIndex = 2;
            this.btn_FileUpload.Text = "上传";
            this.btn_FileUpload.UseVisualStyleBackColor = true;
            this.btn_FileUpload.Click += new System.EventHandler(this.btn_FileUpload_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(166, 10);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 3;
            this.btn_select.Text = "选择";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // txt_DateStart
            // 
            this.txt_DateStart.Location = new System.Drawing.Point(60, 119);
            this.txt_DateStart.Name = "txt_DateStart";
            this.txt_DateStart.Size = new System.Drawing.Size(100, 21);
            this.txt_DateStart.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "开始";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "结束";
            // 
            // txt_DateEnd
            // 
            this.txt_DateEnd.Location = new System.Drawing.Point(60, 146);
            this.txt_DateEnd.Name = "txt_DateEnd";
            this.txt_DateEnd.Size = new System.Drawing.Size(100, 21);
            this.txt_DateEnd.TabIndex = 7;
            // 
            // txt_itemAmount
            // 
            this.txt_itemAmount.Location = new System.Drawing.Point(310, 119);
            this.txt_itemAmount.Name = "txt_itemAmount";
            this.txt_itemAmount.Size = new System.Drawing.Size(100, 21);
            this.txt_itemAmount.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "定投金额";
            // 
            // txt_SY
            // 
            this.txt_SY.AutoSize = true;
            this.txt_SY.Location = new System.Drawing.Point(107, 273);
            this.txt_SY.Name = "txt_SY";
            this.txt_SY.Size = new System.Drawing.Size(53, 12);
            this.txt_SY.TabIndex = 10;
            this.txt_SY.Text = "收益金额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "成本金额";
            // 
            // txt_Total
            // 
            this.txt_Total.AutoSize = true;
            this.txt_Total.Location = new System.Drawing.Point(107, 249);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(41, 12);
            this.txt_Total.TabIndex = 12;
            this.txt_Total.Text = "总金额";
            // 
            // Txt_SYL
            // 
            this.Txt_SYL.AutoSize = true;
            this.Txt_SYL.Location = new System.Drawing.Point(107, 300);
            this.Txt_SYL.Name = "Txt_SYL";
            this.Txt_SYL.Size = new System.Drawing.Size(41, 12);
            this.Txt_SYL.TabIndex = 13;
            this.Txt_SYL.Text = "收益率";
            // 
            // txt_CB
            // 
            this.txt_CB.Location = new System.Drawing.Point(215, 219);
            this.txt_CB.Name = "txt_CB";
            this.txt_CB.Size = new System.Drawing.Size(195, 21);
            this.txt_CB.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(215, 246);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 21);
            this.textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(215, 270);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 21);
            this.textBox4.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(215, 297);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(195, 21);
            this.textBox5.TabIndex = 17;
            // 
            // btn_compute
            // 
            this.btn_compute.Location = new System.Drawing.Point(415, 151);
            this.btn_compute.Name = "btn_compute";
            this.btn_compute.Size = new System.Drawing.Size(75, 23);
            this.btn_compute.TabIndex = 18;
            this.btn_compute.Text = "计算";
            this.btn_compute.UseVisualStyleBackColor = true;
            this.btn_compute.Click += new System.EventHandler(this.btn_compute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 350);
            this.Controls.Add(this.btn_compute);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txt_CB);
            this.Controls.Add(this.Txt_SYL);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_SY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_itemAmount);
            this.Controls.Add(this.txt_DateEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_DateStart);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_FileUpload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_FileUpload;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.TextBox txt_DateStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DateEnd;
        private System.Windows.Forms.TextBox txt_itemAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_SY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txt_Total;
        private System.Windows.Forms.Label Txt_SYL;
        private System.Windows.Forms.TextBox txt_CB;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btn_compute;
    }
}

