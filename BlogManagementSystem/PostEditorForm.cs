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
    public partial class PostEditorForm : Form
    {


        private int _postId = -1;
        private bool _isEditMode = false;

        private int _selectedCategoryId = -1;



        public PostEditorForm()
        {
            InitializeComponent();
        }

        public PostEditorForm(
            int postId,
            string title,
            string content,
            int categoryId
        )
        {
            InitializeComponent();

            _postId = postId;
            _isEditMode = true;

            txtTitle.Text = title;
            txtContent.Text = content;
            _selectedCategoryId = categoryId;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PostEditorForm_Load(object sender, EventArgs e)
        {
            LoadCategories();

            if (_isEditMode)
            {
                this.Text = "Edit Post";
                btnSave.Text = "Update Post";
            }
            else
            {
                this.Text = "New Post";
                btnSave.Text = "Publish Post";
            }
        }

        private void LoadCategories()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = "SELECT CategoryId, Name FROM Categories ORDER BY Name";
                SqlCommand cmd = new SqlCommand(query, con);

                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());

                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryId";
                cmbCategory.DataSource = dt;

                if (_isEditMode && _selectedCategoryId != -1)
                {
                    cmbCategory.SelectedValue = _selectedCategoryId;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Enter a title.");
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Select a category.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Enter content.");
                return;
            }

            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd;

                if (_isEditMode)
                {
                    cmd = new SqlCommand(@"
                UPDATE Posts
                SET Title = @title,
                    Content = @content,
                    CategoryId = @categoryId
                WHERE PostId = @id
            ", con);

                    cmd.Parameters.AddWithValue("@id", _postId);
                }
                else
                {
                    cmd = new SqlCommand(@"
                INSERT INTO Posts (Title, Content, CategoryId, AuthorUsername)
                VALUES (@title, @content, @categoryId, @author)
            ", con);

                    cmd.Parameters.AddWithValue("@author", CurrentUser.Username);
                }

                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@content", txtContent.Text.Trim());
                cmd.Parameters.AddWithValue("@categoryId", categoryId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Post saved successfully.");
            this.Close();
        }


    }
}
