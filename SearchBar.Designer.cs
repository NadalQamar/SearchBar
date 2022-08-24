using System;
using System.Windows.Forms;
using System.Drawing;

namespace SearchBar
{
    partial class SearchBar
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
            this.searchLabel = new Label();
            this.searchBox = new TextBox();
            this.searchEngineSelector = new ComboBox();
            this.SuspendLayout();
            // 
            // searchLabel
            // 
            this.searchLabel.Font = new Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.Location = new Point(2, 2);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new Size(387, 25);
            this.searchLabel.TabIndex = 3;
            this.searchLabel.Text = "Enter your query and then press enter: ";
            // 
            // searchBox
            // 
            this.searchBox.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new Point(20, 32);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new Size(427, 26);
            this.searchBox.TabIndex = 1;
            this.searchBox.KeyDown += new KeyEventHandler(this.SearchBox_PressEnter);
            // 
            // searchEngineSelector
            // 
            this.searchEngineSelector.FormattingEnabled = true;
            this.searchEngineSelector.Items.AddRange(new object[] {
            "Google",
            "Bing"});
            this.searchEngineSelector.Location = new Point(20, 60);
            this.searchEngineSelector.Name = "searchEngineSelector";
            this.searchEngineSelector.Size = new Size(137, 21);
            this.searchEngineSelector.TabIndex = 2;
            // 
            // SearchBar
            // 
            this.ClientSize = new Size(454, 91);
            this.Controls.Add(this.searchEngineSelector);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchLabel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 504, Screen.PrimaryScreen.Bounds.Height - 141);
            this.TopMost = true;
            this.Load += new EventHandler(this.SearchBar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label searchLabel;
        private TextBox searchBox;
        private ComboBox searchEngineSelector;
    }
}