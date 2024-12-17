using System.Collections.Generic;
using System.Windows.Forms;
using static INFINITTechTest.Models.FileReaderModel;

namespace INFINITTechTest
{
    partial class FileReaderView
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.characterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.charListView = new System.Windows.Forms.ListView();
            this.charHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.countHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(248, 439);
            this.treeView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // characterBindingSource
            // 
            this.characterBindingSource.DataSource = typeof(INFINITTechTest.Models.FileReaderModel.CharCount);
            // 
            // charListView
            // 
            this.charListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.charListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.charHeader,
            this.countHeader});
            this.charListView.HideSelection = false;
            this.charListView.Location = new System.Drawing.Point(434, 68);
            this.charListView.Name = "charListView";
            this.charListView.Size = new System.Drawing.Size(237, 383);
            this.charListView.TabIndex = 2;
            this.charListView.UseCompatibleStateImageBehavior = false;
            this.charListView.View = System.Windows.Forms.View.Details;
            // 
            // charHeader
            // 
            this.charHeader.Text = "Character";
            this.charHeader.Width = 87;
            // 
            // countHeader
            // 
            this.countHeader.Text = "Count";
            // 
            // FileReaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.charListView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "FileReaderView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private BindingSource characterBindingSource;
        private DataGridViewTextBoxColumn keysDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valuesDataGridViewTextBoxColumn;
        private ListView charListView;
        private ColumnHeader charHeader;
        private ColumnHeader countHeader;
    }
}

