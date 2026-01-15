namespace BlogManagementSystem
{
    partial class DashboardForm
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
            this.lblPosts = new System.Windows.Forms.Label();
            this.panelPosts = new System.Windows.Forms.Panel();
            this.lblTotalPosts = new System.Windows.Forms.Label();
            this.panelComments = new System.Windows.Forms.Panel();
            this.lblTotalComments = new System.Windows.Forms.Label();
            this.lblComments = new System.Windows.Forms.Label();
            this.panelCategories = new System.Windows.Forms.Panel();
            this.lblTotalCategories = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.panelUserPosts = new System.Windows.Forms.Panel();
            this.lblYourPosts = new System.Windows.Forms.Label();
            this.lablePosts = new System.Windows.Forms.Label();
            this.lblRecentPosts = new System.Windows.Forms.Label();
            this.panelRecentPosts = new System.Windows.Forms.Panel();
            this.lblRecentPost = new System.Windows.Forms.Label();
            this.btnCreatePost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPosts.SuspendLayout();
            this.panelComments.SuspendLayout();
            this.panelCategories.SuspendLayout();
            this.panelUserPosts.SuspendLayout();
            this.panelRecentPosts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosts
            // 
            this.lblPosts.AutoSize = true;
            this.lblPosts.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosts.ForeColor = System.Drawing.Color.Gray;
            this.lblPosts.Location = new System.Drawing.Point(98, 34);
            this.lblPosts.Name = "lblPosts";
            this.lblPosts.Size = new System.Drawing.Size(210, 50);
            this.lblPosts.TabIndex = 0;
            this.lblPosts.Text = "Total Posts";
            // 
            // panelPosts
            // 
            this.panelPosts.BackColor = System.Drawing.Color.White;
            this.panelPosts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPosts.Controls.Add(this.lblTotalPosts);
            this.panelPosts.Controls.Add(this.lblPosts);
            this.panelPosts.Location = new System.Drawing.Point(23, 25);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.Size = new System.Drawing.Size(379, 203);
            this.panelPosts.TabIndex = 1;
            // 
            // lblTotalPosts
            // 
            this.lblTotalPosts.AutoSize = true;
            this.lblTotalPosts.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPosts.Location = new System.Drawing.Point(161, 100);
            this.lblTotalPosts.Name = "lblTotalPosts";
            this.lblTotalPosts.Size = new System.Drawing.Size(60, 71);
            this.lblTotalPosts.TabIndex = 1;
            this.lblTotalPosts.Text = "0";
            // 
            // panelComments
            // 
            this.panelComments.BackColor = System.Drawing.Color.White;
            this.panelComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComments.Controls.Add(this.lblTotalComments);
            this.panelComments.Controls.Add(this.lblComments);
            this.panelComments.Location = new System.Drawing.Point(871, 25);
            this.panelComments.Name = "panelComments";
            this.panelComments.Size = new System.Drawing.Size(392, 203);
            this.panelComments.TabIndex = 2;
            // 
            // lblTotalComments
            // 
            this.lblTotalComments.AutoSize = true;
            this.lblTotalComments.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalComments.Location = new System.Drawing.Point(162, 100);
            this.lblTotalComments.Name = "lblTotalComments";
            this.lblTotalComments.Size = new System.Drawing.Size(60, 71);
            this.lblTotalComments.TabIndex = 1;
            this.lblTotalComments.Text = "0";
            this.lblTotalComments.Click += new System.EventHandler(this.lblTotalComments_Click);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.ForeColor = System.Drawing.Color.Gray;
            this.lblComments.Location = new System.Drawing.Point(104, 37);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(208, 50);
            this.lblComments.TabIndex = 0;
            this.lblComments.Text = "Comments";
            // 
            // panelCategories
            // 
            this.panelCategories.BackColor = System.Drawing.Color.White;
            this.panelCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategories.Controls.Add(this.lblTotalCategories);
            this.panelCategories.Controls.Add(this.lblCategories);
            this.panelCategories.Location = new System.Drawing.Point(440, 25);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(394, 203);
            this.panelCategories.TabIndex = 3;
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.AutoSize = true;
            this.lblTotalCategories.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCategories.Location = new System.Drawing.Point(158, 100);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(60, 71);
            this.lblTotalCategories.TabIndex = 1;
            this.lblTotalCategories.Text = "0";
            this.lblTotalCategories.Click += new System.EventHandler(this.lblTotalCategories_Click);
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.ForeColor = System.Drawing.Color.Gray;
            this.lblCategories.Location = new System.Drawing.Point(98, 34);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(207, 50);
            this.lblCategories.TabIndex = 0;
            this.lblCategories.Text = "Categories";
            this.lblCategories.Click += new System.EventHandler(this.lblTotalCategories_Click);
            // 
            // panelUserPosts
            // 
            this.panelUserPosts.BackColor = System.Drawing.Color.White;
            this.panelUserPosts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserPosts.Controls.Add(this.lblYourPosts);
            this.panelUserPosts.Controls.Add(this.lablePosts);
            this.panelUserPosts.Location = new System.Drawing.Point(1303, 25);
            this.panelUserPosts.Name = "panelUserPosts";
            this.panelUserPosts.Size = new System.Drawing.Size(398, 203);
            this.panelUserPosts.TabIndex = 4;
            this.panelUserPosts.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lblYourPosts
            // 
            this.lblYourPosts.AutoSize = true;
            this.lblYourPosts.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourPosts.Location = new System.Drawing.Point(159, 100);
            this.lblYourPosts.Name = "lblYourPosts";
            this.lblYourPosts.Size = new System.Drawing.Size(60, 71);
            this.lblYourPosts.TabIndex = 1;
            this.lblYourPosts.Text = "0";
            // 
            // lablePosts
            // 
            this.lablePosts.AutoSize = true;
            this.lablePosts.Font = new System.Drawing.Font("Segoe UI", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablePosts.ForeColor = System.Drawing.Color.Gray;
            this.lablePosts.Location = new System.Drawing.Point(96, 37);
            this.lablePosts.Name = "lablePosts";
            this.lablePosts.Size = new System.Drawing.Size(202, 50);
            this.lablePosts.TabIndex = 0;
            this.lablePosts.Text = "Your Posts";
            // 
            // lblRecentPosts
            // 
            this.lblRecentPosts.AutoSize = true;
            this.lblRecentPosts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentPosts.Location = new System.Drawing.Point(97, 288);
            this.lblRecentPosts.Name = "lblRecentPosts";
            this.lblRecentPosts.Size = new System.Drawing.Size(235, 54);
            this.lblRecentPosts.TabIndex = 5;
            this.lblRecentPosts.Text = "RecentPosts";
            // 
            // panelRecentPosts
            // 
            this.panelRecentPosts.BackColor = System.Drawing.Color.White;
            this.panelRecentPosts.Controls.Add(this.lblRecentPost);
            this.panelRecentPosts.Controls.Add(this.btnCreatePost);
            this.panelRecentPosts.Controls.Add(this.label1);
            this.panelRecentPosts.Location = new System.Drawing.Point(23, 357);
            this.panelRecentPosts.Name = "panelRecentPosts";
            this.panelRecentPosts.Size = new System.Drawing.Size(1678, 603);
            this.panelRecentPosts.TabIndex = 6;
            this.panelRecentPosts.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRecentPosts_Paint);
            // 
            // lblRecentPost
            // 
            this.lblRecentPost.AutoSize = true;
            this.lblRecentPost.Font = new System.Drawing.Font("Segoe UI Semibold", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentPost.ForeColor = System.Drawing.Color.Gray;
            this.lblRecentPost.Location = new System.Drawing.Point(87, 23);
            this.lblRecentPost.Name = "lblRecentPost";
            this.lblRecentPost.Size = new System.Drawing.Size(0, 46);
            this.lblRecentPost.TabIndex = 2;
            // 
            // btnCreatePost
            // 
            this.btnCreatePost.BackColor = System.Drawing.Color.MediumPurple;
            this.btnCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePost.ForeColor = System.Drawing.Color.White;
            this.btnCreatePost.Location = new System.Drawing.Point(623, 406);
            this.btnCreatePost.Name = "btnCreatePost";
            this.btnCreatePost.Size = new System.Drawing.Size(356, 100);
            this.btnCreatePost.TabIndex = 1;
            this.btnCreatePost.Text = "+ Create Post";
            this.btnCreatePost.UseVisualStyleBackColor = false;
            this.btnCreatePost.Click += new System.EventHandler(this.btnCreatePost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(527, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "No posts yet. Create your first post!";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1708, 972);
            this.Controls.Add(this.panelRecentPosts);
            this.Controls.Add(this.lblRecentPosts);
            this.Controls.Add(this.panelUserPosts);
            this.Controls.Add(this.panelCategories);
            this.Controls.Add(this.panelComments);
            this.Controls.Add(this.panelPosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelPosts.ResumeLayout(false);
            this.panelPosts.PerformLayout();
            this.panelComments.ResumeLayout(false);
            this.panelComments.PerformLayout();
            this.panelCategories.ResumeLayout(false);
            this.panelCategories.PerformLayout();
            this.panelUserPosts.ResumeLayout(false);
            this.panelUserPosts.PerformLayout();
            this.panelRecentPosts.ResumeLayout(false);
            this.panelRecentPosts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPosts;
        private System.Windows.Forms.Panel panelPosts;
        private System.Windows.Forms.Panel panelComments;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.Panel panelUserPosts;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label lablePosts;
        private System.Windows.Forms.Label lblTotalPosts;
        private System.Windows.Forms.Label lblTotalComments;
        private System.Windows.Forms.Label lblTotalCategories;
        private System.Windows.Forms.Label lblYourPosts;
        private System.Windows.Forms.Label lblRecentPosts;
        private System.Windows.Forms.Panel panelRecentPosts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreatePost;
        private System.Windows.Forms.Label lblRecentPost;
    }
}