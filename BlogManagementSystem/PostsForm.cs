using BlogManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BlogManagementSystem
{
    public partial class PostsForm : Form
    {

        public PostsForm()
        {
            InitializeComponent();
           
        }

        private Image LoadIcon(string fileName)
        {
            string path = Path.Combine(Application.StartupPath, "Icons", fileName);
            return File.Exists(path) ? Image.FromFile(path) : null;
        }


        private void flowPosts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PostsForm_Load(object sender, EventArgs e)
        {
            //LoadPosts();
         
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadPosts();

            flowPosts.SizeChanged += FlowPosts_SizeChanged;

        }

        private void FlowPosts_SizeChanged(object sender, EventArgs e)
        {
            int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;

            foreach (Control c in flowPosts.Controls)
            {
                if (c is Panel card)
                {
                    card.Width =
                        flowPosts.ClientSize.Width
                        - flowPosts.Padding.Left
                        - flowPosts.Padding.Right
                        - scrollbarWidth;
                }
            }
        }


        private Panel CreatePostCard(
            int postId,
            string title,
            string content,
            string category,
            DateTime createdAt,
            string authorUsername
            )
            {
            Panel card = new Panel
            {
                Height = 140,
                Width = flowPosts.Width - 40,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 15),
                //Anchor = AnchorStyles.Left | AnchorStyles.Right
                //Dock = DockStyle.Top
            };



            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Label lblContent = new Label
            {
                Text = content.Length > 160
                    ? content.Substring(0, 160) + "..."
                    : content,

                Location = new Point(20, lblTitle.Bottom + 8),
                MaximumSize = new Size(Math.Max(200, card.Width - 220),0),
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 0, 0, 0)
            };

            Label lblMeta = new Label
            {
                Text = $"{category} • {createdAt:MM/dd/yyyy}",
                Location = new Point(20, lblContent.Bottom + 10),
                ForeColor = Color.FromArgb(150, 0, 0, 0),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            Button btnEdit = new Button
            {
                Size = new Size(32, 32),
                Location = new Point(card.Width - 170, 15),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                BackgroundImage = LoadIcon("edit.png"),
                BackgroundImageLayout = ImageLayout.Zoom,
                TabStop = false,
                Text = "" 
            };

            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.LightGray;

            Button btnDelete = new Button
            {
                Size = new Size(32, 32),
                Location = new Point(card.Width - 90, 15),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                BackgroundImage = LoadIcon("delete.png"),
                BackgroundImageLayout = ImageLayout.Zoom,
                TabStop = false,
                Text = ""
            };

            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.MistyRose;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.LightCoral;

            bool canModify =
                 CurrentUser.Role == "Admin" ||
                 CurrentUser.Username == authorUsername;

            btnEdit.Visible = canModify;
            btnDelete.Visible = canModify;



            card.Resize += (s, e) =>
            {
                lblContent.MaximumSize = new Size(card.Width - 220, 0);

                lblContent.Location = new Point(20, lblTitle.Bottom + 8);
                lblMeta.Location = new Point(20, lblContent.Bottom + 10);

                card.Height = lblMeta.Bottom + 20;

                btnDelete.Left = card.Width - btnDelete.Width - 15;
                btnEdit.Left = btnDelete.Left - btnEdit.Width - 10;
            };



            btnDelete.BackColor = Color.Yellow;

            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show("Delete this post?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeletePost(postId);
                    LoadPosts();
                }
            };

            btnEdit.Click += (s, e) =>
            {
                PostEditorForm editor = new PostEditorForm(
                    postId,
                    title,
                    content,
                    GetCategoryIdByName(category)
                );

                editor.ShowDialog();
                LoadPosts();
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblContent);
            card.Controls.Add(lblMeta);
            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDelete);

            card.Height = lblMeta.Bottom + 20;

            FlowLayoutPanel comments = CreateCommentsPanel(postId);
            comments.Top = card.Height + 5;
            card.Controls.Add(comments);

            card.Height += comments.Height + 10;

            card.Cursor = Cursors.Hand;

            card.Click += (s, e) =>
            {
                PostCardForm postCard = new PostCardForm(postId);
                postCard.ShowDialog();
            };

            return card;
        }

        private int GetCategoryIdByName(string name)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT CategoryId FROM Categories WHERE Name = @name", con);

                cmd.Parameters.AddWithValue("@name", name);
                con.Open();

                return (int)cmd.ExecuteScalar();
            }
        }


        private void LoadPosts()
        {
            flowPosts.Controls.Clear();

            bool hasPosts = false;

            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
                SELECT p.PostId, p.Title, p.Content, c.Name AS Category, p.CreatedAt, p.AuthorUsername
                FROM Posts p
                JOIN Categories c ON p.CategoryId = c.CategoryId
                ORDER BY p.CreatedAt DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    hasPosts = true;

                    Panel postCard = CreatePostCard(
                        Convert.ToInt32(reader["PostId"]),
                        reader["Title"].ToString(),
                        reader["Content"].ToString(),
                        reader["Category"].ToString(),
                        Convert.ToDateTime(reader["CreatedAt"]),
                        reader["AuthorUsername"].ToString()
                    );

                    flowPosts.Controls.Add(postCard);
                }
            }

            if (!hasPosts)
            {
                Label lblEmpty = new Label
                {
                    Text = "No posts yet.",
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true,
                    Padding = new Padding(20)
                };

                flowPosts.Controls.Add(lblEmpty);
            }
        }


        private void btnNewPost_Click(object sender, EventArgs e)
        {
            PostEditorForm editor = new PostEditorForm();
            editor.ShowDialog();
            LoadPosts();
        }

        private void DeletePost(int postId)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = "DELETE FROM Posts WHERE PostId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", postId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private FlowLayoutPanel CreateCommentsPanel(int postId)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(245, 245, 245),
                Width = flowPosts.Width - 60
            };

            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT CommentId, AuthorUsername, Content, CreatedAt
            FROM Comments
            WHERE PostId = @postId
            ORDER BY CreatedAt ASC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@postId", postId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    panel.Controls.Add(CreateCommentItem(
                        Convert.ToInt32(reader["CommentId"]),
                        reader["AuthorUsername"].ToString(),
                        reader["Content"].ToString()
                    ));
                }
            }

            panel.Controls.Add(CreateAddCommentBox(postId));

            return panel;
        }

        private Panel CreateCommentItem(int commentId, string author, string content)
        {
            Panel item = new Panel
            {
                Width = flowPosts.Width - 100,
                AutoSize = true,
                BackColor = Color.White,
                Padding = new Padding(8),
                Margin = new Padding(0, 0, 0, 5)
            };

            Label lblText = new Label
            {
                Text = $"{author}: {content}",
                AutoSize = true,
                MaximumSize = new Size(item.Width - 80, 0)
            };

            Button btnDelete = new Button
            {
                Text = "X",
                Size = new Size(24, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Visible =
                    CurrentUser.Role == "Admin" ||
                    CurrentUser.Username == author
            };

            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) =>
            {
                DeleteComment(commentId);
                LoadPosts();
            };

            item.Controls.Add(lblText);
            item.Controls.Add(btnDelete);

            btnDelete.Location = new Point(item.Width - 30, 5);

            return item;
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

        private Panel CreateAddCommentBox(int postId)
        {
            Panel box = new Panel
            {
                Width = flowPosts.Width - 100,
                Height = 60
            };

            TextBox txt = new TextBox
            {
                Width = box.Width - 80,
                Location = new Point(0, 0)
            };

            Button btn = new Button
            {
                Text = "Post",
                Location = new Point(txt.Right + 5, 0)
            };

            btn.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text)) return;

                using (SqlConnection con = Database.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Comments (PostId, AuthorUsername, Content)
                VALUES (@postId, @author, @content)", con);

                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@author", CurrentUser.Username);
                    cmd.Parameters.AddWithValue("@content", txt.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadPosts();
            };

            box.Controls.Add(txt);
            box.Controls.Add(btn);

            return box;
        }

    }
}
