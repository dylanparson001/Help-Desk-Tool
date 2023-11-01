namespace iGPS_Help_Desk.Views
{
    partial class Igps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Igps));
            this.label1 = new System.Windows.Forms.Label();
            this.StatusChange = new System.Windows.Forms.TabControl();
            this.tabClearContainers = new System.Windows.Forms.TabPage();
            this.cbSaveSnapshot = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetDnus = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumToBeDeleted = new System.Windows.Forms.TextBox();
            this.btnShowGlnContent = new System.Windows.Forms.Button();
            this.lvGlnContent = new System.Windows.Forms.ListView();
            this.colGln = new System.Windows.Forms.ColumnHeader();
            this.colGrai = new System.Windows.Forms.ColumnHeader();
            this.colDateTime = new System.Windows.Forms.ColumnHeader();
            this.txtContainersToClear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearContainers = new System.Windows.Forms.Button();
            this.labelContainersToClear = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.settingsBtn = new System.Windows.Forms.Button();
            this.StatusChange.SuspendLayout();
            this.tabClearContainers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "iGPS Help Desk Tool";
            // 
            // StatusChange
            // 
            this.StatusChange.Controls.Add(this.tabClearContainers);
            this.StatusChange.Location = new System.Drawing.Point(12, 40);
            this.StatusChange.Name = "StatusChange";
            this.StatusChange.SelectedIndex = 0;
            this.StatusChange.Size = new System.Drawing.Size(819, 445);
            this.StatusChange.TabIndex = 1;
            // 
            // tabClearContainers
            // 
            this.tabClearContainers.Controls.Add(this.cbSaveSnapshot);
            this.tabClearContainers.Controls.Add(this.button1);
            this.tabClearContainers.Controls.Add(this.btnGetDnus);
            this.tabClearContainers.Controls.Add(this.btnSave);
            this.tabClearContainers.Controls.Add(this.label8);
            this.tabClearContainers.Controls.Add(this.txtNumToBeDeleted);
            this.tabClearContainers.Controls.Add(this.btnShowGlnContent);
            this.tabClearContainers.Controls.Add(this.lvGlnContent);
            this.tabClearContainers.Controls.Add(this.txtContainersToClear);
            this.tabClearContainers.Controls.Add(this.label7);
            this.tabClearContainers.Controls.Add(this.btnClearContainers);
            this.tabClearContainers.Controls.Add(this.labelContainersToClear);
            this.tabClearContainers.Location = new System.Drawing.Point(4, 29);
            this.tabClearContainers.Name = "tabClearContainers";
            this.tabClearContainers.Size = new System.Drawing.Size(811, 412);
            this.tabClearContainers.TabIndex = 2;
            this.tabClearContainers.Text = "Clear Containers";
            this.tabClearContainers.UseVisualStyleBackColor = true;
            // 
            // cbSaveSnapshot
            // 
            this.cbSaveSnapshot.AutoSize = true;
            this.cbSaveSnapshot.Location = new System.Drawing.Point(154, 314);
            this.cbSaveSnapshot.Name = "cbSaveSnapshot";
            this.cbSaveSnapshot.Size = new System.Drawing.Size(137, 24);
            this.cbSaveSnapshot.TabIndex = 21;
            this.cbSaveSnapshot.Text = "Save Snapshot";
            this.cbSaveSnapshot.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 339);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 36);
            this.button1.TabIndex = 20;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickContainerCancel);
            // 
            // btnGetDnus
            // 
            this.btnGetDnus.Location = new System.Drawing.Point(274, 337);
            this.btnGetDnus.Name = "btnGetDnus";
            this.btnGetDnus.Size = new System.Drawing.Size(115, 39);
            this.btnGetDnus.TabIndex = 19;
            this.btnGetDnus.Text = "Get DNUs";
            this.btnGetDnus.UseVisualStyleBackColor = true;
            this.btnGetDnus.Click += new System.EventHandler(this.ClickGetDnus);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(154, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 39);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Content";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveContent);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(557, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "# GRAIs";
            // 
            // txtNumToBeDeleted
            // 
            this.txtNumToBeDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumToBeDeleted.Location = new System.Drawing.Point(560, 337);
            this.txtNumToBeDeleted.Multiline = true;
            this.txtNumToBeDeleted.Name = "txtNumToBeDeleted";
            this.txtNumToBeDeleted.ReadOnly = true;
            this.txtNumToBeDeleted.Size = new System.Drawing.Size(75, 39);
            this.txtNumToBeDeleted.TabIndex = 16;
            this.txtNumToBeDeleted.Text = "0";
            this.txtNumToBeDeleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShowGlnContent
            // 
            this.btnShowGlnContent.Location = new System.Drawing.Point(33, 339);
            this.btnShowGlnContent.Name = "btnShowGlnContent";
            this.btnShowGlnContent.Size = new System.Drawing.Size(105, 39);
            this.btnShowGlnContent.TabIndex = 15;
            this.btnShowGlnContent.Text = "Show Content";
            this.btnShowGlnContent.UseVisualStyleBackColor = true;
            this.btnShowGlnContent.Click += new System.EventHandler(this.ClickShowContent);
            // 
            // lvGlnContent
            // 
            this.lvGlnContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colGln, this.colGrai, this.colDateTime });
            this.lvGlnContent.FullRowSelect = true;
            this.lvGlnContent.HideSelection = false;
            this.lvGlnContent.HoverSelection = true;
            this.lvGlnContent.Location = new System.Drawing.Point(274, 39);
            this.lvGlnContent.Name = "lvGlnContent";
            this.lvGlnContent.Size = new System.Drawing.Size(497, 269);
            this.lvGlnContent.TabIndex = 14;
            this.lvGlnContent.UseCompatibleStateImageBehavior = false;
            this.lvGlnContent.View = System.Windows.Forms.View.Details;
            // 
            // colGln
            // 
            this.colGln.Text = "GLN";
            this.colGln.Width = 121;
            // 
            // colGrai
            // 
            this.colGrai.Text = "GRAI";
            this.colGrai.Width = 212;
            // 
            // colDateTime
            // 
            this.colDateTime.Text = "DATE_TIME";
            this.colDateTime.Width = 136;
            // 
            // txtContainersToClear
            // 
            this.txtContainersToClear.Location = new System.Drawing.Point(15, 39);
            this.txtContainersToClear.Multiline = true;
            this.txtContainersToClear.Name = "txtContainersToClear";
            this.txtContainersToClear.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContainersToClear.Size = new System.Drawing.Size(235, 269);
            this.txtContainersToClear.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Contents of Containers";
            // 
            // btnClearContainers
            // 
            this.btnClearContainers.BackColor = System.Drawing.Color.Red;
            this.btnClearContainers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClearContainers.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClearContainers.Location = new System.Drawing.Point(662, 339);
            this.btnClearContainers.Name = "btnClearContainers";
            this.btnClearContainers.Size = new System.Drawing.Size(100, 39);
            this.btnClearContainers.TabIndex = 2;
            this.btnClearContainers.Text = "Clear Containers";
            this.btnClearContainers.UseVisualStyleBackColor = false;
            this.btnClearContainers.Click += new System.EventHandler(this.ClickClearContainers);
            // 
            // labelContainersToClear
            // 
            this.labelContainersToClear.AutoSize = true;
            this.labelContainersToClear.Location = new System.Drawing.Point(15, 23);
            this.labelContainersToClear.Name = "labelContainersToClear";
            this.labelContainersToClear.Size = new System.Drawing.Size(191, 20);
            this.labelContainersToClear.TabIndex = 0;
            this.labelContainersToClear.Text = "Containers To Be Cleared";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(758, 11);
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(67, 27);
            this.settingsBtn.TabIndex = 2;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.ClickSettings);
            // 
            // Igps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(857, 514);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.StatusChange);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Igps";
            this.Text = "iGPS Help Desk";
            this.StatusChange.ResumeLayout(false);
            this.tabClearContainers.ResumeLayout(false);
            this.tabClearContainers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl StatusChange;
        private System.Windows.Forms.TabPage tabClearContainers;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtNumToBeDeleted;
        private System.Windows.Forms.Button btnShowGlnContent;
        private System.Windows.Forms.ListView lvGlnContent;
        private System.Windows.Forms.ColumnHeader colGln;
        private System.Windows.Forms.ColumnHeader colGrai;
        private System.Windows.Forms.ColumnHeader colDateTime;
        private System.Windows.Forms.TextBox txtContainersToClear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClearContainers;
        private System.Windows.Forms.Label labelContainersToClear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetDnus;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.CheckBox cbSaveSnapshot;
    }
}

