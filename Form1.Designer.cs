﻿namespace 打飞机游戏
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerBG = new System.Windows.Forms.Timer(this.components);
            this.DiJiFollow = new System.Windows.Forms.Timer(this.components);
            this.JudgeFJ = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerBG
            // 
            this.timerBG.Enabled = true;
            this.timerBG.Interval = 50;
            this.timerBG.Tick += new System.EventHandler(this.timerBG_Tick);
            // 
            // DiJiFollow
            // 
            this.DiJiFollow.Enabled = true;
            this.DiJiFollow.Interval = 50;
            this.DiJiFollow.Tick += new System.EventHandler(this.DiJiFollow_Tick);
            // 
            // JudgeFJ
            // 
            this.JudgeFJ.Enabled = true;
            this.JudgeFJ.Interval = 10;
            this.JudgeFJ.Tick += new System.EventHandler(this.JudgeFJ_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 733);
            this.MaximumSize = new System.Drawing.Size(480, 772);
            this.MinimumSize = new System.Drawing.Size(480, 726);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerBG;
        private System.Windows.Forms.Timer DiJiFollow;
        private System.Windows.Forms.Timer JudgeFJ;
    }
}

