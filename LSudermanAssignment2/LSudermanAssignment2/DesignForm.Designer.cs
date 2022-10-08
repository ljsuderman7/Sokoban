namespace LSudermanAssignment2
{
    partial class DesignForm
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
            this.btnDestination = new System.Windows.Forms.Button();
            this.btnBox = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnHero = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(14, 457);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(135, 65);
            this.btnDestination.TabIndex = 10;
            this.btnDestination.Text = "Desination";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // btnBox
            // 
            this.btnBox.Location = new System.Drawing.Point(14, 386);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(135, 65);
            this.btnBox.TabIndex = 11;
            this.btnBox.Text = "Box";
            this.btnBox.UseVisualStyleBackColor = true;
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // btnWall
            // 
            this.btnWall.Location = new System.Drawing.Point(14, 315);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(135, 65);
            this.btnWall.TabIndex = 12;
            this.btnWall.Text = "Wall";
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.btnWall_Click);
            // 
            // btnHero
            // 
            this.btnHero.Location = new System.Drawing.Point(14, 244);
            this.btnHero.Name = "btnHero";
            this.btnHero.Size = new System.Drawing.Size(135, 65);
            this.btnHero.TabIndex = 13;
            this.btnHero.Text = "Hero";
            this.btnHero.UseVisualStyleBackColor = true;
            this.btnHero.Click += new System.EventHandler(this.btnHero_Click);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(14, 173);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(135, 65);
            this.btnNone.TabIndex = 14;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(561, 31);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(131, 28);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(424, 31);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(131, 22);
            this.txtColumns.TabIndex = 8;
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(215, 31);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(131, 22);
            this.txtRows.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Columns:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rows:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1211, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLevelToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveLevelToolStripMenuItem.Text = "Save Level";
            this.saveLevelToolStripMenuItem.Click += new System.EventHandler(this.saveLevelToolStripMenuItem_Click);
            // 
            // DesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 640);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.btnBox);
            this.Controls.Add(this.btnWall);
            this.Controls.Add(this.btnHero);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtColumns);
            this.Controls.Add(this.txtRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DesignForm";
            this.Text = "Design Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button btnHero;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
    }
}