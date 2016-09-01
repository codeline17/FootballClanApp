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
            this.components = new System.ComponentModel.Container();
            this.lMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.matchGetByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.samwiseDataSet = new Smaug.SamwiseDataSet();
            this.tmrEFixtures = new System.Windows.Forms.Timer(this.components);
            this.matchGetByDateTableAdapter = new Smaug.SamwiseDataSetTableAdapters.MatchGetByDateTableAdapter();
            this.lMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchGetByDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.samwiseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // lMain
            // 
            this.lMain.ColumnCount = 1;
            this.lMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lMain.Controls.Add(this.txtConsole, 0, 2);
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
            // matchGetByDateBindingSource
            // 
            this.matchGetByDateBindingSource.DataMember = "MatchGetByDate";
            this.matchGetByDateBindingSource.DataSource = this.samwiseDataSet;
            // 
            // samwiseDataSet
            // 
            this.samwiseDataSet.DataSetName = "SamwiseDataSet";
            this.samwiseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tmrEFixtures
            // 
            this.tmrEFixtures.Enabled = true;
            this.tmrEFixtures.Interval = 600000;
            this.tmrEFixtures.Tick += new System.EventHandler(this.tmrEFixtures_Tick);
            // 
            // matchGetByDateTableAdapter
            // 
            this.matchGetByDateTableAdapter.ClearBeforeFill = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.matchGetByDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.samwiseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel lMain;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Timer tmrEFixtures;
        private System.Windows.Forms.BindingSource matchGetByDateBindingSource;
        private SamwiseDataSet samwiseDataSet;
        private SamwiseDataSetTableAdapters.MatchGetByDateTableAdapter matchGetByDateTableAdapter;
    }
}

