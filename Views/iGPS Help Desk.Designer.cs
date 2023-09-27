namespace iGPS_Help_Desk.Forms
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
            this.formChangeStatus = new System.Windows.Forms.TabPage();
            this.lvGlnList = new System.Windows.Forms.ListView();
            this.GLN = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.SubStatus = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewSubStatus = new System.Windows.Forms.TextBox();
            this.txtNewStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmitStatusChange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGlnList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.settingsBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.StatusChange.SuspendLayout();
            this.tabClearContainers.SuspendLayout();
            this.formChangeStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "iGPS Help Desk Tool";
            // 
            // StatusChange
            // 
            this.StatusChange.Controls.Add(this.tabClearContainers);
            this.StatusChange.Controls.Add(this.formChangeStatus);
            this.StatusChange.Location = new System.Drawing.Point(18, 60);
            this.StatusChange.Margin = new System.Windows.Forms.Padding(4);
            this.StatusChange.Name = "StatusChange";
            this.StatusChange.SelectedIndex = 0;
            this.StatusChange.Size = new System.Drawing.Size(1178, 614);
            this.StatusChange.TabIndex = 1;
            // 
            // tabClearContainers
            // 
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
            this.tabClearContainers.Margin = new System.Windows.Forms.Padding(4);
            this.tabClearContainers.Name = "tabClearContainers";
            this.tabClearContainers.Size = new System.Drawing.Size(1170, 581);
            this.tabClearContainers.TabIndex = 2;
            this.tabClearContainers.Text = "Clear Containers";
            this.tabClearContainers.UseVisualStyleBackColor = true;
            // 
            // btnGetDnus
            // 
            this.btnGetDnus.Location = new System.Drawing.Point(411, 506);
            this.btnGetDnus.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetDnus.Name = "btnGetDnus";
            this.btnGetDnus.Size = new System.Drawing.Size(172, 58);
            this.btnGetDnus.TabIndex = 19;
            this.btnGetDnus.Text = "Get DNUs";
            this.btnGetDnus.UseVisualStyleBackColor = true;
            this.btnGetDnus.Click += new System.EventHandler(this.ClickGetDnus);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 506);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 58);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Content";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSaveContent);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(836, 482);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "# GRAIs";
            // 
            // txtNumToBeDeleted
            // 
            this.txtNumToBeDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumToBeDeleted.Location = new System.Drawing.Point(840, 506);
            this.txtNumToBeDeleted.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumToBeDeleted.Multiline = true;
            this.txtNumToBeDeleted.Name = "txtNumToBeDeleted";
            this.txtNumToBeDeleted.ReadOnly = true;
            this.txtNumToBeDeleted.Size = new System.Drawing.Size(110, 56);
            this.txtNumToBeDeleted.TabIndex = 16;
            this.txtNumToBeDeleted.Text = "0";
            this.txtNumToBeDeleted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShowGlnContent
            // 
            this.btnShowGlnContent.Location = new System.Drawing.Point(50, 508);
            this.btnShowGlnContent.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowGlnContent.Name = "btnShowGlnContent";
            this.btnShowGlnContent.Size = new System.Drawing.Size(158, 58);
            this.btnShowGlnContent.TabIndex = 15;
            this.btnShowGlnContent.Text = "Show Content";
            this.btnShowGlnContent.UseVisualStyleBackColor = true;
            this.btnShowGlnContent.Click += new System.EventHandler(this.ClickShowContent);
            // 
            // lvGlnContent
            // 
            this.lvGlnContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colGln, this.colGrai, this.colDateTime });
            this.lvGlnContent.HideSelection = false;
            this.lvGlnContent.Location = new System.Drawing.Point(411, 58);
            this.lvGlnContent.Margin = new System.Windows.Forms.Padding(4);
            this.lvGlnContent.Name = "lvGlnContent";
            this.lvGlnContent.Size = new System.Drawing.Size(744, 402);
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
            this.txtContainersToClear.Location = new System.Drawing.Point(23, 58);
            this.txtContainersToClear.Margin = new System.Windows.Forms.Padding(4);
            this.txtContainersToClear.Multiline = true;
            this.txtContainersToClear.Name = "txtContainersToClear";
            this.txtContainersToClear.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContainersToClear.Size = new System.Drawing.Size(350, 402);
            this.txtContainersToClear.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(411, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Contents of Containers";
            // 
            // btnClearContainers
            // 
            this.btnClearContainers.BackColor = System.Drawing.Color.Red;
            this.btnClearContainers.Cursor = System.Windows.Forms.Cursors.No;
            this.btnClearContainers.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClearContainers.Location = new System.Drawing.Point(993, 508);
            this.btnClearContainers.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearContainers.Name = "btnClearContainers";
            this.btnClearContainers.Size = new System.Drawing.Size(150, 58);
            this.btnClearContainers.TabIndex = 2;
            this.btnClearContainers.Text = "Clear Containers";
            this.btnClearContainers.UseVisualStyleBackColor = false;
            this.btnClearContainers.Click += new System.EventHandler(this.ClickClearContainers);
            // 
            // labelContainersToClear
            // 
            this.labelContainersToClear.AutoSize = true;
            this.labelContainersToClear.Location = new System.Drawing.Point(23, 34);
            this.labelContainersToClear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContainersToClear.Name = "labelContainersToClear";
            this.labelContainersToClear.Size = new System.Drawing.Size(191, 20);
            this.labelContainersToClear.TabIndex = 0;
            this.labelContainersToClear.Text = "Containers To Be Cleared";
            // 
            // formChangeStatus
            // 
            this.formChangeStatus.Controls.Add(this.lvGlnList);
            this.formChangeStatus.Controls.Add(this.btnCancel);
            this.formChangeStatus.Controls.Add(this.txtNewSubStatus);
            this.formChangeStatus.Controls.Add(this.txtNewStatus);
            this.formChangeStatus.Controls.Add(this.label5);
            this.formChangeStatus.Controls.Add(this.btnSubmitStatusChange);
            this.formChangeStatus.Controls.Add(this.label4);
            this.formChangeStatus.Controls.Add(this.label3);
            this.formChangeStatus.Controls.Add(this.txtGlnList);
            this.formChangeStatus.Controls.Add(this.label2);
            this.formChangeStatus.Location = new System.Drawing.Point(4, 29);
            this.formChangeStatus.Margin = new System.Windows.Forms.Padding(4);
            this.formChangeStatus.Name = "formChangeStatus";
            this.formChangeStatus.Padding = new System.Windows.Forms.Padding(4);
            this.formChangeStatus.Size = new System.Drawing.Size(1170, 581);
            this.formChangeStatus.TabIndex = 0;
            this.formChangeStatus.Text = "Status Changes";
            this.formChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lvGlnList
            // 
            this.lvGlnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGlnList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.GLN, this.Status, this.SubStatus });
            this.lvGlnList.HideSelection = false;
            this.lvGlnList.Location = new System.Drawing.Point(632, 68);
            this.lvGlnList.Margin = new System.Windows.Forms.Padding(4);
            this.lvGlnList.Name = "lvGlnList";
            this.lvGlnList.Size = new System.Drawing.Size(523, 446);
            this.lvGlnList.TabIndex = 13;
            this.lvGlnList.UseCompatibleStateImageBehavior = false;
            this.lvGlnList.View = System.Windows.Forms.View.Details;
            // 
            // GLN
            // 
            this.GLN.Text = "GLN";
            this.GLN.Width = 121;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 99;
            // 
            // SubStatus
            // 
            this.SubStatus.Text = "SubStatus";
            this.SubStatus.Width = 101;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 462);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 54);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.ClickCancel);
            // 
            // txtNewSubStatus
            // 
            this.txtNewSubStatus.Location = new System.Drawing.Point(260, 214);
            this.txtNewSubStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewSubStatus.Name = "txtNewSubStatus";
            this.txtNewSubStatus.Size = new System.Drawing.Size(176, 26);
            this.txtNewSubStatus.TabIndex = 10;
            // 
            // txtNewStatus
            // 
            this.txtNewStatus.Location = new System.Drawing.Point(260, 68);
            this.txtNewStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewStatus.Name = "txtNewStatus";
            this.txtNewStatus.Size = new System.Drawing.Size(176, 26);
            this.txtNewStatus.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(627, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "New Gln Status / SubStatus";
            // 
            // btnSubmitStatusChange
            // 
            this.btnSubmitStatusChange.Location = new System.Drawing.Point(260, 462);
            this.btnSubmitStatusChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitStatusChange.Name = "btnSubmitStatusChange";
            this.btnSubmitStatusChange.Size = new System.Drawing.Size(178, 54);
            this.btnSubmitStatusChange.TabIndex = 6;
            this.btnSubmitStatusChange.Text = "Submit";
            this.btnSubmitStatusChange.UseVisualStyleBackColor = true;
            this.btnSubmitStatusChange.Click += new System.EventHandler(this.ClickStatusChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "New SubStatus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Status";
            // 
            // txtGlnList
            // 
            this.txtGlnList.Location = new System.Drawing.Point(9, 68);
            this.txtGlnList.Margin = new System.Windows.Forms.Padding(4);
            this.txtGlnList.Multiline = true;
            this.txtGlnList.Name = "txtGlnList";
            this.txtGlnList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGlnList.Size = new System.Drawing.Size(235, 446);
            this.txtGlnList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "GLN List";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(1062, 14);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(100, 40);
            this.settingsBtn.TabIndex = 2;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.clickSettings);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(603, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 54);
            this.button1.TabIndex = 20;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clickCancel);
            // 
            // Igps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1204, 760);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.StatusChange);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Igps";
            this.Text = "iGPS Help Desk";
            this.StatusChange.ResumeLayout(false);
            this.tabClearContainers.ResumeLayout(false);
            this.tabClearContainers.PerformLayout();
            this.formChangeStatus.ResumeLayout(false);
            this.formChangeStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl StatusChange;
        private System.Windows.Forms.TabPage formChangeStatus;
        private System.Windows.Forms.TabPage tabClearContainers;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView lvGlnList;
        private System.Windows.Forms.ColumnHeader GLN;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader SubStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewSubStatus;
        private System.Windows.Forms.TextBox txtNewStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmitStatusChange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGlnList;
        private System.Windows.Forms.Label label2;
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
    }
}

