namespace iGPS_Help_Desk.Views
{
    partial class MoveContainersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveContainersForm));
            this.lvFromGrais = new System.Windows.Forms.ListView();
            this.colFromGrais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvToGln = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMoveGrais = new System.Windows.Forms.Button();
            this.btnMoveSelectedGrais = new System.Windows.Forms.Button();
            this.cbDeleteContainer = new System.Windows.Forms.CheckBox();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.lblToGraisCount = new System.Windows.Forms.Label();
            this.lblFromGraisCount = new System.Windows.Forms.Label();
            this.lblToGln = new System.Windows.Forms.TextBox();
            this.lblFromGln = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvFromGrais
            // 
            this.lvFromGrais.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFromGrais,
            this.colCount});
            this.lvFromGrais.HideSelection = false;
            this.lvFromGrais.Location = new System.Drawing.Point(20, 87);
            this.lvFromGrais.Name = "lvFromGrais";
            this.lvFromGrais.Size = new System.Drawing.Size(348, 278);
            this.lvFromGrais.TabIndex = 8;
            this.lvFromGrais.UseCompatibleStateImageBehavior = false;
            this.lvFromGrais.View = System.Windows.Forms.View.Details;
            // 
            // colFromGrais
            // 
            this.colFromGrais.Text = "GRAI";
            this.colFromGrais.Width = 241;
            // 
            // colCount
            // 
            this.colCount.Text = "Count";
            // 
            // lvToGln
            // 
            this.lvToGln.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colToCount});
            this.lvToGln.HideSelection = false;
            this.lvToGln.Location = new System.Drawing.Point(404, 87);
            this.lvToGln.Name = "lvToGln";
            this.lvToGln.Size = new System.Drawing.Size(370, 278);
            this.lvToGln.TabIndex = 9;
            this.lvToGln.UseCompatibleStateImageBehavior = false;
            this.lvToGln.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "GRAI";
            this.columnHeader1.Width = 268;
            // 
            // colToCount
            // 
            this.colToCount.Text = "Count";
            // 
            // btnMoveGrais
            // 
            this.btnMoveGrais.Location = new System.Drawing.Point(406, 395);
            this.btnMoveGrais.Name = "btnMoveGrais";
            this.btnMoveGrais.Size = new System.Drawing.Size(112, 35);
            this.btnMoveGrais.TabIndex = 10;
            this.btnMoveGrais.Text = "Move All Grais";
            this.btnMoveGrais.UseVisualStyleBackColor = true;
            this.btnMoveGrais.Click += new System.EventHandler(this.clickMoveAllGrais);
            // 
            // btnMoveSelectedGrais
            // 
            this.btnMoveSelectedGrais.Location = new System.Drawing.Point(20, 395);
            this.btnMoveSelectedGrais.Name = "btnMoveSelectedGrais";
            this.btnMoveSelectedGrais.Size = new System.Drawing.Size(124, 35);
            this.btnMoveSelectedGrais.TabIndex = 11;
            this.btnMoveSelectedGrais.Text = "Move Selected Grais";
            this.btnMoveSelectedGrais.UseVisualStyleBackColor = true;
            this.btnMoveSelectedGrais.Click += new System.EventHandler(this.clickMoveSelectedGrais);
            // 
            // cbDeleteContainer
            // 
            this.cbDeleteContainer.AutoSize = true;
            this.cbDeleteContainer.Location = new System.Drawing.Point(406, 372);
            this.cbDeleteContainer.Name = "cbDeleteContainer";
            this.cbDeleteContainer.Size = new System.Drawing.Size(169, 17);
            this.cbDeleteContainer.TabIndex = 12;
            this.cbDeleteContainer.Text = "Delete Container When Empty";
            this.cbDeleteContainer.UseVisualStyleBackColor = true;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(695, 395);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(79, 35);
            this.btnCloseForm.TabIndex = 15;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.clickCloseForm);
            // 
            // lblToGraisCount
            // 
            this.lblToGraisCount.AutoSize = true;
            this.lblToGraisCount.Location = new System.Drawing.Point(403, 62);
            this.lblToGraisCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToGraisCount.Name = "lblToGraisCount";
            this.lblToGraisCount.Size = new System.Drawing.Size(24, 13);
            this.lblToGraisCount.TabIndex = 14;
            this.lblToGraisCount.Text = "test";
            // 
            // lblFromGraisCount
            // 
            this.lblFromGraisCount.AutoSize = true;
            this.lblFromGraisCount.Location = new System.Drawing.Point(20, 62);
            this.lblFromGraisCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFromGraisCount.Name = "lblFromGraisCount";
            this.lblFromGraisCount.Size = new System.Drawing.Size(24, 13);
            this.lblFromGraisCount.TabIndex = 13;
            this.lblFromGraisCount.Text = "test";
            // 
            // lblToGln
            // 
            this.lblToGln.Location = new System.Drawing.Point(470, 25);
            this.lblToGln.Name = "lblToGln";
            this.lblToGln.ReadOnly = true;
            this.lblToGln.Size = new System.Drawing.Size(133, 20);
            this.lblToGln.TabIndex = 16;
            // 
            // lblFromGln
            // 
            this.lblFromGln.Location = new System.Drawing.Point(77, 25);
            this.lblFromGln.Name = "lblFromGln";
            this.lblFromGln.ReadOnly = true;
            this.lblFromGln.Size = new System.Drawing.Size(109, 20);
            this.lblFromGln.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "From GLN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "To GLN:";
            // 
            // MoveContainersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFromGln);
            this.Controls.Add(this.lblToGln);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblToGraisCount);
            this.Controls.Add(this.lblFromGraisCount);
            this.Controls.Add(this.cbDeleteContainer);
            this.Controls.Add(this.btnMoveSelectedGrais);
            this.Controls.Add(this.btnMoveGrais);
            this.Controls.Add(this.lvToGln);
            this.Controls.Add(this.lvFromGrais);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MoveContainersForm";
            this.Text = "MoveContainersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvFromGrais;
        private System.Windows.Forms.ColumnHeader colFromGrais;
        private System.Windows.Forms.ListView lvToGln;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.ColumnHeader colToCount;
        private System.Windows.Forms.Button btnMoveGrais;
        private System.Windows.Forms.Button btnMoveSelectedGrais;
        private System.Windows.Forms.CheckBox cbDeleteContainer;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblToGraisCount;
        private System.Windows.Forms.Label lblFromGraisCount;
        private System.Windows.Forms.TextBox lblToGln;
        private System.Windows.Forms.TextBox lblFromGln;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}