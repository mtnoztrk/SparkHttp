﻿namespace SparkHttp
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
            this.TypeIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.TargetAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.sparkHttpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRequest = new System.Windows.Forms.TabPage();
            this.tabResponse = new System.Windows.Forms.TabPage();
            this.responseTextBox = new System.Windows.Forms.RichTextBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sparkHttpBindingSource)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabRequest.SuspendLayout();
            this.tabResponse.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestTextBox
            // 
            this.requestTextBox.Location = new System.Drawing.Point(6, 6);
            this.requestTextBox.Name = "requestTextBox";
            this.requestTextBox.Size = new System.Drawing.Size(680, 461);
            this.requestTextBox.TabIndex = 0;
            this.requestTextBox.Text = "";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabControl1);
            this.mainPanel.Controls.Add(this.requestGridView);
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
            this.TypeIcon,
            this.TargetAddress,
            this.Guid});
            this.requestGridView.Location = new System.Drawing.Point(3, 28);
            this.requestGridView.Name = "requestGridView";
            this.requestGridView.ReadOnly = true;
            this.requestGridView.Size = new System.Drawing.Size(248, 505);
            this.requestGridView.TabIndex = 5;
            this.requestGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.requestGridView_CellClick);
            // 
            // TypeIcon
            // 
            this.TypeIcon.Frozen = true;
            this.TypeIcon.HeaderText = "Type";
            this.TypeIcon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.TypeIcon.Name = "TypeIcon";
            this.TypeIcon.ReadOnly = true;
            this.TypeIcon.Width = 39;
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
            // Guid
            // 
            this.Guid.Frozen = true;
            this.Guid.HeaderText = "Guid";
            this.Guid.Name = "Guid";
            this.Guid.ReadOnly = true;
            this.Guid.Visible = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(530, 473);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 26);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(611, 473);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 26);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRequest);
            this.tabControl1.Controls.Add(this.tabResponse);
            this.tabControl1.Location = new System.Drawing.Point(257, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 531);
            this.tabControl1.TabIndex = 6;
            // 
            // tabRequest
            // 
            this.tabRequest.Controls.Add(this.sendButton);
            this.tabRequest.Controls.Add(this.saveButton);
            this.tabRequest.Controls.Add(this.requestTextBox);
            this.tabRequest.Location = new System.Drawing.Point(4, 22);
            this.tabRequest.Name = "tabRequest";
            this.tabRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequest.Size = new System.Drawing.Size(692, 505);
            this.tabRequest.TabIndex = 0;
            this.tabRequest.Text = "Request";
            this.tabRequest.UseVisualStyleBackColor = true;
            // 
            // tabResponse
            // 
            this.tabResponse.Controls.Add(this.responseTextBox);
            this.tabResponse.Location = new System.Drawing.Point(4, 22);
            this.tabResponse.Name = "tabResponse";
            this.tabResponse.Padding = new System.Windows.Forms.Padding(3);
            this.tabResponse.Size = new System.Drawing.Size(692, 505);
            this.tabResponse.TabIndex = 1;
            this.tabResponse.Text = "Response";
            this.tabResponse.UseVisualStyleBackColor = true;
            // 
            // responseTextBox
            // 
            this.responseTextBox.Location = new System.Drawing.Point(6, 6);
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.Size = new System.Drawing.Size(680, 461);
            this.responseTextBox.TabIndex = 1;
            this.responseTextBox.Text = "";
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
            this.tabControl1.ResumeLayout(false);
            this.tabRequest.ResumeLayout(false);
            this.tabResponse.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox requestTextBox;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.BindingSource sparkHttpBindingSource;
        private System.Windows.Forms.DataGridView requestGridView;
        private System.Windows.Forms.DataGridViewImageColumn TypeIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Guid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRequest;
        private System.Windows.Forms.TabPage tabResponse;
        private System.Windows.Forms.RichTextBox responseTextBox;
    }
}

