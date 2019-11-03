namespace ProjektGK1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVertexToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePropetiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sameLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointsToolStripMenuItem,
            this.linesToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.newToolStripMenuItem,
            this.finishGraphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(13, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(461, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveGraphToolStripMenuItem,
            this.moveVertexToolStripMenuItem,
            this.deleteVertexToolStripMenuItem,
            this.addVertexToolStripMenuItem});
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.pointsToolStripMenuItem.Text = "Vertex";
            // 
            // moveGraphToolStripMenuItem
            // 
            this.moveGraphToolStripMenuItem.Name = "moveGraphToolStripMenuItem";
            this.moveGraphToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.moveGraphToolStripMenuItem.Text = "Move Graph";
            this.moveGraphToolStripMenuItem.Click += new System.EventHandler(this.moveGraphToolStripMenuItem_Click);
            // 
            // moveVertexToolStripMenuItem
            // 
            this.moveVertexToolStripMenuItem.Name = "moveVertexToolStripMenuItem";
            this.moveVertexToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.moveVertexToolStripMenuItem.Text = "Move Vertex";
            this.moveVertexToolStripMenuItem.Click += new System.EventHandler(this.moveVertexToolStripMenuItem_Click);
            // 
            // deleteVertexToolStripMenuItem
            // 
            this.deleteVertexToolStripMenuItem.Name = "deleteVertexToolStripMenuItem";
            this.deleteVertexToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.deleteVertexToolStripMenuItem.Text = "Delete Vertex";
            this.deleteVertexToolStripMenuItem.Click += new System.EventHandler(this.deleteVertexToolStripMenuItem_Click);
            // 
            // addVertexToolStripMenuItem
            // 
            this.addVertexToolStripMenuItem.Name = "addVertexToolStripMenuItem";
            this.addVertexToolStripMenuItem.Size = new System.Drawing.Size(217, 34);
            this.addVertexToolStripMenuItem.Text = "Add Vertex";
            this.addVertexToolStripMenuItem.Click += new System.EventHandler(this.addVertexToolStripMenuItem_Click);
            // 
            // linesToolStripMenuItem
            // 
            this.linesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveEdgeToolStripMenuItem,
            this.addVertexToolStripMenuItem1});
            this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
            this.linesToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.linesToolStripMenuItem.Text = "Edges";
            // 
            // moveEdgeToolStripMenuItem
            // 
            this.moveEdgeToolStripMenuItem.Name = "moveEdgeToolStripMenuItem";
            this.moveEdgeToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.moveEdgeToolStripMenuItem.Text = "Move Edge";
            this.moveEdgeToolStripMenuItem.Click += new System.EventHandler(this.moveEdgeToolStripMenuItem_Click);
            // 
            // addVertexToolStripMenuItem1
            // 
            this.addVertexToolStripMenuItem1.Name = "addVertexToolStripMenuItem1";
            this.addVertexToolStripMenuItem1.Size = new System.Drawing.Size(277, 34);
            this.addVertexToolStripMenuItem1.Text = "Add Vertex To Graph";
            this.addVertexToolStripMenuItem1.Click += new System.EventHandler(this.addVertexToolStripMenuItem1_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removePropetiesToolStripMenuItem,
            this.sameLengthToolStripMenuItem,
            this.paToolStripMenuItem,
            this.dontMoveToolStripMenuItem});
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(108, 29);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // removePropetiesToolStripMenuItem
            // 
            this.removePropetiesToolStripMenuItem.Name = "removePropetiesToolStripMenuItem";
            this.removePropetiesToolStripMenuItem.Size = new System.Drawing.Size(245, 34);
            this.removePropetiesToolStripMenuItem.Text = "Remove Propety";
            this.removePropetiesToolStripMenuItem.Click += new System.EventHandler(this.removePropetiesToolStripMenuItem_Click);
            // 
            // sameLengthToolStripMenuItem
            // 
            this.sameLengthToolStripMenuItem.Name = "sameLengthToolStripMenuItem";
            this.sameLengthToolStripMenuItem.Size = new System.Drawing.Size(245, 34);
            this.sameLengthToolStripMenuItem.Text = "Same Length";
            this.sameLengthToolStripMenuItem.Click += new System.EventHandler(this.sameLengthToolStripMenuItem_Click);
            // 
            // paToolStripMenuItem
            // 
            this.paToolStripMenuItem.Name = "paToolStripMenuItem";
            this.paToolStripMenuItem.Size = new System.Drawing.Size(245, 34);
            this.paToolStripMenuItem.Text = "Parallel";
            this.paToolStripMenuItem.Click += new System.EventHandler(this.paToolStripMenuItem_Click);
            // 
            // dontMoveToolStripMenuItem
            // 
            this.dontMoveToolStripMenuItem.Name = "dontMoveToolStripMenuItem";
            this.dontMoveToolStripMenuItem.Size = new System.Drawing.Size(245, 34);
            this.dontMoveToolStripMenuItem.Text = "Dont move";
            this.dontMoveToolStripMenuItem.Click += new System.EventHandler(this.dontMoveToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.newToolStripMenuItem.Text = "Clear";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // finishGraphToolStripMenuItem
            // 
            this.finishGraphToolStripMenuItem.Name = "finishGraphToolStripMenuItem";
            this.finishGraphToolStripMenuItem.Size = new System.Drawing.Size(126, 29);
            this.finishGraphToolStripMenuItem.Text = "Finish Graph";
            this.finishGraphToolStripMenuItem.Click += new System.EventHandler(this.finishGraphToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(854, 544);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 594);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVertexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePropetiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sameLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontMoveToolStripMenuItem;
    }
}

