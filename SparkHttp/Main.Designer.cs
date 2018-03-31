namespace SparkHttp
{
    partial class SparkHttp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SparkHttp));
            this.requestTextBox = new System.Windows.Forms.RichTextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.requestGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.sparkHttpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Type = new System.Windows.Forms.DataGridViewImageColumn();
            this.TargetAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sparkHttpBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // requestTextBox
            // 
            this.requestTextBox.Location = new System.Drawing.Point(257, 28);
            this.requestTextBox.Name = "requestTextBox";
            this.requestTextBox.Size = new System.Drawing.Size(700, 461);
            this.requestTextBox.TabIndex = 0;
            this.requestTextBox.Text = "";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.requestGridView);
            this.mainPanel.Controls.Add(this.saveButton);
            this.mainPanel.Controls.Add(this.sendButton);
            this.mainPanel.Controls.Add(this.requestTextBox);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(960, 537);
            this.mainPanel.TabIndex = 1;
            // 
            // requestGridView
            // 
            this.requestGridView.AllowUserToAddRows = false;
            this.requestGridView.AllowUserToDeleteRows = false;
            this.requestGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.TargetAddress});
            this.requestGridView.Location = new System.Drawing.Point(3, 3);
            this.requestGridView.Name = "requestGridView";
            this.requestGridView.ReadOnly = true;
            this.requestGridView.Size = new System.Drawing.Size(248, 486);
            this.requestGridView.TabIndex = 5;
            this.requestGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestGridView_CellClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(801, 495);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 39);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(882, 495);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 39);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // Type
            // 
            this.Type.Frozen = true;
            this.Type.HeaderText = "Type";
            this.Type.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 39;
            // 
            // TargetAddress
            // 
            this.TargetAddress.Frozen = true;
            this.TargetAddress.HeaderText = "Address";
            this.TargetAddress.Name = "TargetAddress";
            this.TargetAddress.ReadOnly = true;
            this.TargetAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TargetAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TargetAddress.Width = 166;
            // 
            // SparkHttp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SparkHttp";
            this.Text = "SparkHttp";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sparkHttpBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox requestTextBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.BindingSource sparkHttpBindingSource;
        private System.Windows.Forms.DataGridView requestGridView;
        private System.Windows.Forms.DataGridViewImageColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetAddress;
    }
}

