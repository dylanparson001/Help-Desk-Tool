﻿namespace iGPS_Help_Desk.Views
{
    partial class ClearGraisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearGraisForm));
            this.lvFromGrais = new System.Windows.Forms.ListView();
            this.colGrais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDeleteSelectedGrais = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.lblFromGraisCount = new System.Windows.Forms.Label();
            this.lblFromGln = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.reloadButton = new System.Windows.Forms.Button();
            this.lblSelectGraisError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.graiSearchBar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvFromGrais
            // 
            this.lvFromGrais.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGrais,
            this.colDate,
            this.colCount});
            this.lvFromGrais.FullRowSelect = true;
            this.lvFromGrais.HideSelection = false;
            this.lvFromGrais.Location = new System.Drawing.Point(51, 73);
            this.lvFromGrais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvFromGrais.Name = "lvFromGrais";
            this.lvFromGrais.Size = new System.Drawing.Size(888, 432);
            this.lvFromGrais.TabIndex = 8;
            this.lvFromGrais.UseCompatibleStateImageBehavior = false;
            this.lvFromGrais.View = System.Windows.Forms.View.Details;
            // 
            // colGrais
            // 
            this.colGrais.Text = "GRAI";
            this.colGrais.Width = 199;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 229;
            // 
            // colCount
            // 
            this.colCount.Text = "Count";
            this.colCount.Width = 69;
            // 
            // btnDeleteSelectedGrais
            // 
            this.btnDeleteSelectedGrais.Location = new System.Drawing.Point(51, 538);
            this.btnDeleteSelectedGrais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteSelectedGrais.Name = "btnDeleteSelectedGrais";
            this.btnDeleteSelectedGrais.Size = new System.Drawing.Size(192, 42);
            this.btnDeleteSelectedGrais.TabIndex = 11;
            this.btnDeleteSelectedGrais.Text = "Delete Selected Grais";
            this.btnDeleteSelectedGrais.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedGrais.Click += new System.EventHandler(this.clickDeleteSelectedGrais);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(823, 538);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(116, 42);
            this.btnCloseForm.TabIndex = 15;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.clickCloseForm);
            // 
            // lblFromGraisCount
            // 
            this.lblFromGraisCount.AutoSize = true;
            this.lblFromGraisCount.Location = new System.Drawing.Point(33, 510);
            this.lblFromGraisCount.Name = "lblFromGraisCount";
            this.lblFromGraisCount.Size = new System.Drawing.Size(60, 20);
            this.lblFromGraisCount.TabIndex = 13;
            this.lblFromGraisCount.Text = "[Count]";
            // 
            // lblFromGln
            // 
            this.lblFromGln.Location = new System.Drawing.Point(104, 19);
            this.lblFromGln.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblFromGln.Name = "lblFromGln";
            this.lblFromGln.ReadOnly = true;
            this.lblFromGln.Size = new System.Drawing.Size(162, 26);
            this.lblFromGln.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "GLN:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 42);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save Selected GRAIs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.saveSelectedGrais);
            // 
            // reloadButton
            // 
            this.reloadButton.Location = new System.Drawing.Point(742, 13);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(112, 32);
            this.reloadButton.TabIndex = 20;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // lblSelectGraisError
            // 
            this.lblSelectGraisError.AutoSize = true;
            this.lblSelectGraisError.ForeColor = System.Drawing.Color.Red;
            this.lblSelectGraisError.Location = new System.Drawing.Point(280, 496);
            this.lblSelectGraisError.Name = "lblSelectGraisError";
            this.lblSelectGraisError.Size = new System.Drawing.Size(0, 20);
            this.lblSelectGraisError.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Search GRAI";
            // 
            // graiSearchBar
            // 
            this.graiSearchBar.Location = new System.Drawing.Point(314, 19);
            this.graiSearchBar.Name = "graiSearchBar";
            this.graiSearchBar.Size = new System.Drawing.Size(241, 26);
            this.graiSearchBar.TabIndex = 22;
            this.graiSearchBar.TextChanged += new System.EventHandler(this.searchContainerForGrai);
            // 
            // ClearGraisForm
            // 
            this.AcceptButton = this.btnDeleteSelectedGrais;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 640);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.graiSearchBar);
            this.Controls.Add(this.lblSelectGraisError);
            this.Controls.Add(this.reloadButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFromGln);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblFromGraisCount);
            this.Controls.Add(this.btnDeleteSelectedGrais);
            this.Controls.Add(this.lvFromGrais);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClearGraisForm";
            this.Text = "Grai List of Container";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvFromGrais;
        private System.Windows.Forms.ColumnHeader colGrais;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnDeleteSelectedGrais;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblFromGraisCount;
        private System.Windows.Forms.TextBox lblFromGln;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.Label lblSelectGraisError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox graiSearchBar;
    }
}