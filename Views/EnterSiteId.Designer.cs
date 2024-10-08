﻿using System.ComponentModel;

namespace iGPS_Help_Desk.Views
{
    partial class EnterSiteId
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterSiteId));
            this.txtSiteId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSiteId
            // 
            this.txtSiteId.Location = new System.Drawing.Point(238, 148);
            this.txtSiteId.Name = "txtSiteId";
            this.txtSiteId.Size = new System.Drawing.Size(246, 26);
            this.txtSiteId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(238, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Site Id:";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(238, 358);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(244, 38);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.ClickSubmitId);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 62);
            this.label2.TabIndex = 8;
            this.label2.Text = "iGPS Help Desk Tool";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(238, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "Folder Path To Save:";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(238, 256);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(246, 26);
            this.txtFolderPath.TabIndex = 9;
            // 
            // EnterSiteId
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSiteId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnterSiteId";
            this.Text = "EnterSiteId";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFolderPath;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox txtSiteId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnter;

        #endregion
    }
}