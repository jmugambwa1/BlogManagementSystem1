namespace BlogManagementSystem
{
    partial class PostCardForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.flowComments = new System.Windows.Forms.FlowLayoutPanel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnPostComment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(58, 104);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(266, 72);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Post Title";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Segoe UI Semibold", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(58, 322);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(349, 72);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "Post Content";
            // 
            // flowComments
            // 
            this.flowComments.Location = new System.Drawing.Point(88, 595);
            this.flowComments.Name = "flowComments";
            this.flowComments.Size = new System.Drawing.Size(964, 313);
            this.flowComments.TabIndex = 2;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(88, 982);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(964, 94);
            this.txtComment.TabIndex = 3;
            // 
            // btnPostComment
            // 
            this.btnPostComment.BackColor = System.Drawing.Color.MediumPurple;
            this.btnPostComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPostComment.Font = new System.Drawing.Font("Segoe UI Semibold", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostComment.ForeColor = System.Drawing.Color.White;
            this.btnPostComment.Location = new System.Drawing.Point(291, 1129);
            this.btnPostComment.Name = "btnPostComment";
            this.btnPostComment.Size = new System.Drawing.Size(487, 92);
            this.btnPostComment.TabIndex = 4;
            this.btnPostComment.Text = "Post Comment";
            this.btnPostComment.UseVisualStyleBackColor = false;
            this.btnPostComment.Click += new System.EventHandler(this.btnPostComment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "Comments";
            // 
            // PostCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 1256);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPostComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.flowComments);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblTitle);
            this.Name = "PostCardForm";
            this.Text = "PostCardForm";
            this.Load += new System.EventHandler(this.PostCardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.FlowLayoutPanel flowComments;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnPostComment;
        private System.Windows.Forms.Label label1;
    }
}