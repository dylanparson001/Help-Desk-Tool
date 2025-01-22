namespace iGPS_Help_Desk.Views
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
            this.cbPalletGenerationChoice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.lvFromGrais.Location = new System.Drawing.Point(34, 57);
            this.lvFromGrais.Name = "lvFromGrais";
            this.lvFromGrais.Size = new System.Drawing.Size(593, 273);
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
            this.btnDeleteSelectedGrais.Location = new System.Drawing.Point(34, 350);
            this.btnDeleteSelectedGrais.Name = "btnDeleteSelectedGrais";
            this.btnDeleteSelectedGrais.Size = new System.Drawing.Size(128, 27);
            this.btnDeleteSelectedGrais.TabIndex = 11;
            this.btnDeleteSelectedGrais.Text = "Delete Selected Grais";
            this.btnDeleteSelectedGrais.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedGrais.Click += new System.EventHandler(this.clickDeleteSelectedGrais);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(549, 350);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(77, 27);
            this.btnCloseForm.TabIndex = 15;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.clickCloseForm);
            // 
            // lblFromGraisCount
            // 
            this.lblFromGraisCount.AutoSize = true;
            this.lblFromGraisCount.Location = new System.Drawing.Point(31, 333);
            this.lblFromGraisCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromGraisCount.Name = "lblFromGraisCount";
            this.lblFromGraisCount.Size = new System.Drawing.Size(41, 13);
            this.lblFromGraisCount.TabIndex = 13;
            this.lblFromGraisCount.Text = "[Count]";
            // 
            // lblFromGln
            // 
            this.lblFromGln.Location = new System.Drawing.Point(34, 24);
            this.lblFromGln.Multiline = true;
            this.lblFromGln.Name = "lblFromGln";
            this.lblFromGln.ReadOnly = true;
            this.lblFromGln.Size = new System.Drawing.Size(111, 20);
            this.lblFromGln.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "GLN:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 350);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 27);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save Selected GRAIs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.saveSelectedGrais);
            // 
            // reloadButton
            // 
            this.reloadButton.Location = new System.Drawing.Point(549, 24);
            this.reloadButton.Margin = new System.Windows.Forms.Padding(2);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(77, 23);
            this.reloadButton.TabIndex = 20;
            this.reloadButton.Text = "Reload";
            this.reloadButton.UseVisualStyleBackColor = true;
            this.reloadButton.Click += new System.EventHandler(this.ReloadButtonClick);
            // 
            // lblSelectGraisError
            // 
            this.lblSelectGraisError.AutoSize = true;
            this.lblSelectGraisError.ForeColor = System.Drawing.Color.Red;
            this.lblSelectGraisError.Location = new System.Drawing.Point(187, 322);
            this.lblSelectGraisError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectGraisError.Name = "lblSelectGraisError";
            this.lblSelectGraisError.Size = new System.Drawing.Size(0, 13);
            this.lblSelectGraisError.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Search GRAI";
            // 
            // graiSearchBar
            // 
            this.graiSearchBar.Location = new System.Drawing.Point(314, 24);
            this.graiSearchBar.Margin = new System.Windows.Forms.Padding(2);
            this.graiSearchBar.Multiline = true;
            this.graiSearchBar.Name = "graiSearchBar";
            this.graiSearchBar.Size = new System.Drawing.Size(163, 20);
            this.graiSearchBar.TabIndex = 22;
            this.graiSearchBar.TextChanged += new System.EventHandler(this.searchContainerForGrai);
            // 
            // cbPalletGenerationChoice
            // 
            this.cbPalletGenerationChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalletGenerationChoice.FormattingEnabled = true;
            this.cbPalletGenerationChoice.Items.AddRange(new object[] {
            "ALL",
            "GEN1 (0)",
            "GEN2/FEMSA (A)",
            "GEN2/Rehrig (B)",
            "GEN3 (C)",
            "GEN6 (D)"});
            this.cbPalletGenerationChoice.Location = new System.Drawing.Point(154, 24);
            this.cbPalletGenerationChoice.Margin = new System.Windows.Forms.Padding(2);
            this.cbPalletGenerationChoice.Name = "cbPalletGenerationChoice";
            this.cbPalletGenerationChoice.Size = new System.Drawing.Size(133, 21);
            this.cbPalletGenerationChoice.TabIndex = 24;
            this.cbPalletGenerationChoice.SelectedIndexChanged += new System.EventHandler(this.palletGenChoice);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Generation:";
            // 
            // ClearGraisForm
            // 
            this.AcceptButton = this.btnDeleteSelectedGrais;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 388);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPalletGenerationChoice);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClearGraisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ComboBox cbPalletGenerationChoice;
        private System.Windows.Forms.Label label3;
    }
}