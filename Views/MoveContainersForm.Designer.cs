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
            this.colFromGrais = new System.Windows.Forms.ColumnHeader();
            this.colCount = new System.Windows.Forms.ColumnHeader();
            this.lvToGln = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.colToCount = new System.Windows.Forms.ColumnHeader();
            this.btnMoveSelectedGrais = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.lblToGraisCount = new System.Windows.Forms.Label();
            this.lblFromGraisCount = new System.Windows.Forms.Label();
            this.lblToGln = new System.Windows.Forms.TextBox();
            this.lblFromGln = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lvFromGrais
            // 
            this.lvFromGrais.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colFromGrais, this.colCount });
            this.lvFromGrais.HideSelection = false;
            this.lvFromGrais.Location = new System.Drawing.Point(30, 134);
            this.lvFromGrais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvFromGrais.Name = "lvFromGrais";
            this.lvFromGrais.Size = new System.Drawing.Size(520, 426);
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
            this.lvToGln.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1, this.colToCount });
            this.lvToGln.HideSelection = false;
            this.lvToGln.Location = new System.Drawing.Point(606, 134);
            this.lvToGln.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvToGln.Name = "lvToGln";
            this.lvToGln.Size = new System.Drawing.Size(553, 426);
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
            // btnMoveSelectedGrais
            // 
            this.btnMoveSelectedGrais.Location = new System.Drawing.Point(30, 608);
            this.btnMoveSelectedGrais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoveSelectedGrais.Name = "btnMoveSelectedGrais";
            this.btnMoveSelectedGrais.Size = new System.Drawing.Size(186, 54);
            this.btnMoveSelectedGrais.TabIndex = 11;
            this.btnMoveSelectedGrais.Text = "Move Selected Grais";
            this.btnMoveSelectedGrais.UseVisualStyleBackColor = true;
            this.btnMoveSelectedGrais.Click += new System.EventHandler(this.clickMoveSelectedGrais);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(1042, 608);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(118, 54);
            this.btnCloseForm.TabIndex = 15;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.clickCloseForm);
            // 
            // lblToGraisCount
            // 
            this.lblToGraisCount.AutoSize = true;
            this.lblToGraisCount.Location = new System.Drawing.Point(604, 95);
            this.lblToGraisCount.Name = "lblToGraisCount";
            this.lblToGraisCount.Size = new System.Drawing.Size(36, 20);
            this.lblToGraisCount.TabIndex = 14;
            this.lblToGraisCount.Text = "test";
            // 
            // lblFromGraisCount
            // 
            this.lblFromGraisCount.AutoSize = true;
            this.lblFromGraisCount.Location = new System.Drawing.Point(30, 95);
            this.lblFromGraisCount.Name = "lblFromGraisCount";
            this.lblFromGraisCount.Size = new System.Drawing.Size(36, 20);
            this.lblFromGraisCount.TabIndex = 13;
            this.lblFromGraisCount.Text = "test";
            // 
            // lblToGln
            // 
            this.lblToGln.Location = new System.Drawing.Point(705, 38);
            this.lblToGln.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblToGln.Name = "lblToGln";
            this.lblToGln.ReadOnly = true;
            this.lblToGln.Size = new System.Drawing.Size(198, 26);
            this.lblToGln.TabIndex = 16;
            // 
            // lblFromGln
            // 
            this.lblFromGln.Location = new System.Drawing.Point(116, 38);
            this.lblFromGln.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblFromGln.Name = "lblFromGln";
            this.lblFromGln.ReadOnly = true;
            this.lblFromGln.Size = new System.Drawing.Size(162, 26);
            this.lblFromGln.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "From GLN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "To GLN:";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(42, 573);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(151, 24);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkAllFromGln);
            // 
            // MoveContainersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 702);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFromGln);
            this.Controls.Add(this.lblToGln);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblToGraisCount);
            this.Controls.Add(this.lblFromGraisCount);
            this.Controls.Add(this.btnMoveSelectedGrais);
            this.Controls.Add(this.lvToGln);
            this.Controls.Add(this.lvFromGrais);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveContainersForm";
            this.Text = "MoveContainersForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox checkBox1;

        #endregion
        private System.Windows.Forms.ListView lvFromGrais;
        private System.Windows.Forms.ColumnHeader colFromGrais;
        private System.Windows.Forms.ListView lvToGln;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.ColumnHeader colToCount;
        private System.Windows.Forms.Button btnMoveSelectedGrais;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Label lblToGraisCount;
        private System.Windows.Forms.Label lblFromGraisCount;
        private System.Windows.Forms.TextBox lblToGln;
        private System.Windows.Forms.TextBox lblFromGln;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}