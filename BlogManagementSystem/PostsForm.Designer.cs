namespace BlogManagementSystem
{
    partial class PostsForm
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
            this.panelPosts = new System.Windows.Forms.Panel();
            this.flowPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoPosts = new System.Windows.Forms.Label();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelPosts.SuspendLayout();
            this.flowPosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPosts
            // 
            this.panelPosts.Controls.Add(this.flowPosts);
            this.panelPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPosts.Location = new System.Drawing.Point(0, 0);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.Size = new System.Drawing.Size(1676, 884);
            this.panelPosts.TabIndex = 0;
            // 
            // flowPosts
            // 
            this.flowPosts.AutoScroll = true;
            this.flowPosts.AutoSize = true;
            this.flowPosts.Controls.Add(this.lblNoPosts);
            this.flowPosts.Controls.Add(this.tableLayoutMain);
            this.flowPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPosts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPosts.Location = new System.Drawing.Point(0, 0);
            this.flowPosts.Margin = new System.Windows.Forms.Padding(0);
            this.flowPosts.Name = "flowPosts";
            this.flowPosts.Padding = new System.Windows.Forms.Padding(10);
            this.flowPosts.Size = new System.Drawing.Size(1676, 884);
            this.flowPosts.TabIndex = 2;
            this.flowPosts.WrapContents = false;
            this.flowPosts.Paint += new System.Windows.Forms.PaintEventHandler(this.flowPosts_Paint);
            // 
            // lblNoPosts
            // 
            this.lblNoPosts.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoPosts.ForeColor = System.Drawing.Color.Gray;
            this.lblNoPosts.Location = new System.Drawing.Point(13, 10);
            this.lblNoPosts.Name = "lblNoPosts";
            this.lblNoPosts.Size = new System.Drawing.Size(442, 162);
            this.lblNoPosts.TabIndex = 0;
            this.lblNoPosts.Text = "No posts yet.";
            this.lblNoPosts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoPosts.Visible = false;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(13, 175);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 2;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Size = new System.Drawing.Size(442, 749);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // PostsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1676, 884);
            this.Controls.Add(this.panelPosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PostsForm";
            this.Text = "PostsForm";
            this.panelPosts.ResumeLayout(false);
            this.panelPosts.PerformLayout();
            this.flowPosts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPosts;
        private System.Windows.Forms.FlowLayoutPanel flowPosts;
        private System.Windows.Forms.Label lblNoPosts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
    }
}