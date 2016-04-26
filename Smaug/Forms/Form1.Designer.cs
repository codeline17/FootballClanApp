namespace Smaug
{
    partial class frmMain
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
            this.lMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.gdMain = new System.Windows.Forms.DataGridView();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.lMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdMain)).BeginInit();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lMain
            // 
            this.lMain.ColumnCount = 1;
            this.lMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lMain.Controls.Add(this.txtConsole, 0, 2);
            this.lMain.Controls.Add(this.gdMain, 0, 1);
            this.lMain.Controls.Add(this.tsMain, 0, 0);
            this.lMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMain.Location = new System.Drawing.Point(0, 0);
            this.lMain.Name = "lMain";
            this.lMain.RowCount = 3;
            this.lMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.91391F));
            this.lMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.08609F));
            this.lMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.lMain.Size = new System.Drawing.Size(1114, 488);
            this.lMain.TabIndex = 0;
            // 
            // txtConsole
            // 
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Location = new System.Drawing.Point(3, 334);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(1108, 151);
            this.txtConsole.TabIndex = 0;
            // 
            // gdMain
            // 
            this.gdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdMain.Location = new System.Drawing.Point(3, 45);
            this.gdMain.Name = "gdMain";
            this.gdMain.Size = new System.Drawing.Size(1108, 283);
            this.gdMain.TabIndex = 1;
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1114, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 488);
            this.Controls.Add(this.lMain);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.lMain.ResumeLayout(false);
            this.lMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdMain)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel lMain;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.DataGridView gdMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}

