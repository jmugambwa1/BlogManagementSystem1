using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BlogManagementSystem.Data;


namespace BlogManagementSystem
{
    public partial class DashboardForm : Form
    {
        private string _username;

        public event Action CreatePostRequested;


        public DashboardForm()
        {
            InitializeComponent();
        }
        public DashboardForm(string username) : this()
        {
            _username = username;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
         
            LoadRecentPost();
            LoadCategoryCount();
            LoadTotalPosts();
            LoadYourPosts();
            LoadTotalComments();
        }

        private void LoadCategoryCount()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Categories";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                int count = (int)cmd.ExecuteScalar();

                lblTotalCategories.Text = count.ToString();
            }
        }

        public void LoadTotalComments()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Comments", con);

                con.Open();
                lblTotalComments.Text = cmd.ExecuteScalar().ToString();
            }
        }



        private void LoadTotalPosts()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Posts", con);

                con.Open();
                lblTotalPosts.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void LoadYourPosts()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Posts WHERE AuthorUsername = @user", con);

                cmd.Parameters.AddWithValue("@user", CurrentUser.Username);

                con.Open();
                lblYourPosts.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void LoadRecentPost()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
                    SELECT TOP 1 p.Title, c.Name AS Category, p.CreatedAt
                    FROM Posts p
                    JOIN Categories c ON p.CategoryId = c.CategoryId
                    ORDER BY p.CreatedAt DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblRecentPost.Text =
                        $"{reader["Title"]}\n" +
                        $"{reader["Category"]} • {Convert.ToDateTime(reader["CreatedAt"]):MM/dd/yyyy}";
                }
                else
                {
                    lblRecentPost.Text = "No posts yet.";
                }
            }
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalCategories_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalComments_Click(object sender, EventArgs e)
        {

        }

        private void panelRecentPosts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreatePost_Click(object sender, EventArgs e)
        {
            CreatePostRequested?.Invoke();
        }
    }
}
