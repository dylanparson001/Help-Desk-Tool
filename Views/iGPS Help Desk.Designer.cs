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
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.findGhosts = new System.Windows.Forms.Button();
            this.cbSaveSnapshot = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetDnus = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumToBeDeleted = new System.Windows.Forms.TextBox();
            this.btnShowGlnContent = new System.Windows.Forms.Button();
            this.lvGlnContent = new System.Windows.Forms.ListView();
            this.colGln = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtContainersToClear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearContainers = new System.Windows.Forms.Button();
            this.labelContainersToClear = new System.Windows.Forms.Label();
            this.tabMovePallets = new System.Windows.Forms.TabPage();
            this.lblContainersAddSuccess = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tbSearchBar = new System.Windows.Forms.TextBox();
            this.lvPlacards = new System.Windows.Forms.ListView();
            this.ContainerGLN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContainerDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContainerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContainerSubStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssetCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.tabRemoveOrders = new System.Windows.Forms.TabPage();
            this.cbCheckAllOrders = new System.Windows.Forms.CheckBox();
            this.btnChangeQuantity = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.Orderid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BolId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessingStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSourceId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatusDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRequestedQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoveOrders = new System.Windows.Forms.Button();
            this.btnShowOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBols = new System.Windows.Forms.TextBox();
            this.dataSet1 = new System.Data.DataSet();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.settingsBtn = new System.Windows.Forms.Button();
            this.StatusChange.SuspendLayout();
            this.tabClearContainers.SuspendLayout();
            this.tabMovePallets.SuspendLayout();
            this.tabRemoveOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "iGPS Help Desk Tool";
            // 
            // StatusChange
            // 
            this.StatusChange.Controls.Add(this.tabClearContainers);
            this.StatusChange.Controls.Add(this.tabMovePallets);
            this.StatusChange.Controls.Add(this.tabRemoveOrders);
            this.StatusChange.Location = new System.Drawing.Point(12, 40);
            this.StatusChange.Name = "StatusChange";
            this.StatusChange.SelectedIndex = 0;
            this.StatusChange.Size = new System.Drawing.Size(865, 453);
            this.StatusChange.TabIndex = 1;
            // 
            // tabClearContainers
            // 
            this.tabClearContainers.Controls.Add(this.lblErrorMessage);
            this.tabClearContainers.Controls.Add(this.findGhosts);
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
            this.tabClearContainers.Location = new System.Drawing.Point(4, 22);
            this.tabClearContainers.Name = "tabClearContainers";
            this.tabClearContainers.Size = new System.Drawing.Size(857, 427);
            this.tabClearContainers.TabIndex = 2;
            this.tabClearContainers.Text = "Clear Containers";
            this.tabClearContainers.UseVisualStyleBackColor = true;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(18, 341);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(51, 20);
            this.lblErrorMessage.TabIndex = 23;
            this.lblErrorMessage.Text = "label3";
            this.lblErrorMessage.Visible = false;
            // 
            // findGhosts
            // 
            this.findGhosts.Location = new System.Drawing.Point(247, 365);
            this.findGhosts.Name = "findGhosts";
            this.findGhosts.Size = new System.Drawing.Size(115, 39);
            this.findGhosts.TabIndex = 22;
            this.findGhosts.Text = "Find Ghost Grais";
            this.findGhosts.UseVisualStyleBackColor = true;
            this.findGhosts.Click += new System.EventHandler(this.BtnFindGhosts);
            // 
            // cbSaveSnapshot
            // 
            this.cbSaveSnapshot.AutoSize = true;
            this.cbSaveSnapshot.Checked = true;
            this.cbSaveSnapshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveSnapshot.Location = new System.Drawing.Point(368, 342);
            this.cbSaveSnapshot.Name = "cbSaveSnapshot";
            this.cbSaveSnapshot.Size = new System.Drawing.Size(99, 17);
            this.cbSaveSnapshot.TabIndex = 21;
            this.cbSaveSnapshot.Text = "Save Snapshot";
            this.cbSaveSnapshot.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 365);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 39);
            this.button1.TabIndex = 20;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClickContainerCancel);
            // 
            // btnGetDnus
            // 
            this.btnGetDnus.Location = new System.Drawing.Point(126, 365);
            this.btnGetDnus.Name = "btnGetDnus";
            this.btnGetDnus.Size = new System.Drawing.Size(115, 39);
            this.btnGetDnus.TabIndex = 19;
            this.btnGetDnus.Text = "Get DNUs";
            this.btnGetDnus.UseVisualStyleBackColor = true;
            this.btnGetDnus.Click += new System.EventHandler(this.ClickGetDnus);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(368, 365);
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
            this.label8.Location = new System.Drawing.Point(618, 347);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "# GRAIs";
            // 
            // txtNumToBeDeleted
            // 
            this.txtNumToBeDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumToBeDeleted.Location = new System.Drawing.Point(621, 365);
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
            this.btnShowGlnContent.Location = new System.Drawing.Point(15, 365);
            this.btnShowGlnContent.Name = "btnShowGlnContent";
            this.btnShowGlnContent.Size = new System.Drawing.Size(105, 39);
            this.btnShowGlnContent.TabIndex = 15;
            this.btnShowGlnContent.Text = "Show Content";
            this.btnShowGlnContent.UseVisualStyleBackColor = true;
            this.btnShowGlnContent.Click += new System.EventHandler(this.ClickShowContent);
            // 
            // lvGlnContent
            // 
            this.lvGlnContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGln,
            this.colGrai,
            this.colDateTime});
            this.lvGlnContent.FullRowSelect = true;
            this.lvGlnContent.HideSelection = false;
            this.lvGlnContent.Location = new System.Drawing.Point(296, 39);
            this.lvGlnContent.Name = "lvGlnContent";
            this.lvGlnContent.Size = new System.Drawing.Size(527, 295);
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
            this.txtContainersToClear.Size = new System.Drawing.Size(235, 295);
            this.txtContainersToClear.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Contents of Containers";
            // 
            // btnClearContainers
            // 
            this.btnClearContainers.BackColor = System.Drawing.Color.Red;
            this.btnClearContainers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearContainers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClearContainers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClearContainers.Location = new System.Drawing.Point(723, 365);
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
            this.labelContainersToClear.Location = new System.Drawing.Point(15, 16);
            this.labelContainersToClear.Name = "labelContainersToClear";
            this.labelContainersToClear.Size = new System.Drawing.Size(128, 13);
            this.labelContainersToClear.TabIndex = 0;
            this.labelContainersToClear.Text = "Containers To Be Cleared";
            // 
            // tabMovePallets
            // 
            this.tabMovePallets.Controls.Add(this.lblContainersAddSuccess);
            this.tabMovePallets.Controls.Add(this.button4);
            this.tabMovePallets.Controls.Add(this.label2);
            this.tabMovePallets.Controls.Add(this.button3);
            this.tabMovePallets.Controls.Add(this.tbSearchBar);
            this.tabMovePallets.Controls.Add(this.lvPlacards);
            this.tabMovePallets.Controls.Add(this.button2);
            this.tabMovePallets.Location = new System.Drawing.Point(4, 22);
            this.tabMovePallets.Margin = new System.Windows.Forms.Padding(2);
            this.tabMovePallets.Name = "tabMovePallets";
            this.tabMovePallets.Size = new System.Drawing.Size(857, 427);
            this.tabMovePallets.TabIndex = 3;
            this.tabMovePallets.Text = "Search Containers";
            this.tabMovePallets.UseVisualStyleBackColor = true;
            // 
            // lblContainersAddSuccess
            // 
            this.lblContainersAddSuccess.AutoSize = true;
            this.lblContainersAddSuccess.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblContainersAddSuccess.Location = new System.Drawing.Point(193, 387);
            this.lblContainersAddSuccess.Name = "lblContainersAddSuccess";
            this.lblContainersAddSuccess.Size = new System.Drawing.Size(144, 13);
            this.lblContainersAddSuccess.TabIndex = 13;
            this.lblContainersAddSuccess.Text = "Containers have been added";
            this.lblContainersAddSuccess.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(653, 386);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 33);
            this.button4.TabIndex = 12;
            this.button4.Text = "Show Grais";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.moveExisitngForm);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "Add To Containers List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.addToClearList);
            // 
            // tbSearchBar
            // 
            this.tbSearchBar.Location = new System.Drawing.Point(537, 27);
            this.tbSearchBar.Name = "tbSearchBar";
            this.tbSearchBar.Size = new System.Drawing.Size(241, 20);
            this.tbSearchBar.TabIndex = 9;
            this.tbSearchBar.TextChanged += new System.EventHandler(this.searchContainersText);
            // 
            // lvPlacards
            // 
            this.lvPlacards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContainerGLN,
            this.ContainerDescription,
            this.ContainerStatus,
            this.ContainerSubStatus,
            this.AssetCount});
            this.lvPlacards.FullRowSelect = true;
            this.lvPlacards.HideSelection = false;
            this.lvPlacards.Location = new System.Drawing.Point(24, 61);
            this.lvPlacards.Name = "lvPlacards";
            this.lvPlacards.Size = new System.Drawing.Size(754, 315);
            this.lvPlacards.TabIndex = 2;
            this.lvPlacards.UseCompatibleStateImageBehavior = false;
            this.lvPlacards.View = System.Windows.Forms.View.Details;
            // 
            // ContainerGLN
            // 
            this.ContainerGLN.Text = "GLN";
            this.ContainerGLN.Width = 126;
            // 
            // ContainerDescription
            // 
            this.ContainerDescription.Text = "Description";
            this.ContainerDescription.Width = 236;
            // 
            // ContainerStatus
            // 
            this.ContainerStatus.Text = "Status";
            this.ContainerStatus.Width = 114;
            // 
            // ContainerSubStatus
            // 
            this.ContainerSubStatus.Text = "SubStatus";
            this.ContainerSubStatus.Width = 98;
            // 
            // AssetCount
            // 
            this.AssetCount.Text = "Count";
            this.AssetCount.Width = 73;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reload Containers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ReloadContainers);
            // 
            // tabRemoveOrders
            // 
            this.tabRemoveOrders.Controls.Add(this.cbCheckAllOrders);
            this.tabRemoveOrders.Controls.Add(this.btnChangeQuantity);
            this.tabRemoveOrders.Controls.Add(this.lblError);
            this.tabRemoveOrders.Controls.Add(this.lvOrders);
            this.tabRemoveOrders.Controls.Add(this.btnRemoveOrders);
            this.tabRemoveOrders.Controls.Add(this.btnShowOrder);
            this.tabRemoveOrders.Controls.Add(this.label3);
            this.tabRemoveOrders.Controls.Add(this.txtBols);
            this.tabRemoveOrders.Location = new System.Drawing.Point(4, 22);
            this.tabRemoveOrders.Name = "tabRemoveOrders";
            this.tabRemoveOrders.Size = new System.Drawing.Size(857, 427);
            this.tabRemoveOrders.TabIndex = 4;
            this.tabRemoveOrders.Text = "Order Removal";
            this.tabRemoveOrders.UseVisualStyleBackColor = true;
            // 
            // cbCheckAllOrders
            // 
            this.cbCheckAllOrders.AutoSize = true;
            this.cbCheckAllOrders.Location = new System.Drawing.Point(159, 23);
            this.cbCheckAllOrders.Name = "cbCheckAllOrders";
            this.cbCheckAllOrders.Size = new System.Drawing.Size(105, 17);
            this.cbCheckAllOrders.TabIndex = 9;
            this.cbCheckAllOrders.Text = "Check All Orders";
            this.cbCheckAllOrders.UseVisualStyleBackColor = true;
            this.cbCheckAllOrders.CheckedChanged += new System.EventHandler(this.clickCheckAll);
            // 
            // btnChangeQuantity
            // 
            this.btnChangeQuantity.Location = new System.Drawing.Point(269, 389);
            this.btnChangeQuantity.Name = "btnChangeQuantity";
            this.btnChangeQuantity.Size = new System.Drawing.Size(106, 34);
            this.btnChangeQuantity.TabIndex = 8;
            this.btnChangeQuantity.Text = "Change Quantity";
            this.btnChangeQuantity.UseVisualStyleBackColor = true;
            this.btnChangeQuantity.Click += new System.EventHandler(this.clickChangeQuantity);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(657, 389);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(28, 13);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "error";
            this.lblError.Visible = false;
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Orderid,
            this.BolId,
            this.ProcessingStatus,
            this.colSourceId,
            this.colStatusDate,
            this.colRequestedQuantity});
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(159, 46);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(670, 337);
            this.lvOrders.TabIndex = 5;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            // 
            // Orderid
            // 
            this.Orderid.Text = "Order Id";
            this.Orderid.Width = 120;
            // 
            // BolId
            // 
            this.BolId.Text = "Bol Id";
            this.BolId.Width = 75;
            // 
            // ProcessingStatus
            // 
            this.ProcessingStatus.Text = "Processing Status";
            this.ProcessingStatus.Width = 100;
            // 
            // colSourceId
            // 
            this.colSourceId.Text = "Source Id";
            this.colSourceId.Width = 85;
            // 
            // colStatusDate
            // 
            this.colStatusDate.Text = "Status Date";
            this.colStatusDate.Width = 145;
            // 
            // colRequestedQuantity
            // 
            this.colRequestedQuantity.Text = "Quantity";
            this.colRequestedQuantity.Width = 75;
            // 
            // btnRemoveOrders
            // 
            this.btnRemoveOrders.Location = new System.Drawing.Point(159, 390);
            this.btnRemoveOrders.Name = "btnRemoveOrders";
            this.btnRemoveOrders.Size = new System.Drawing.Size(104, 34);
            this.btnRemoveOrders.TabIndex = 4;
            this.btnRemoveOrders.Text = "Remove Selected Orders";
            this.btnRemoveOrders.UseVisualStyleBackColor = true;
            this.btnRemoveOrders.Click += new System.EventHandler(this.clickRemoveOrders);
            // 
            // btnShowOrder
            // 
            this.btnShowOrder.Location = new System.Drawing.Point(18, 389);
            this.btnShowOrder.Name = "btnShowOrder";
            this.btnShowOrder.Size = new System.Drawing.Size(110, 34);
            this.btnShowOrder.TabIndex = 2;
            this.btnShowOrder.Text = "Show Orders";
            this.btnShowOrder.UseVisualStyleBackColor = true;
            this.btnShowOrder.Click += new System.EventHandler(this.clickShowOrder);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Enter BOL(s)";
            // 
            // txtBols
            // 
            this.txtBols.Location = new System.Drawing.Point(20, 46);
            this.txtBols.Multiline = true;
            this.txtBols.Name = "txtBols";
            this.txtBols.Size = new System.Drawing.Size(108, 337);
            this.txtBols.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(806, 9);
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
            this.ClientSize = new System.Drawing.Size(882, 497);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.StatusChange);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Igps";
            this.Text = "iGPS Help Desk";
            this.StatusChange.ResumeLayout(false);
            this.tabClearContainers.ResumeLayout(false);
            this.tabClearContainers.PerformLayout();
            this.tabMovePallets.ResumeLayout(false);
            this.tabMovePallets.PerformLayout();
            this.tabRemoveOrders.ResumeLayout(false);
            this.tabRemoveOrders.PerformLayout();
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
        private System.Windows.Forms.TabPage tabMovePallets;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvPlacards;
        private System.Windows.Forms.ColumnHeader ContainerGLN;
        private System.Windows.Forms.ColumnHeader ContainerDescription;
        private System.Windows.Forms.ColumnHeader ContainerStatus;
        private System.Windows.Forms.ColumnHeader ContainerSubStatus;
        private System.Windows.Forms.ColumnHeader AssetCount;
        private System.Windows.Forms.CheckBox cbSaveSnapshot;
        private System.Windows.Forms.TextBox tbSearchBar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblContainersAddSuccess;
        private System.Windows.Forms.Button findGhosts;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.TabPage tabRemoveOrders;
        private System.Windows.Forms.Button btnShowOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBols;
        private System.Windows.Forms.Button btnRemoveOrders;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader Orderid;
        private System.Windows.Forms.ColumnHeader BolId;
        private System.Windows.Forms.ColumnHeader ProcessingStatus;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ColumnHeader colSourceId;
        private System.Windows.Forms.ColumnHeader colStatusDate;
        private System.Windows.Forms.ColumnHeader colRequestedQuantity;
        private System.Windows.Forms.Button btnChangeQuantity;
        private System.Windows.Forms.CheckBox cbCheckAllOrders;
    }
}
