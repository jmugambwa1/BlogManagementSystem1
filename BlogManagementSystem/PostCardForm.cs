using BlogManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogManagementSystem
{
    public partial class PostCardForm : Form
    {
        private int _postId;

        public event Action CommentAdded;
        public PostCardForm(int postId)
        {
            InitializeComponent();
            _postId = postId;
        }

        private void PostCardForm_Load(object sender, EventArgs e)
        {
            LoadPost();
            LoadComments();
        }

        private void LoadPost()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT Title, Content
            FROM Posts
            WHERE PostId = @id", con);

                cmd.Parameters.AddWithValue("@id", _postId);
                con.Open();

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    lblTitle.Text = r["Title"].ToString();
                    lblContent.Text = r["Content"].ToString();
                }
            }
        }

        private void LoadComments()
        {
            flowComments.Controls.Clear();

            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT CommentId, AuthorUsername, Content
            FROM Comments
            WHERE PostId = @postId
            ORDER BY CreatedAt", con);

                cmd.Parameters.AddWithValue("@postId", _postId);
                con.Open();

                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    flowComments.Controls.Add(
                        CreateCommentItem(
                            (int)r["CommentId"],
                            r["AuthorUsername"].ToString(),
                            r["Content"].ToString()
                        )
                    );
                }
            }
        }

        private Panel CreateCommentItem(int commentId, string author, string content)
        {
            Panel panel = new Panel
            {
                Width = flowComments.Width - 25,
                Height = 40
            };

            Label lbl = new Label
            {
                Text = $"{author}: {content}",
                AutoSize = true
            };

            Button btnDelete = new Button
            {
                Text = "Delete",
                Left = panel.Width - 70,
                Visible =
                    CurrentUser.Role == "Admin" ||
                    CurrentUser.Username == author
            };

            btnDelete.Click += (s, e) =>
            {
                DeleteComment(commentId);
                LoadComments();
            };

            panel.Controls.Add(lbl);
            panel.Controls.Add(btnDelete);
            return panel;
        }

        private void btnPostComment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComment.Text))
                return;

            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Comments (PostId, AuthorUsername, Content)
            VALUES (@postId, @author, @content)", con);

                cmd.Parameters.AddWithValue("@postId", _postId);
                cmd.Parameters.AddWithValue("@author", CurrentUser.Username);
                cmd.Parameters.AddWithValue("@content", txtComment.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            txtComment.Clear();
            LoadComments();
            CommentAdded?.Invoke();

        }

        private void DeleteComment(int commentId)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Comments WHERE CommentId = @id", con);

                cmd.Parameters.AddWithValue("@id", commentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
